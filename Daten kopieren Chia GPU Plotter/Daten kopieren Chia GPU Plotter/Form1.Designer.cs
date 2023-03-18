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
            PoolContractAdresse = new TextBox();
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
            PlotsPrüfenCB = new CheckBox();
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
            MadMaxTmp2OrdnerTB = new TextBox();
            MadMaxTmp2OrdnerBT = new Button();
            MadMaxTmp3OrdnerTB = new TextBox();
            MadMaxTmp3OrdnerBT = new Button();
            WakeUpHDDCB = new CheckBox();
            label9 = new Label();
            ThreadsND = new NumericUpDown();
            label10 = new Label();
            BucketsND = new NumericUpDown();
            label11 = new Label();
            Buckets3ND = new NumericUpDown();
            WaitForCopyCB = new CheckBox();
            label12 = new Label();
            ThreadmultiplierforP2ND = new NumericUpDown();
            WakeUpHddsB = new Button();
            WakeUpHddsTB = new TextBox();
            PlotGleichmäßigVerteilen = new CheckBox();
            TmpDateienLöschen = new Button();
            ZugriffsrechtPrüfen = new Button();
            ((System.ComponentModel.ISupportInitialize)AnzahlPlots).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GPUGemeinsameSpeicherGUI).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ThreadsND).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BucketsND).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Buckets3ND).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ThreadmultiplierforP2ND).BeginInit();
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
            quellPfad.Size = new Size(571, 29);
            quellPfad.TabIndex = 2;
            // 
            // QuellordnerWählen
            // 
            QuellordnerWählen.Location = new Point(408, 83);
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
            log.Location = new Point(598, 306);
            log.Multiline = true;
            log.Name = "log";
            log.ScrollBars = ScrollBars.Both;
            log.Size = new Size(1781, 363);
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
            // PoolContractAdresse
            // 
            PoolContractAdresse.Location = new Point(906, 122);
            PoolContractAdresse.Name = "PoolContractAdresse";
            PoolContractAdresse.Size = new Size(945, 31);
            PoolContractAdresse.TabIndex = 13;
            PoolContractAdresse.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(720, 48);
            label1.Name = "label1";
            label1.Size = new Size(151, 25);
            label1.TabIndex = 14;
            label1.Text = "Cuda Plotter Pfad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(720, 88);
            label2.Name = "label2";
            label2.Size = new Size(151, 25);
            label2.TabIndex = 15;
            label2.Text = "Farmer public key";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(720, 125);
            label3.Name = "label3";
            label3.Size = new Size(183, 25);
            label3.TabIndex = 16;
            label3.Text = "Pool contract address";
            // 
            // AnzahlPlots
            // 
            AnzahlPlots.Location = new Point(1170, 199);
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
            label4.Location = new Point(1170, 165);
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
            // PlotsPrüfenCB
            // 
            PlotsPrüfenCB.AutoSize = true;
            PlotsPrüfenCB.Location = new Point(2219, 209);
            PlotsPrüfenCB.Name = "PlotsPrüfenCB";
            PlotsPrüfenCB.Size = new Size(134, 29);
            PlotsPrüfenCB.TabIndex = 25;
            PlotsPrüfenCB.Text = "Plots prüfen";
            PlotsPrüfenCB.UseVisualStyleBackColor = true;
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
            PlotterAuswahl.Items.AddRange(new object[] { "Chia GPU Plotter", "MadMax CPU Plotter", "MadMax GPU Plotter" });
            PlotterAuswahl.Location = new Point(597, 197);
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
            KLevelAuswahl.Location = new Point(822, 197);
            KLevelAuswahl.Name = "KLevelAuswahl";
            KLevelAuswahl.Size = new Size(96, 33);
            KLevelAuswahl.TabIndex = 30;
            KLevelAuswahl.Text = "K Level";
            // 
            // KompressionAuswahl
            // 
            KompressionAuswahl.FormattingEnabled = true;
            KompressionAuswahl.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            KompressionAuswahl.Location = new Point(924, 197);
            KompressionAuswahl.Name = "KompressionAuswahl";
            KompressionAuswahl.Size = new Size(141, 33);
            KompressionAuswahl.TabIndex = 31;
            KompressionAuswahl.Text = "Kompression";
            // 
            // GPUGemeinsameSpeicherGUI
            // 
            GPUGemeinsameSpeicherGUI.Location = new Point(1071, 198);
            GPUGemeinsameSpeicherGUI.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            GPUGemeinsameSpeicherGUI.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            GPUGemeinsameSpeicherGUI.Name = "GPUGemeinsameSpeicherGUI";
            GPUGemeinsameSpeicherGUI.Size = new Size(84, 31);
            GPUGemeinsameSpeicherGUI.TabIndex = 32;
            GPUGemeinsameSpeicherGUI.Value = new decimal(new int[] { 115, 0, 0, 0 });
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
            label5.Location = new Point(597, 165);
            label5.Name = "label5";
            label5.Size = new Size(64, 25);
            label5.TabIndex = 34;
            label5.Text = "Plotter";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(822, 165);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 35;
            label6.Text = "K Level";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(924, 165);
            label7.Name = "label7";
            label7.Size = new Size(116, 25);
            label7.TabIndex = 36;
            label7.Text = "Kompression";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1068, 165);
            label8.Name = "label8";
            label8.Size = new Size(102, 25);
            label8.TabIndex = 37;
            label8.Text = "SMem GPU";
            // 
            // MadMaxRAMFull
            // 
            MadMaxRAMFull.AutoSize = true;
            MadMaxRAMFull.Location = new Point(5, 28);
            MadMaxRAMFull.Margin = new Padding(2);
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
            MadMaxRAMHalb.Margin = new Padding(2);
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
            MadMaxRAMViertel.Margin = new Padding(2);
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
            groupBox1.Location = new Point(1300, 158);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(259, 72);
            groupBox1.TabIndex = 41;
            groupBox1.TabStop = false;
            groupBox1.Text = "MadMax RAM verfügbar";
            // 
            // MadMaxTmp2OrdnerTB
            // 
            MadMaxTmp2OrdnerTB.Location = new Point(1592, 233);
            MadMaxTmp2OrdnerTB.Name = "MadMaxTmp2OrdnerTB";
            MadMaxTmp2OrdnerTB.Size = new Size(433, 31);
            MadMaxTmp2OrdnerTB.TabIndex = 41;
            // 
            // MadMaxTmp2OrdnerBT
            // 
            MadMaxTmp2OrdnerBT.Location = new Point(1361, 233);
            MadMaxTmp2OrdnerBT.Name = "MadMaxTmp2OrdnerBT";
            MadMaxTmp2OrdnerBT.Size = new Size(214, 31);
            MadMaxTmp2OrdnerBT.TabIndex = 42;
            MadMaxTmp2OrdnerBT.Text = "MadMax Tmp2 Ordner";
            MadMaxTmp2OrdnerBT.UseVisualStyleBackColor = true;
            MadMaxTmp2OrdnerBT.Click += MadMaxTmpOrdnerBT_Click;
            // 
            // MadMaxTmp3OrdnerTB
            // 
            MadMaxTmp3OrdnerTB.Location = new Point(1592, 270);
            MadMaxTmp3OrdnerTB.Name = "MadMaxTmp3OrdnerTB";
            MadMaxTmp3OrdnerTB.Size = new Size(433, 31);
            MadMaxTmp3OrdnerTB.TabIndex = 43;
            // 
            // MadMaxTmp3OrdnerBT
            // 
            MadMaxTmp3OrdnerBT.Location = new Point(1361, 270);
            MadMaxTmp3OrdnerBT.Name = "MadMaxTmp3OrdnerBT";
            MadMaxTmp3OrdnerBT.Size = new Size(214, 31);
            MadMaxTmp3OrdnerBT.TabIndex = 44;
            MadMaxTmp3OrdnerBT.Text = "MadMax Tmp3 Ordner";
            MadMaxTmp3OrdnerBT.UseVisualStyleBackColor = true;
            MadMaxTmp3OrdnerBT.Click += MadMaxTmp3OrdnerBT_Click;
            // 
            // WakeUpHDDCB
            // 
            WakeUpHDDCB.AutoSize = true;
            WakeUpHDDCB.Location = new Point(2219, 174);
            WakeUpHDDCB.Name = "WakeUpHDDCB";
            WakeUpHDDCB.Size = new Size(153, 29);
            WakeUpHDDCB.TabIndex = 45;
            WakeUpHDDCB.Text = "Wake Up HDD";
            WakeUpHDDCB.UseVisualStyleBackColor = true;
            WakeUpHDDCB.CheckStateChanged += WakeUpHDD_CheckStateChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(598, 233);
            label9.Name = "label9";
            label9.Size = new Size(74, 25);
            label9.TabIndex = 47;
            label9.Text = "Threads";
            // 
            // ThreadsND
            // 
            ThreadsND.Location = new Point(597, 261);
            ThreadsND.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            ThreadsND.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ThreadsND.Name = "ThreadsND";
            ThreadsND.Size = new Size(124, 31);
            ThreadsND.TabIndex = 46;
            ThreadsND.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(734, 233);
            label10.Name = "label10";
            label10.Size = new Size(72, 25);
            label10.TabIndex = 49;
            label10.Text = "Buckets";
            // 
            // BucketsND
            // 
            BucketsND.Location = new Point(733, 261);
            BucketsND.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            BucketsND.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            BucketsND.Name = "BucketsND";
            BucketsND.Size = new Size(124, 31);
            BucketsND.TabIndex = 48;
            BucketsND.Value = new decimal(new int[] { 256, 0, 0, 0 });
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(871, 233);
            label11.Name = "label11";
            label11.Size = new Size(87, 25);
            label11.TabIndex = 51;
            label11.Text = "Buckets 3";
            // 
            // Buckets3ND
            // 
            Buckets3ND.Location = new Point(870, 261);
            Buckets3ND.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            Buckets3ND.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            Buckets3ND.Name = "Buckets3ND";
            Buckets3ND.Size = new Size(124, 31);
            Buckets3ND.TabIndex = 50;
            Buckets3ND.Value = new decimal(new int[] { 256, 0, 0, 0 });
            // 
            // WaitForCopyCB
            // 
            WaitForCopyCB.AutoSize = true;
            WaitForCopyCB.Location = new Point(1000, 263);
            WaitForCopyCB.Name = "WaitForCopyCB";
            WaitForCopyCB.Size = new Size(183, 29);
            WaitForCopyCB.TabIndex = 52;
            WaitForCopyCB.Text = "Warten bis kopiert";
            WaitForCopyCB.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(1190, 233);
            label12.Name = "label12";
            label12.Size = new Size(170, 25);
            label12.TabIndex = 54;
            label12.Text = "Thread multiplier P2";
            // 
            // ThreadmultiplierforP2ND
            // 
            ThreadmultiplierforP2ND.Location = new Point(1189, 261);
            ThreadmultiplierforP2ND.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            ThreadmultiplierforP2ND.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ThreadmultiplierforP2ND.Name = "ThreadmultiplierforP2ND";
            ThreadmultiplierforP2ND.Size = new Size(124, 31);
            ThreadmultiplierforP2ND.TabIndex = 53;
            ThreadmultiplierforP2ND.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // WakeUpHddsB
            // 
            WakeUpHddsB.Location = new Point(1592, 167);
            WakeUpHddsB.Name = "WakeUpHddsB";
            WakeUpHddsB.Size = new Size(230, 41);
            WakeUpHddsB.TabIndex = 55;
            WakeUpHddsB.Text = "Pfad Wake Up Hdds";
            WakeUpHddsB.UseVisualStyleBackColor = true;
            WakeUpHddsB.Click += WakeUpHddsB_Click;
            // 
            // WakeUpHddsTB
            // 
            WakeUpHddsTB.Location = new Point(1828, 172);
            WakeUpHddsTB.Name = "WakeUpHddsTB";
            WakeUpHddsTB.Size = new Size(385, 31);
            WakeUpHddsTB.TabIndex = 56;
            // 
            // PlotGleichmäßigVerteilen
            // 
            PlotGleichmäßigVerteilen.AllowDrop = true;
            PlotGleichmäßigVerteilen.AutoSize = true;
            PlotGleichmäßigVerteilen.Location = new Point(35, 762);
            PlotGleichmäßigVerteilen.Name = "PlotGleichmäßigVerteilen";
            PlotGleichmäßigVerteilen.Size = new Size(249, 29);
            PlotGleichmäßigVerteilen.TabIndex = 57;
            PlotGleichmäßigVerteilen.TabStop = false;
            PlotGleichmäßigVerteilen.Text = "Plots gleichmäßig verteilen";
            PlotGleichmäßigVerteilen.UseVisualStyleBackColor = true;
            // 
            // TmpDateienLöschen
            // 
            TmpDateienLöschen.Location = new Point(296, 754);
            TmpDateienLöschen.Name = "TmpDateienLöschen";
            TmpDateienLöschen.Size = new Size(257, 34);
            TmpDateienLöschen.TabIndex = 58;
            TmpDateienLöschen.Text = "Tmp Dateien löschen";
            TmpDateienLöschen.UseVisualStyleBackColor = true;
            TmpDateienLöschen.Click += TmpDateienLöschen_Click;
            // 
            // ZugriffsrechtPrüfen
            // 
            ZugriffsrechtPrüfen.Location = new Point(559, 754);
            ZugriffsrechtPrüfen.Name = "ZugriffsrechtPrüfen";
            ZugriffsrechtPrüfen.Size = new Size(257, 34);
            ZugriffsrechtPrüfen.TabIndex = 59;
            ZugriffsrechtPrüfen.Text = "Zugriffsrecht prüfen";
            ZugriffsrechtPrüfen.UseVisualStyleBackColor = true;
            ZugriffsrechtPrüfen.Click += ZugriffsrechtPrüfen_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2384, 803);
            Controls.Add(ZugriffsrechtPrüfen);
            Controls.Add(TmpDateienLöschen);
            Controls.Add(PlotGleichmäßigVerteilen);
            Controls.Add(WakeUpHddsTB);
            Controls.Add(WakeUpHddsB);
            Controls.Add(label12);
            Controls.Add(ThreadmultiplierforP2ND);
            Controls.Add(WaitForCopyCB);
            Controls.Add(label11);
            Controls.Add(Buckets3ND);
            Controls.Add(label10);
            Controls.Add(BucketsND);
            Controls.Add(label9);
            Controls.Add(ThreadsND);
            Controls.Add(WakeUpHDDCB);
            Controls.Add(MadMaxTmp3OrdnerBT);
            Controls.Add(MadMaxTmp3OrdnerTB);
            Controls.Add(MadMaxTmp2OrdnerBT);
            Controls.Add(MadMaxTmp2OrdnerTB);
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
            Controls.Add(PlotsPrüfenCB);
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
            Controls.Add(PoolContractAdresse);
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
            Text = "mech2youDV v1.1.6";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)AnzahlPlots).EndInit();
            ((System.ComponentModel.ISupportInitialize)GPUGemeinsameSpeicherGUI).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ThreadsND).EndInit();
            ((System.ComponentModel.ISupportInitialize)BucketsND).EndInit();
            ((System.ComponentModel.ISupportInitialize)Buckets3ND).EndInit();
            ((System.ComponentModel.ISupportInitialize)ThreadmultiplierforP2ND).EndInit();
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
        private TextBox PoolContractAdresse;
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
        private CheckBox PlotsPrüfenCB;
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
        private TextBox MadMaxTmp2OrdnerTB;
        private Button MadMaxTmp2OrdnerBT;
        private TextBox MadMaxTmp3OrdnerTB;
        private Button MadMaxTmp3OrdnerBT;
        private CheckBox WakeUpHDDCB;
        private Label label9;
        private NumericUpDown ThreadsND;
        private Label label10;
        private NumericUpDown BucketsND;
        private Label label11;
        private NumericUpDown Buckets3ND;
        private CheckBox WaitForCopyCB;
        private Label label12;
        private NumericUpDown ThreadmultiplierforP2ND;
        private Button WakeUpHddsB;
        private TextBox WakeUpHddsTB;
        private CheckBox PlotGleichmäßigVerteilen;
        private Button TmpDateienLöschen;
        private Button ZugriffsrechtPrüfen;
    }
}