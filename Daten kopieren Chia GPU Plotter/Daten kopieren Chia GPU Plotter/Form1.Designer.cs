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
            Kopieren = new Button();
            KopierenStarten = new Button();
            quellPfad = new ListBox();
            QuellordnerWählen = new Button();
            zielPfadListe = new ListBox();
            ZielverzeichnissEinfügen = new Button();
            ZielverzeichnissLöschen = new Button();
            log = new TextBox();
            LogLöschen = new Button();
            KopierenAnhalten = new Button();
            ChiaCudaPlotterWählen = new Button();
            FarmerKey = new TextBox();
            PoolKey = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            AnzahlPlots = new NumericUpDown();
            label4 = new Label();
            StartPlot = new Button();
            PlotterGefunden = new CheckBox();
            StopPlot = new Button();
            PlotCheck = new Button();
            SettingsSpeichern = new Button();
            CudaPlotterPfad = new TextBox();
            PlotsPrüfen = new CheckBox();
            Werbelink = new LinkLabel();
            WerbungYouTube = new LinkLabel();
            WerbungSpende = new LinkLabel();
            PlotterAuswahl = new ComboBox();
            KLevelAuswahl = new ComboBox();
            KompressionAuswahl = new ComboBox();
            GPUGemeinsameSpeicherGUI = new NumericUpDown();
            InfoGUI = new RichTextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            MadMaxRAMFull = new RadioButton();
            MadMaxRAMHalb = new RadioButton();
            MadMaxRAMViertel = new RadioButton();
            groupBox1 = new GroupBox();
            MadMaxTmpOrdnerTB = new TextBox();
            MadMaxTmpOrdnerBT = new Button();
            ((System.ComponentModel.ISupportInitialize)AnzahlPlots).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GPUGemeinsameSpeicherGUI).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // Kopieren
            // 
            Kopieren.Location = new Point(559, 714);
            Kopieren.Name = "Kopieren";
            Kopieren.Size = new Size(155, 34);
            Kopieren.TabIndex = 0;
            Kopieren.Text = "Kopieren";
            Kopieren.UseVisualStyleBackColor = true;
            Kopieren.Visible = false;
            Kopieren.Click += Kopieren_Click;
            // 
            // KopierenStarten
            // 
            KopierenStarten.Location = new Point(35, 714);
            KopierenStarten.Name = "KopierenStarten";
            KopierenStarten.Size = new Size(236, 34);
            KopierenStarten.TabIndex = 1;
            KopierenStarten.Text = "Kopieren starten";
            KopierenStarten.UseVisualStyleBackColor = true;
            KopierenStarten.Click += KopierenStarten_Click;
            // 
            // quellPfad
            // 
            quellPfad.FormattingEnabled = true;
            quellPfad.ItemHeight = 25;
            quellPfad.Location = new Point(35, 50);
            quellPfad.Name = "quellPfad";
            quellPfad.Size = new Size(679, 29);
            quellPfad.TabIndex = 2;
            // 
            // QuellordnerWählen
            // 
            QuellordnerWählen.Location = new Point(516, 85);
            QuellordnerWählen.Name = "QuellordnerWählen";
            QuellordnerWählen.Size = new Size(198, 34);
            QuellordnerWählen.TabIndex = 3;
            QuellordnerWählen.Text = "Quellordner wählen";
            QuellordnerWählen.UseVisualStyleBackColor = true;
            QuellordnerWählen.Click += QuellordnerWählen_Click;
            // 
            // zielPfadListe
            // 
            zielPfadListe.FormattingEnabled = true;
            zielPfadListe.ItemHeight = 25;
            zielPfadListe.Location = new Point(35, 164);
            zielPfadListe.Name = "zielPfadListe";
            zielPfadListe.Size = new Size(431, 504);
            zielPfadListe.TabIndex = 4;
            // 
            // ZielverzeichnissEinfügen
            // 
            ZielverzeichnissEinfügen.Location = new Point(35, 674);
            ZielverzeichnissEinfügen.Name = "ZielverzeichnissEinfügen";
            ZielverzeichnissEinfügen.Size = new Size(236, 34);
            ZielverzeichnissEinfügen.TabIndex = 5;
            ZielverzeichnissEinfügen.Text = "Zielverzeichniss einfügen";
            ZielverzeichnissEinfügen.UseVisualStyleBackColor = true;
            ZielverzeichnissEinfügen.Click += ZielverzeichnissEinfügen_Click;
            // 
            // ZielverzeichnissLöschen
            // 
            ZielverzeichnissLöschen.Location = new Point(296, 674);
            ZielverzeichnissLöschen.Name = "ZielverzeichnissLöschen";
            ZielverzeichnissLöschen.Size = new Size(257, 34);
            ZielverzeichnissLöschen.TabIndex = 6;
            ZielverzeichnissLöschen.Text = "Zielverzeichniss löschen";
            ZielverzeichnissLöschen.UseVisualStyleBackColor = true;
            ZielverzeichnissLöschen.Click += ZielverzeichnissLöschen_Click;
            // 
            // log
            // 
            log.Location = new Point(598, 248);
            log.Multiline = true;
            log.Name = "log";
            log.ScrollBars = ScrollBars.Both;
            log.Size = new Size(1781, 421);
            log.TabIndex = 7;
            // 
            // LogLöschen
            // 
            LogLöschen.Location = new Point(559, 674);
            LogLöschen.Name = "LogLöschen";
            LogLöschen.Size = new Size(155, 34);
            LogLöschen.TabIndex = 8;
            LogLöschen.Text = "Log löschen";
            LogLöschen.UseVisualStyleBackColor = true;
            LogLöschen.Click += LogLöschen_Click;
            // 
            // KopierenAnhalten
            // 
            KopierenAnhalten.Location = new Point(296, 714);
            KopierenAnhalten.Name = "KopierenAnhalten";
            KopierenAnhalten.Size = new Size(257, 34);
            KopierenAnhalten.TabIndex = 9;
            KopierenAnhalten.Text = "Kopieren anhalten";
            KopierenAnhalten.UseVisualStyleBackColor = true;
            KopierenAnhalten.Click += KopierenAnhalten_Click;
            // 
            // ChiaCudaPlotterWählen
            // 
            ChiaCudaPlotterWählen.Location = new Point(906, 3);
            ChiaCudaPlotterWählen.Name = "ChiaCudaPlotterWählen";
            ChiaCudaPlotterWählen.Size = new Size(230, 41);
            ChiaCudaPlotterWählen.TabIndex = 10;
            ChiaCudaPlotterWählen.Text = "Chia Cuda Plotter wählen";
            ChiaCudaPlotterWählen.UseVisualStyleBackColor = true;
            ChiaCudaPlotterWählen.Click += ChiaCudaPlotterWählen_Click;
            // 
            // FarmerKey
            // 
            FarmerKey.Location = new Point(906, 85);
            FarmerKey.Name = "FarmerKey";
            FarmerKey.Size = new Size(945, 31);
            FarmerKey.TabIndex = 12;
            FarmerKey.UseSystemPasswordChar = true;
            // 
            // PoolKey
            // 
            PoolKey.Location = new Point(906, 122);
            PoolKey.Name = "PoolKey";
            PoolKey.Size = new Size(945, 31);
            PoolKey.TabIndex = 13;
            PoolKey.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(749, 54);
            label1.Name = "label1";
            label1.Size = new Size(151, 25);
            label1.TabIndex = 14;
            label1.Text = "Cuda Plotter Pfad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(749, 90);
            label2.Name = "label2";
            label2.Size = new Size(99, 25);
            label2.TabIndex = 15;
            label2.Text = "Farmer Key";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(749, 125);
            label3.Name = "label3";
            label3.Size = new Size(80, 25);
            label3.TabIndex = 16;
            label3.Text = "Pool Key";
            // 
            // AnzahlPlots
            // 
            AnzahlPlots.Location = new Point(1322, 198);
            AnzahlPlots.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            AnzahlPlots.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            AnzahlPlots.Name = "AnzahlPlots";
            AnzahlPlots.Size = new Size(124, 31);
            AnzahlPlots.TabIndex = 17;
            AnzahlPlots.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1322, 164);
            label4.Name = "label4";
            label4.Size = new Size(109, 25);
            label4.TabIndex = 18;
            label4.Text = "Anzahl Plots";
            // 
            // StartPlot
            // 
            StartPlot.Location = new Point(1857, 82);
            StartPlot.Name = "StartPlot";
            StartPlot.Size = new Size(295, 68);
            StartPlot.TabIndex = 19;
            StartPlot.Text = "Start Plot";
            StartPlot.UseVisualStyleBackColor = true;
            StartPlot.Click += StartPlot_Click;
            // 
            // PlotterGefunden
            // 
            PlotterGefunden.AllowDrop = true;
            PlotterGefunden.AutoCheck = false;
            PlotterGefunden.AutoSize = true;
            PlotterGefunden.Location = new Point(1162, 10);
            PlotterGefunden.Name = "PlotterGefunden";
            PlotterGefunden.Size = new Size(171, 29);
            PlotterGefunden.TabIndex = 20;
            PlotterGefunden.TabStop = false;
            PlotterGefunden.Text = "Plotter gefunden";
            PlotterGefunden.UseVisualStyleBackColor = true;
            // 
            // StopPlot
            // 
            StopPlot.Location = new Point(1857, 82);
            StopPlot.Name = "StopPlot";
            StopPlot.Size = new Size(295, 68);
            StopPlot.TabIndex = 21;
            StopPlot.Text = "Stop Plot";
            StopPlot.UseVisualStyleBackColor = true;
            StopPlot.Click += StopPlot_Click;
            // 
            // PlotCheck
            // 
            PlotCheck.Location = new Point(2158, 82);
            PlotCheck.Name = "PlotCheck";
            PlotCheck.Size = new Size(221, 68);
            PlotCheck.TabIndex = 22;
            PlotCheck.Text = "Plot Check";
            PlotCheck.UseVisualStyleBackColor = true;
            PlotCheck.Click += PlotCheck_Click;
            // 
            // SettingsSpeichern
            // 
            SettingsSpeichern.Location = new Point(2158, 3);
            SettingsSpeichern.Name = "SettingsSpeichern";
            SettingsSpeichern.Size = new Size(221, 34);
            SettingsSpeichern.TabIndex = 23;
            SettingsSpeichern.Text = "Settings speichern";
            SettingsSpeichern.UseVisualStyleBackColor = true;
            SettingsSpeichern.Click += SettingsSpeichern_Click;
            // 
            // CudaPlotterPfad
            // 
            CudaPlotterPfad.Location = new Point(906, 47);
            CudaPlotterPfad.Name = "CudaPlotterPfad";
            CudaPlotterPfad.Size = new Size(945, 31);
            CudaPlotterPfad.TabIndex = 24;
            // 
            // PlotsPrüfen
            // 
            PlotsPrüfen.AutoSize = true;
            PlotsPrüfen.Location = new Point(2158, 47);
            PlotsPrüfen.Name = "PlotsPrüfen";
            PlotsPrüfen.Size = new Size(134, 29);
            PlotsPrüfen.TabIndex = 25;
            PlotsPrüfen.Text = "Plots prüfen";
            PlotsPrüfen.UseVisualStyleBackColor = true;
            // 
            // Werbelink
            // 
            Werbelink.AutoSize = true;
            Werbelink.Location = new Point(225, 14);
            Werbelink.Name = "Werbelink";
            Werbelink.Size = new Size(217, 25);
            Werbelink.TabIndex = 26;
            Werbelink.TabStop = true;
            Werbelink.Text = "Werbung mech2you.shop";
            Werbelink.LinkClicked += Werbelink_LinkClicked;
            // 
            // WerbungYouTube
            // 
            WerbungYouTube.AutoSize = true;
            WerbungYouTube.Location = new Point(448, 14);
            WerbungYouTube.Name = "WerbungYouTube";
            WerbungYouTube.Size = new Size(158, 25);
            WerbungYouTube.TabIndex = 27;
            WerbungYouTube.TabStop = true;
            WerbungYouTube.Text = "Werbung YouTube";
            WerbungYouTube.LinkClicked += WerbungYouTube_LinkClicked;
            // 
            // WerbungSpende
            // 
            WerbungSpende.AutoSize = true;
            WerbungSpende.Location = new Point(35, 14);
            WerbungSpende.Name = "WerbungSpende";
            WerbungSpende.Size = new Size(184, 25);
            WerbungSpende.TabIndex = 28;
            WerbungSpende.TabStop = true;
            WerbungSpende.Text = "Unterstüzte den Kanal";
            WerbungSpende.LinkClicked += WerbungSpende_LinkClicked;
            // 
            // PlotterAuswahl
            // 
            PlotterAuswahl.FormattingEnabled = true;
            PlotterAuswahl.Items.AddRange(new object[] { "MadMax GPU Plotter", "Chia GPU Plotter" });
            PlotterAuswahl.Location = new Point(749, 196);
            PlotterAuswahl.Name = "PlotterAuswahl";
            PlotterAuswahl.Size = new Size(219, 33);
            PlotterAuswahl.TabIndex = 29;
            PlotterAuswahl.Text = "wähle den Plotter";
            // 
            // KLevelAuswahl
            // 
            KLevelAuswahl.AutoCompleteCustomSource.AddRange(new string[] { "32", "33", "34" });
            KLevelAuswahl.FormattingEnabled = true;
            KLevelAuswahl.Items.AddRange(new object[] { "32", "33", "34", "35", "36", "37", "38" });
            KLevelAuswahl.Location = new Point(974, 196);
            KLevelAuswahl.Name = "KLevelAuswahl";
            KLevelAuswahl.Size = new Size(96, 33);
            KLevelAuswahl.TabIndex = 30;
            KLevelAuswahl.Text = "K Level";
            // 
            // KompressionAuswahl
            // 
            KompressionAuswahl.FormattingEnabled = true;
            KompressionAuswahl.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            KompressionAuswahl.Location = new Point(1076, 196);
            KompressionAuswahl.Name = "KompressionAuswahl";
            KompressionAuswahl.Size = new Size(141, 33);
            KompressionAuswahl.TabIndex = 31;
            KompressionAuswahl.Text = "Kompression";
            // 
            // GPUGemeinsameSpeicherGUI
            // 
            GPUGemeinsameSpeicherGUI.Location = new Point(1223, 197);
            GPUGemeinsameSpeicherGUI.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            GPUGemeinsameSpeicherGUI.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            GPUGemeinsameSpeicherGUI.Name = "GPUGemeinsameSpeicherGUI";
            GPUGemeinsameSpeicherGUI.Size = new Size(84, 31);
            GPUGemeinsameSpeicherGUI.TabIndex = 32;
            GPUGemeinsameSpeicherGUI.Value = new decimal(new int[] { 215, 0, 0, 0 });
            // 
            // InfoGUI
            // 
            InfoGUI.Location = new Point(720, 674);
            InfoGUI.Name = "InfoGUI";
            InfoGUI.Size = new Size(180, 74);
            InfoGUI.TabIndex = 33;
            InfoGUI.Text = "18TB c8 235";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(749, 164);
            label5.Name = "label5";
            label5.Size = new Size(64, 25);
            label5.TabIndex = 34;
            label5.Text = "Plotter";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(974, 164);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 35;
            label6.Text = "K Level";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1076, 164);
            label7.Name = "label7";
            label7.Size = new Size(116, 25);
            label7.TabIndex = 36;
            label7.Text = "Kompression";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1220, 164);
            label8.Name = "label8";
            label8.Size = new Size(102, 25);
            label8.TabIndex = 37;
            label8.Text = "SMem GPU";
            // 
            // MadMaxRAMFull
            // 
            MadMaxRAMFull.AutoSize = true;
            MadMaxRAMFull.Location = new Point(5, 28);
            MadMaxRAMFull.Margin = new Padding(2, 2, 2, 2);
            MadMaxRAMFull.Name = "MadMaxRAMFull";
            MadMaxRAMFull.Size = new Size(91, 29);
            MadMaxRAMFull.TabIndex = 38;
            MadMaxRAMFull.Text = "Full GB";
            MadMaxRAMFull.UseVisualStyleBackColor = true;
            // 
            // MadMaxRAMHalb
            // 
            MadMaxRAMHalb.AutoSize = true;
            MadMaxRAMHalb.Location = new Point(91, 28);
            MadMaxRAMHalb.Margin = new Padding(2, 2, 2, 2);
            MadMaxRAMHalb.Name = "MadMaxRAMHalb";
            MadMaxRAMHalb.Size = new Size(91, 29);
            MadMaxRAMHalb.TabIndex = 39;
            MadMaxRAMHalb.Text = "1/2 GB";
            MadMaxRAMHalb.UseVisualStyleBackColor = true;
            // 
            // MadMaxRAMViertel
            // 
            MadMaxRAMViertel.AutoSize = true;
            MadMaxRAMViertel.Location = new Point(177, 28);
            MadMaxRAMViertel.Margin = new Padding(2, 2, 2, 2);
            MadMaxRAMViertel.Name = "MadMaxRAMViertel";
            MadMaxRAMViertel.Size = new Size(91, 29);
            MadMaxRAMViertel.TabIndex = 40;
            MadMaxRAMViertel.Text = "1/4 GB";
            MadMaxRAMViertel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(MadMaxRAMViertel);
            groupBox1.Controls.Add(MadMaxRAMHalb);
            groupBox1.Controls.Add(MadMaxRAMFull);
            groupBox1.Location = new Point(1452, 157);
            groupBox1.Margin = new Padding(2, 2, 2, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 2, 2, 2);
            groupBox1.Size = new Size(259, 72);
            groupBox1.TabIndex = 41;
            groupBox1.TabStop = false;
            groupBox1.Text = "MadMax RAM verfügbar";
            // 
            // MadMaxTmpOrdnerTB
            // 
            MadMaxTmpOrdnerTB.Location = new Point(1718, 212);
            MadMaxTmpOrdnerTB.Name = "MadMaxTmpOrdnerTB";
            MadMaxTmpOrdnerTB.Size = new Size(662, 31);
            MadMaxTmpOrdnerTB.TabIndex = 41;
            // 
            // MadMaxTmpOrdnerBT
            // 
            MadMaxTmpOrdnerBT.Location = new Point(1718, 164);
            MadMaxTmpOrdnerBT.Name = "MadMaxTmpOrdnerBT";
            MadMaxTmpOrdnerBT.Size = new Size(230, 41);
            MadMaxTmpOrdnerBT.TabIndex = 42;
            MadMaxTmpOrdnerBT.Text = "MadMax Tmp Ordner";
            MadMaxTmpOrdnerBT.UseVisualStyleBackColor = true;
            MadMaxTmpOrdnerBT.Click += MadMaxTmpOrdnerBT_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2384, 765);
            Controls.Add(MadMaxTmpOrdnerBT);
            Controls.Add(MadMaxTmpOrdnerTB);
            Controls.Add(groupBox1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(InfoGUI);
            Controls.Add(GPUGemeinsameSpeicherGUI);
            Controls.Add(KompressionAuswahl);
            Controls.Add(KLevelAuswahl);
            Controls.Add(PlotterAuswahl);
            Controls.Add(WerbungSpende);
            Controls.Add(WerbungYouTube);
            Controls.Add(Werbelink);
            Controls.Add(PlotsPrüfen);
            Controls.Add(CudaPlotterPfad);
            Controls.Add(SettingsSpeichern);
            Controls.Add(PlotCheck);
            Controls.Add(StopPlot);
            Controls.Add(PlotterGefunden);
            Controls.Add(StartPlot);
            Controls.Add(label4);
            Controls.Add(AnzahlPlots);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PoolKey);
            Controls.Add(FarmerKey);
            Controls.Add(ChiaCudaPlotterWählen);
            Controls.Add(KopierenAnhalten);
            Controls.Add(LogLöschen);
            Controls.Add(log);
            Controls.Add(ZielverzeichnissLöschen);
            Controls.Add(ZielverzeichnissEinfügen);
            Controls.Add(zielPfadListe);
            Controls.Add(QuellordnerWählen);
            Controls.Add(quellPfad);
            Controls.Add(KopierenStarten);
            Controls.Add(Kopieren);
            Name = "Form1";
            Text = "mech2youDV v1.0.1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)AnzahlPlots).EndInit();
            ((System.ComponentModel.ISupportInitialize)GPUGemeinsameSpeicherGUI).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private ComboBox PlotterAuswahl;
        private ComboBox KLevelAuswahl;
        private ComboBox KompressionAuswahl;
        private NumericUpDown GPUGemeinsameSpeicherGUI;
        private RichTextBox InfoGUI;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private RadioButton MadMaxRAMFull;
        private RadioButton MadMaxRAMHalb;
        private RadioButton MadMaxRAMViertel;
        private GroupBox groupBox1;
        private TextBox MadMaxTmpOrdnerTB;
        private Button MadMaxTmpOrdnerBT;
    }
}