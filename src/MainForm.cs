using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing.Printing;

namespace VAGFahrplan
{
    public partial class MainForm : Form
    {
        private ListBox autocompleteList;
        private string currentStationId = null;
        private string currentStationName = null;
        private Timer autoRefreshTimer;
        private Timer clockTimer;

        public MainForm()
        {
            InitializeComponent();

            // Autocomplete-Liste initialisieren
            autocompleteList = new ListBox();
            autocompleteList.Width = txtSearch.Width;
            autocompleteList.Height = 150;
            autocompleteList.Visible = false;
            autocompleteList.Click += AutocompleteList_Click;
            autocompleteList.DrawMode = DrawMode.OwnerDrawFixed;
            autocompleteList.DrawItem += AutocompleteList_DrawItem;
            this.Controls.Add(autocompleteList);

            // Event-Handler hinzufügen
            txtSearch.TextChanged += TxtSearch_TextChanged;
            txtSearch.KeyDown += TxtSearch_KeyDown;
            btnSearch.Click += BtnSearch_Click;
            lstStations.SelectedIndexChanged += LstStations_SelectedIndexChanged;
            btnRefresh.Click += BtnRefresh_Click;
            btnPrint.Click += BtnPrint_Click;

            // Timer für automatische Aktualisierung
            autoRefreshTimer = new Timer();
            autoRefreshTimer.Interval = 30000; // 30 Sekunden
            autoRefreshTimer.Tick += AutoRefreshTimer_Tick;

            // Uhr-Timer initialisieren
            clockTimer = new Timer();
            clockTimer.Interval = 1000; // 1 Sekunde
            clockTimer.Tick += ClockTimer_Tick;
            clockTimer.Start();

            // ListView-Konfiguration
            lstStations.View = View.Details;
            lstStations.FullRowSelect = true;
            lstStations.Columns.Add("Haltestelle", -2);

            lstDepartures.View = View.Details;
            lstDepartures.FullRowSelect = true;
            lstDepartures.Columns.Add("Linie", 60);
            lstDepartures.Columns.Add("Zeit", 60);
            lstDepartures.Columns.Add("Ziel", 250);
            lstDepartures.Columns.Add("Minuten", 70);
            lstDepartures.Columns.Add("Fahrzeug", 120);

            // Form-Events
            this.Load += MainForm_Load;
            this.FormClosed += MainForm_FormClosed;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            autoRefreshTimer.Stop();
            clockTimer.Stop();
        }

