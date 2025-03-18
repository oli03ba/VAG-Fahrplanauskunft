namespace VAGFahrplan
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblClock = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabStations = new System.Windows.Forms.TabPage();
            this.lstStations = new System.Windows.Forms.ListView();
            this.tabDepartures = new System.Windows.Forms.TabPage();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblStationName = new System.Windows.Forms.Label();
            this.lstDepartures = new System.Windows.Forms.ListView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headerPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabStations.SuspendLayout();
            this.tabDepartures.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(41)))), ((int)(((byte)(28)))));
            this.headerPanel.Controls.Add(this.lblClock);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1176, 92);
            this.headerPanel.TabIndex = 0;
            // 
            // lblClock
            // 
            this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.ForeColor = System.Drawing.Color.White;
            this.lblClock.Location = new System.Drawing.Point(975, 31);
            this.lblClock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(112, 32);
            this.lblClock.TabIndex = 1;
            this.lblClock.Text = "00:00:00";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 23);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(355, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "VAG Fahrplanauskunft";
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.White;
            this.searchPanel.Controls.Add(this.btnSearch);
            this.searchPanel.Controls.Add(this.txtSearch);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(0, 92);
            this.searchPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Padding = new System.Windows.Forms.Padding(30, 23, 30, 23);
            this.searchPanel.Size = new System.Drawing.Size(1176, 108);
            this.searchPanel.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(41)))), ((int)(((byte)(28)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1004, 23);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(140, 62);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Suchen";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(30, 29);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(962, 39);
            this.txtSearch.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabStations);
            this.tabControl.Controls.Add(this.tabDepartures);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 200);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1176, 663);
            this.tabControl.TabIndex = 2;
            // 
            // tabStations
            // 
            this.tabStations.Controls.Add(this.lstStations);
            this.tabStations.Location = new System.Drawing.Point(4, 37);
            this.tabStations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabStations.Name = "tabStations";
            this.tabStations.Padding = new System.Windows.Forms.Padding(22, 23, 22, 23);
            this.tabStations.Size = new System.Drawing.Size(1168, 622);
            this.tabStations.TabIndex = 0;
            this.tabStations.Text = "Haltestellen";
            this.tabStations.UseVisualStyleBackColor = true;
            // 
            // lstStations
            // 
            this.lstStations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstStations.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstStations.HideSelection = false;
            this.lstStations.Location = new System.Drawing.Point(22, 23);
            this.lstStations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstStations.Name = "lstStations";
            this.lstStations.Size = new System.Drawing.Size(1124, 576);
            this.lstStations.TabIndex = 0;
            this.lstStations.UseCompatibleStateImageBehavior = false;
            // 
            // tabDepartures
            // 
            this.tabDepartures.Controls.Add(this.btnRefresh);
            this.tabDepartures.Controls.Add(this.lblStationName);
            this.tabDepartures.Controls.Add(this.lstDepartures);
            this.tabDepartures.Controls.Add(this.btnPrint);
            this.tabDepartures.Location = new System.Drawing.Point(4, 37);
            this.tabDepartures.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabDepartures.Name = "tabDepartures";
            this.tabDepartures.Padding = new System.Windows.Forms.Padding(22, 23, 22, 23);
            this.tabDepartures.Size = new System.Drawing.Size(1168, 622);
            this.tabDepartures.TabIndex = 1;
            this.tabDepartures.Text = "Abfahrten";
            this.tabDepartures.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(993, 18);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(148, 49);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Aktualisieren";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // lblStationName
            // 
            this.lblStationName.AutoSize = true;
            this.lblStationName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStationName.Location = new System.Drawing.Point(22, 23);
            this.lblStationName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStationName.Name = "lblStationName";
            this.lblStationName.Size = new System.Drawing.Size(131, 32);
            this.lblStationName.TabIndex = 1;
            this.lblStationName.Text = "Abfahrten:";
            // 
            // lstDepartures
            // 
            this.lstDepartures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDepartures.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDepartures.HideSelection = false;
            this.lstDepartures.Location = new System.Drawing.Point(22, 77);
            this.lstDepartures.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstDepartures.Name = "lstDepartures";
            this.lstDepartures.Size = new System.Drawing.Size(1117, 515);
            this.lstDepartures.TabIndex = 0;
            this.lstDepartures.UseCompatibleStateImageBehavior = false;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(836, 18);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(148, 49);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Drucken";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 200);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1176, 35);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(64, 29);
            this.helpMenuItem.Text = "Hilfe";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(164, 34);
            this.aboutMenuItem.Text = "Über...";
            this.aboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 863);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.headerPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VAG Fahrplanauskunft";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabStations.ResumeLayout(false);
            this.tabDepartures.ResumeLayout(false);
            this.tabDepartures.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabStations;
        private System.Windows.Forms.ListView lstStations;
        private System.Windows.Forms.TabPage tabDepartures;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblStationName;
        private System.Windows.Forms.ListView lstDepartures;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
    }
}