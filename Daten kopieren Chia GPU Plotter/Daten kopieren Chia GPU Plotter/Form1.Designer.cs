namespace Daten_kopieren_Chia_GPU_Plotter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Kopieren = new System.Windows.Forms.Button();
            this.KopierenStarten = new System.Windows.Forms.Button();
            this.quellPfad = new System.Windows.Forms.ListBox();
            this.QuellordnerWählen = new System.Windows.Forms.Button();
            this.zielPfadListe = new System.Windows.Forms.ListBox();
            this.ZielverzeichnissEinfügen = new System.Windows.Forms.Button();
            this.ZielverzeichnissLöschen = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.TextBox();
            this.LogLöschen = new System.Windows.Forms.Button();
            this.KopierenAnhalten = new System.Windows.Forms.Button();
            this.ChiaCudaPlotterWählen = new System.Windows.Forms.Button();
            this.FarmerKey = new System.Windows.Forms.TextBox();
            this.PoolKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AnzahlPlots = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.StartPlot = new System.Windows.Forms.Button();
            this.PlotterGefunden = new System.Windows.Forms.CheckBox();
            this.StopPlot = new System.Windows.Forms.Button();
            this.PlotCheck = new System.Windows.Forms.Button();
            this.SettingsSpeichern = new System.Windows.Forms.Button();
            this.CudaPlotterPfad = new System.Windows.Forms.TextBox();
            this.PlotsPrüfen = new System.Windows.Forms.CheckBox();
            this.Werbelink = new System.Windows.Forms.LinkLabel();
            this.WerbungYouTube = new System.Windows.Forms.LinkLabel();
            this.WerbungSpende = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.AnzahlPlots)).BeginInit();
            this.SuspendLayout();
            // 
            // Kopieren
            // 
            this.Kopieren.Location = new System.Drawing.Point(559, 714);
            this.Kopieren.Name = "Kopieren";
            this.Kopieren.Size = new System.Drawing.Size(155, 34);
            this.Kopieren.TabIndex = 0;
            this.Kopieren.Text = "Kopieren";
            this.Kopieren.UseVisualStyleBackColor = true;
            this.Kopieren.Visible = false;
            this.Kopieren.Click += new System.EventHandler(this.Kopieren_Click);
            // 
            // KopierenStarten
            // 
            this.KopierenStarten.Location = new System.Drawing.Point(35, 714);
            this.KopierenStarten.Name = "KopierenStarten";
            this.KopierenStarten.Size = new System.Drawing.Size(236, 34);
            this.KopierenStarten.TabIndex = 1;
            this.KopierenStarten.Text = "Kopieren starten";
            this.KopierenStarten.UseVisualStyleBackColor = true;
            this.KopierenStarten.Click += new System.EventHandler(this.KopierenStarten_Click);
            // 
            // quellPfad
            // 
            this.quellPfad.FormattingEnabled = true;
            this.quellPfad.ItemHeight = 25;
            this.quellPfad.Location = new System.Drawing.Point(35, 50);
            this.quellPfad.Name = "quellPfad";
            this.quellPfad.Size = new System.Drawing.Size(679, 29);
            this.quellPfad.TabIndex = 2;
            // 
            // QuellordnerWählen
            // 
            this.QuellordnerWählen.Location = new System.Drawing.Point(516, 85);
            this.QuellordnerWählen.Name = "QuellordnerWählen";
            this.QuellordnerWählen.Size = new System.Drawing.Size(198, 34);
            this.QuellordnerWählen.TabIndex = 3;
            this.QuellordnerWählen.Text = "Quellordner wählen";
            this.QuellordnerWählen.UseVisualStyleBackColor = true;
            this.QuellordnerWählen.Click += new System.EventHandler(this.QuellordnerWählen_Click);
            // 
            // zielPfadListe
            // 
            this.zielPfadListe.FormattingEnabled = true;
            this.zielPfadListe.ItemHeight = 25;
            this.zielPfadListe.Location = new System.Drawing.Point(35, 164);
            this.zielPfadListe.Name = "zielPfadListe";
            this.zielPfadListe.Size = new System.Drawing.Size(518, 504);
            this.zielPfadListe.TabIndex = 4;
            // 
            // ZielverzeichnissEinfügen
            // 
            this.ZielverzeichnissEinfügen.Location = new System.Drawing.Point(35, 674);
            this.ZielverzeichnissEinfügen.Name = "ZielverzeichnissEinfügen";
            this.ZielverzeichnissEinfügen.Size = new System.Drawing.Size(236, 34);
            this.ZielverzeichnissEinfügen.TabIndex = 5;
            this.ZielverzeichnissEinfügen.Text = "Zielverzeichniss einfügen";
            this.ZielverzeichnissEinfügen.UseVisualStyleBackColor = true;
            this.ZielverzeichnissEinfügen.Click += new System.EventHandler(this.ZielverzeichnissEinfügen_Click);
            // 
            // ZielverzeichnissLöschen
            // 
            this.ZielverzeichnissLöschen.Location = new System.Drawing.Point(296, 674);
            this.ZielverzeichnissLöschen.Name = "ZielverzeichnissLöschen";
            this.ZielverzeichnissLöschen.Size = new System.Drawing.Size(257, 34);
            this.ZielverzeichnissLöschen.TabIndex = 6;
            this.ZielverzeichnissLöschen.Text = "Zielverzeichniss löschen";
            this.ZielverzeichnissLöschen.UseVisualStyleBackColor = true;
            this.ZielverzeichnissLöschen.Click += new System.EventHandler(this.ZielverzeichnissLöschen_Click);
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(559, 164);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.log.Size = new System.Drawing.Size(1820, 504);
            this.log.TabIndex = 7;
            // 
            // LogLöschen
            // 
            this.LogLöschen.Location = new System.Drawing.Point(559, 674);
            this.LogLöschen.Name = "LogLöschen";
            this.LogLöschen.Size = new System.Drawing.Size(155, 34);
            this.LogLöschen.TabIndex = 8;
            this.LogLöschen.Text = "Log löschen";
            this.LogLöschen.UseVisualStyleBackColor = true;
            this.LogLöschen.Click += new System.EventHandler(this.LogLöschen_Click);
            // 
            // KopierenAnhalten
            // 
            this.KopierenAnhalten.Location = new System.Drawing.Point(296, 714);
            this.KopierenAnhalten.Name = "KopierenAnhalten";
            this.KopierenAnhalten.Size = new System.Drawing.Size(257, 34);
            this.KopierenAnhalten.TabIndex = 9;
            this.KopierenAnhalten.Text = "Kopieren anhalten";
            this.KopierenAnhalten.UseVisualStyleBackColor = true;
            this.KopierenAnhalten.Click += new System.EventHandler(this.KopierenAnhalten_Click);
            // 
            // ChiaCudaPlotterWählen
            // 
            this.ChiaCudaPlotterWählen.Location = new System.Drawing.Point(906, 3);
            this.ChiaCudaPlotterWählen.Name = "ChiaCudaPlotterWählen";
            this.ChiaCudaPlotterWählen.Size = new System.Drawing.Size(230, 41);
            this.ChiaCudaPlotterWählen.TabIndex = 10;
            this.ChiaCudaPlotterWählen.Text = "Chia Cuda Plotter wählen";
            this.ChiaCudaPlotterWählen.UseVisualStyleBackColor = true;
            this.ChiaCudaPlotterWählen.Click += new System.EventHandler(this.ChiaCudaPlotterWählen_Click);
            // 
            // FarmerKey
            // 
            this.FarmerKey.Location = new System.Drawing.Point(906, 85);
            this.FarmerKey.Name = "FarmerKey";
            this.FarmerKey.Size = new System.Drawing.Size(945, 31);
            this.FarmerKey.TabIndex = 12;
            this.FarmerKey.UseSystemPasswordChar = true;
            // 
            // PoolKey
            // 
            this.PoolKey.Location = new System.Drawing.Point(906, 122);
            this.PoolKey.Name = "PoolKey";
            this.PoolKey.Size = new System.Drawing.Size(945, 31);
            this.PoolKey.TabIndex = 13;
            this.PoolKey.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(749, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Cuda Plotter Pfad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(749, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Farmer Key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(749, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Pool Key";
            // 
            // AnzahlPlots
            // 
            this.AnzahlPlots.Location = new System.Drawing.Point(1972, 45);
            this.AnzahlPlots.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.AnzahlPlots.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AnzahlPlots.Name = "AnzahlPlots";
            this.AnzahlPlots.Size = new System.Drawing.Size(180, 31);
            this.AnzahlPlots.TabIndex = 17;
            this.AnzahlPlots.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1857, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "Anzahl Plots";
            // 
            // StartPlot
            // 
            this.StartPlot.Location = new System.Drawing.Point(1857, 82);
            this.StartPlot.Name = "StartPlot";
            this.StartPlot.Size = new System.Drawing.Size(295, 68);
            this.StartPlot.TabIndex = 19;
            this.StartPlot.Text = "Start Plot";
            this.StartPlot.UseVisualStyleBackColor = true;
            this.StartPlot.Click += new System.EventHandler(this.StartPlot_Click);
            // 
            // PlotterGefunden
            // 
            this.PlotterGefunden.AllowDrop = true;
            this.PlotterGefunden.AutoCheck = false;
            this.PlotterGefunden.AutoSize = true;
            this.PlotterGefunden.Location = new System.Drawing.Point(1162, 10);
            this.PlotterGefunden.Name = "PlotterGefunden";
            this.PlotterGefunden.Size = new System.Drawing.Size(171, 29);
            this.PlotterGefunden.TabIndex = 20;
            this.PlotterGefunden.TabStop = false;
            this.PlotterGefunden.Text = "Plotter gefunden";
            this.PlotterGefunden.UseVisualStyleBackColor = true;
            // 
            // StopPlot
            // 
            this.StopPlot.Location = new System.Drawing.Point(1857, 82);
            this.StopPlot.Name = "StopPlot";
            this.StopPlot.Size = new System.Drawing.Size(295, 68);
            this.StopPlot.TabIndex = 21;
            this.StopPlot.Text = "Stop Plot";
            this.StopPlot.UseVisualStyleBackColor = true;
            this.StopPlot.Click += new System.EventHandler(this.StopPlot_Click);
            // 
            // PlotCheck
            // 
            this.PlotCheck.Location = new System.Drawing.Point(2158, 82);
            this.PlotCheck.Name = "PlotCheck";
            this.PlotCheck.Size = new System.Drawing.Size(221, 68);
            this.PlotCheck.TabIndex = 22;
            this.PlotCheck.Text = "Plot Check";
            this.PlotCheck.UseVisualStyleBackColor = true;
            this.PlotCheck.Click += new System.EventHandler(this.PlotCheck_Click);
            // 
            // SettingsSpeichern
            // 
            this.SettingsSpeichern.Location = new System.Drawing.Point(2158, 3);
            this.SettingsSpeichern.Name = "SettingsSpeichern";
            this.SettingsSpeichern.Size = new System.Drawing.Size(221, 34);
            this.SettingsSpeichern.TabIndex = 23;
            this.SettingsSpeichern.Text = "Settings speichern";
            this.SettingsSpeichern.UseVisualStyleBackColor = true;
            this.SettingsSpeichern.Click += new System.EventHandler(this.SettingsSpeichern_Click);
            // 
            // CudaPlotterPfad
            // 
            this.CudaPlotterPfad.Location = new System.Drawing.Point(906, 47);
            this.CudaPlotterPfad.Name = "CudaPlotterPfad";
            this.CudaPlotterPfad.Size = new System.Drawing.Size(945, 31);
            this.CudaPlotterPfad.TabIndex = 24;
            // 
            // PlotsPrüfen
            // 
            this.PlotsPrüfen.AutoSize = true;
            this.PlotsPrüfen.Location = new System.Drawing.Point(2158, 43);
            this.PlotsPrüfen.Name = "PlotsPrüfen";
            this.PlotsPrüfen.Size = new System.Drawing.Size(134, 29);
            this.PlotsPrüfen.TabIndex = 25;
            this.PlotsPrüfen.Text = "Plots prüfen";
            this.PlotsPrüfen.UseVisualStyleBackColor = true;
            // 
            // Werbelink
            // 
            this.Werbelink.AutoSize = true;
            this.Werbelink.Location = new System.Drawing.Point(225, 14);
            this.Werbelink.Name = "Werbelink";
            this.Werbelink.Size = new System.Drawing.Size(217, 25);
            this.Werbelink.TabIndex = 26;
            this.Werbelink.TabStop = true;
            this.Werbelink.Text = "Werbung mech2you.shop";
            this.Werbelink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Werbelink_LinkClicked);
            // 
            // WerbungYouTube
            // 
            this.WerbungYouTube.AutoSize = true;
            this.WerbungYouTube.Location = new System.Drawing.Point(448, 14);
            this.WerbungYouTube.Name = "WerbungYouTube";
            this.WerbungYouTube.Size = new System.Drawing.Size(158, 25);
            this.WerbungYouTube.TabIndex = 27;
            this.WerbungYouTube.TabStop = true;
            this.WerbungYouTube.Text = "Werbung YouTube";
            this.WerbungYouTube.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WerbungYouTube_LinkClicked);
            // 
            // WerbungSpende
            // 
            this.WerbungSpende.AutoSize = true;
            this.WerbungSpende.Location = new System.Drawing.Point(35, 14);
            this.WerbungSpende.Name = "WerbungSpende";
            this.WerbungSpende.Size = new System.Drawing.Size(184, 25);
            this.WerbungSpende.TabIndex = 28;
            this.WerbungSpende.TabStop = true;
            this.WerbungSpende.Text = "Unterstüzte den Kanal";
            this.WerbungSpende.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WerbungSpende_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2384, 765);
            this.Controls.Add(this.WerbungSpende);
            this.Controls.Add(this.WerbungYouTube);
            this.Controls.Add(this.Werbelink);
            this.Controls.Add(this.PlotsPrüfen);
            this.Controls.Add(this.CudaPlotterPfad);
            this.Controls.Add(this.SettingsSpeichern);
            this.Controls.Add(this.PlotCheck);
            this.Controls.Add(this.StopPlot);
            this.Controls.Add(this.PlotterGefunden);
            this.Controls.Add(this.StartPlot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AnzahlPlots);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PoolKey);
            this.Controls.Add(this.FarmerKey);
            this.Controls.Add(this.ChiaCudaPlotterWählen);
            this.Controls.Add(this.KopierenAnhalten);
            this.Controls.Add(this.LogLöschen);
            this.Controls.Add(this.log);
            this.Controls.Add(this.ZielverzeichnissLöschen);
            this.Controls.Add(this.ZielverzeichnissEinfügen);
            this.Controls.Add(this.zielPfadListe);
            this.Controls.Add(this.QuellordnerWählen);
            this.Controls.Add(this.quellPfad);
            this.Controls.Add(this.KopierenStarten);
            this.Controls.Add(this.Kopieren);
            this.Name = "Form1";
            this.Text = "mech2youDV v1.0.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AnzahlPlots)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Kopieren;
        private Button KopierenStarten;
        private ListBox quellPfad;
        private Button QuellordnerWählen;
        private ListBox zielPfadListe;
        private Button ZielverzeichnissEinfügen;
        private Button ZielverzeichnissLöschen;
        private TextBox log;
        private Button LogLöschen;
        private Button KopierenAnhalten;
        private Button ChiaCudaPlotterWählen;
        private TextBox FarmerKey;
        private TextBox PoolKey;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown AnzahlPlots;
        private Label label4;
        private Button StartPlot;
        private CheckBox PlotterGefunden;
        private Button StopPlot;
        private Button PlotCheck;
        private Button SettingsSpeichern;
        private TextBox CudaPlotterPfad;
        private CheckBox PlotsPrüfen;
        private LinkLabel Werbelink;
        private LinkLabel WerbungYouTube;
        private LinkLabel WerbungSpende;
    }
}