        private void AutoRefreshTimer_Tick(object sender, EventArgs e)
        {
            if (currentStationId != null && tabControl.SelectedIndex == 1)
            {
                RefreshDepartures();
            }
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            // Aktuelle Zeit anzeigen
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void AutocompleteList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), e.Bounds);
            }

            using (var brush = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString(autocompleteList.Items[e.Index].ToString(), e.Font, brush, e.Bounds);
            }

            e.DrawFocusRectangle();
        }

        private void AutocompleteList_Click(object sender, EventArgs e)
        {
            if (autocompleteList.SelectedItem != null)
            {
                string selectedText = autocompleteList.SelectedItem.ToString();
                txtSearch.Text = selectedText;
                autocompleteList.Visible = false;
                txtSearch.Focus();
            }
        }

        private async void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (searchText.Length >= 2)
            {
                autocompleteList.Location = new Point(txtSearch.Left, txtSearch.Bottom);
                await SearchStationsForAutocomplete(searchText);
            }
            else
            {
                autocompleteList.Visible = false;
            }
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (autocompleteList.Visible)
            {
                if (e.KeyCode == Keys.Down && autocompleteList.Items.Count > 0)
                {
                    autocompleteList.SelectedIndex = autocompleteList.SelectedIndex < 0 ? 0 : autocompleteList.SelectedIndex;
                    autocompleteList.Focus();
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    autocompleteList.Visible = false;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Enter && autocompleteList.SelectedItem != null)
                {
                    txtSearch.Text = autocompleteList.SelectedItem.ToString();
                    autocompleteList.Visible = false;
                    e.Handled = true;
                    SearchStations();
                }
            }

            if (e.KeyCode == Keys.Enter && !e.Handled)
            {
                SearchStations();
                e.Handled = true;
            }
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            await SearchStationsAsync();
        }

        private async Task SearchStationsForAutocomplete(string query)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest("https://start.vag.de/dm/api/v1/haltestellen/vgn");
                request.AddParameter("name", query);

                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    var result = JsonConvert.DeserializeObject<JObject>(response.Content);
                    var stations = result["Haltestellen"].ToObject<List<JObject>>();

                    autocompleteList.Items.Clear();

                    foreach (var station in stations)
                    {
                        autocompleteList.Items.Add(station["Haltestellenname"].ToString());
                    }

                    if (autocompleteList.Items.Count > 0)
                    {
                        autocompleteList.Visible = true;
                    }
                    else
                    {
                        autocompleteList.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler bei Autocomplete: " + ex.Message);
                autocompleteList.Visible = false;
            }
        }

        private async Task SearchStationsAsync()
        {
            string query = txtSearch.Text.Trim();

            if (query.Length < 2)
            {
                MessageBox.Show("Bitte geben Sie mindestens 2 Buchstaben ein.", "Hinweis",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                lstStations.Items.Clear();

                var client = new RestClient();
                var request = new RestRequest("https://start.vag.de/dm/api/v1/haltestellen/vgn");
                request.AddParameter("name", query);

                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    var result = JsonConvert.DeserializeObject<JObject>(response.Content);
                    var stations = result["Haltestellen"].ToObject<List<JObject>>();

                    foreach (var station in stations)
                    {
                        string stationName = station["Haltestellenname"].ToString();
                        string stationId = station["VGNKennung"].ToString();

                        var item = new ListViewItem(stationName);
                        item.Tag = new StationInfo
                        {
                            Id = stationId,
                            Name = stationName
                        };
                        lstStations.Items.Add(item);
                    }

                    if (lstStations.Items.Count > 0)
                    {
                        tabControl.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Keine Haltestellen gefunden.", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler bei der Suche: " + ex.Message, "Fehler",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchStations()
        {
            // Direkt ausführen statt Task.Run zu verwenden
            SearchStationsAsync().ConfigureAwait(false);
        }

        private void LstStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstStations.SelectedItems.Count > 0)
            {
                var selectedItem = lstStations.SelectedItems[0];
                var stationInfo = (StationInfo)selectedItem.Tag;

                currentStationId = stationInfo.Id;
                currentStationName = stationInfo.Name;

                LoadDepartures();

                tabControl.SelectedIndex = 1;
            }
        }

        private async void LoadDepartures()
        {
            if (string.IsNullOrEmpty(currentStationId)) return;

            try
            {
                lblStationName.Text = $"Abfahrten: {currentStationName}";
                lstDepartures.Items.Clear();

                string apiUrl = $"https://start.vag.de/dm/api/v1/abfahrten/vgn/{currentStationId}";
                Debug.WriteLine("API URL: " + apiUrl);

                var client = new RestClient();
                var request = new RestRequest(apiUrl);

                var response = await client.ExecuteAsync(request);

                Debug.WriteLine("API Status: " + response.StatusCode);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    Debug.WriteLine("Antwort erhalten: " + response.Content.Length + " Zeichen");
                    var result = JsonConvert.DeserializeObject<JObject>(response.Content);

                    if (result != null && result["Abfahrten"] != null)
                    {
                        var departures = result["Abfahrten"].ToObject<List<JObject>>();
                        Debug.WriteLine($"Abfahrten in API-Antwort: {departures.Count}");

                        var departureItems = new List<DepartureInfo>();
                        DateTime now = DateTime.Now;

                        foreach (var dep in departures)
                        {
                            Debug.WriteLine($"Verarbeite Abfahrt: {dep.ToString(Formatting.None)}");

                            string line = dep["Linienname"]?.ToString() ?? "?";
                            string destination = dep["Richtungstext"]?.ToString() ?? "Unbekannt";
                            string vehicleNumber = dep["Fahrzeugnummer"]?.ToString();
                            string product = dep["Produkt"]?.ToString()?.ToLower();

                            // Die AbfahrtszeitSoll im ISO-Format verwenden
                            string isoTimeStr = dep["AbfahrtszeitSoll"]?.ToString();
                            if (string.IsNullOrEmpty(isoTimeStr))
                            {
                                Debug.WriteLine("Keine Abfahrtszeit gefunden");
                                continue;
                            }

                            // ISO-Zeit parsen
                            if (DateTime.TryParse(isoTimeStr, out DateTime depTime))
                            {
                                // Kurze Zeitanzeige (HH:MM) für die Anzeige erstellen
                                string displayTime = depTime.ToString("HH:mm");

                                // Verzögerung berechnen (falls vorhanden)
                                int delay = 0;
                                if (dep["AbfahrtszeitIst"] != null)
                                {
                                    if (DateTime.TryParse(dep["AbfahrtszeitIst"].ToString(), out DateTime actualTime))
                                    {
                                        TimeSpan delaySpan = actualTime - depTime;
                                        delay = (int)Math.Round(delaySpan.TotalMinutes);

                                        // Negative Verzögerung (zu früh) ignorieren
                                        if (delay < 0) delay = 0;
                                    }
                                }

                                // Fahrzeugtyp bestimmen
                                string typeName;
                                Color typeColor;

                                if (product == "ubahn" || line.StartsWith("U"))
                                {
                                    typeName = "U-Bahn";
                                    typeColor = Color.FromArgb(0, 102, 179); // #0066b3
                                }
                                else if (product == "tram" || (int.TryParse(line, out int num) && num < 20))
                                {
                                    typeName = "Straßenbahn";
                                    typeColor = Color.FromArgb(204, 0, 0); // #cc0000
                                }
                                else if (product == "bus" || (int.TryParse(line, out num) && num >= 20))
                                {
                                    typeName = "Bus";
                                    typeColor = Color.FromArgb(153, 51, 153); // #993399
                                }
                                else if (product == "sbahn" || line.StartsWith("S"))
                                {
                                    typeName = "S-Bahn";
                                    typeColor = Color.FromArgb(0, 102, 51); // #006633
                                }
                                else
                                {
                                    typeName = "Zug";
                                    typeColor = Color.FromArgb(0, 102, 51); // #006633
                                }

                                // Minuten bis zur Abfahrt berechnen
                                int minutes = (int)Math.Round((depTime - now).TotalMinutes);

                                // Alle Abfahrten hinzufügen
                                departureItems.Add(new DepartureInfo
                                {
                                    Line = line,
                                    Destination = destination,
                                    Time = displayTime,
                                    Delay = delay,
                                    Minutes = minutes,
                                    VehicleNumber = vehicleNumber,
                                    TypeName = typeName,
                                    TypeColor = typeColor
                                });

                                Debug.WriteLine($"Erfolgreich verarbeitet: {line} nach {destination} um {displayTime}, in {minutes} Min");
                            }
                            else
                            {
                                Debug.WriteLine($"Konnte ISO-Zeit nicht parsen: '{isoTimeStr}'");
                            }
                        }

                        // Nach Minuten sortieren
                        departureItems = departureItems.OrderBy(d => d.Minutes).ToList();

                        Debug.WriteLine($"Anzuzeigende Abfahrten: {departureItems.Count}");

                        foreach (var departure in departureItems)
                        {
                            var item = new ListViewItem(new[]
                            {
                                departure.Line,
                                departure.Time + (departure.Delay > 0 ? $" +{departure.Delay}" : ""),
                                departure.Destination,
                                departure.Minutes >= 0 ? $"in {departure.Minutes} Min" : $"vor {Math.Abs(departure.Minutes)} Min",
                                departure.VehicleNumber != null ? $"{departure.TypeName}: {departure.VehicleNumber}" : departure.TypeName
                            });

                            item.BackColor = departure.Delay > 0 ? Color.FromArgb(255, 240, 240) : Color.White;
                            item.UseItemStyleForSubItems = false;
                            item.SubItems[0].BackColor = departure.TypeColor;
                            item.SubItems[0].ForeColor = Color.White;

                            lstDepartures.Items.Add(item);
                        }

                        if (departureItems.Count == 0)
                        {
                            MessageBox.Show("Keine aktuellen Abfahrten für diese Haltestelle gefunden. Dies kann an der aktuellen Tageszeit oder an der API liegen.",
                                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        autoRefreshTimer.Start();
                    }
                    else
                    {
                        MessageBox.Show("Keine Abfahrtsdaten in der API-Antwort gefunden. Möglicherweise ist die Haltestelle nicht im Fahrplan enthalten.",
                            "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Fehler beim Abrufen der Abfahrten. Status: " + response.StatusCode, "Fehler",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Laden der Abfahrten: " + ex.Message, "Fehler",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception: " + ex.ToString());
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDepartures();
        }

        private void RefreshDepartures()
        {
            if (currentStationId != null)
            {
                LoadDepartures();
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (lstDepartures.Items.Count == 0)
            {
                MessageBox.Show("Es sind keine Abfahrten zum Drucken vorhanden.", "Hinweis",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Druckdialog erstellen
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument;
            printDocument.PrintPage += PrintDocument_PrintPage;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            // Zeige den Über-Dialog an
            using (AboutForm aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog(this);
            }
        }

        // Druck-Ereignishandler
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Schriftarten und Pinsel für den Druck
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 10);
            Brush brush = Brushes.Black;

            // Seitenränder
            int margin = 50;
            int y = margin;

            // Titel drucken
            e.Graphics.DrawString("VAG Fahrplanauskunft", titleFont, brush, margin, y);
            y += 30;

            // Haltestelle drucken
            e.Graphics.DrawString("Haltestelle: " + currentStationName, headerFont, brush, margin, y);
            y += 30;

            // Aktuelle Zeit drucken
            e.Graphics.DrawString("Stand: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), headerFont, brush, margin, y);
            y += 40;

            // Abfahrten-Tabellenkopf
            e.Graphics.DrawString("Linie", headerFont, brush, margin, y);
            e.Graphics.DrawString("Zeit", headerFont, brush, margin + 80, y);
            e.Graphics.DrawString("Ziel", headerFont, brush, margin + 150, y);
            e.Graphics.DrawString("Abfahrt", headerFont, brush, margin + 400, y);
            e.Graphics.DrawString("Typ/Wagen", headerFont, brush, margin + 500, y);
            y += 25;

            // Trennlinie
            e.Graphics.DrawLine(Pens.Black, margin, y, e.PageBounds.Width - margin, y);
            y += 10;

            // Alle Abfahrten drucken
            foreach (ListViewItem item in lstDepartures.Items)
            {
                // Zeile nur drucken, wenn sie auf die Seite passt
                if (y + 20 > e.PageBounds.Height - margin)
                {
                    break;
                }

                // Linie mit Farbmarkierung
                Rectangle lineRect = new Rectangle(margin, y, 50, 15);
                Color lineColor = item.SubItems[0].BackColor;
                e.Graphics.FillRectangle(new SolidBrush(lineColor), lineRect);
                e.Graphics.DrawString(item.SubItems[0].Text, bodyFont, Brushes.White, margin + 5, y);

                // Andere Spalten
                e.Graphics.DrawString(item.SubItems[1].Text, bodyFont, brush, margin + 80, y);
                e.Graphics.DrawString(item.SubItems[2].Text, bodyFont, brush, margin + 150, y);
                e.Graphics.DrawString(item.SubItems[3].Text, bodyFont, brush, margin + 400, y);
                e.Graphics.DrawString(item.SubItems[4].Text, bodyFont, brush, margin + 500, y);

                y += 20;
            }
        }
    }

    public class StationInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class DepartureInfo
    {
        public string Line { get; set; }
        public string Destination { get; set; }
        public string Time { get; set; }
        public int Delay { get; set; }
        public int Minutes { get; set; }
        public string VehicleNumber { get; set; }
        public string TypeName { get; set; }
        public Color TypeColor { get; set; }
    }
}