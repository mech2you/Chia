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
            LogLöschen = new Button();
            KopierenAnhalten = new Button();
            ChiaCudaPlotterWählen = new Button();
            FarmerKey = new TextBox();
            PoolContractAdresse = new TextBox();
            label1 = new Label();
            FarmerKeyL = new Label();
            PoolContractAdresseL = new Label();
            AnzahlPlots = new NumericUpDown();
            AnzahlPlotsL = new Label();
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
            PlotterAuswahlL = new Label();
            KLevelAuswahlL = new Label();
            KompressionAuswahlL = new Label();
            GPUGemeinsameSpeicherGUIL = new Label();
            MadMaxRAMFull = new RadioButton();
            MadMaxRAMHalb = new RadioButton();
            MadMaxRAMViertel = new RadioButton();
            MadMaxRAMG = new GroupBox();
            MadMaxTmp2OrdnerTB = new TextBox();
            MadMaxTmp2OrdnerBT = new Button();
            MadMaxTmp3OrdnerTB = new TextBox();
            MadMaxTmp3OrdnerBT = new Button();
            WakeUpHDDCB = new CheckBox();
            ThreadsNDL = new Label();
            ThreadsND = new NumericUpDown();
            BucketsNDL = new Label();
            BucketsND = new NumericUpDown();
            Buckets3NDL = new Label();
            Buckets3ND = new NumericUpDown();
            WaitForCopyCB = new CheckBox();
            ThreadmultiplierforP2NDL = new Label();
            ThreadmultiplierforP2ND = new NumericUpDown();
            WakeUpHddsB = new Button();
            WakeUpHddsTB = new TextBox();
            PlotGleichmäßigVerteilen = new CheckBox();
            TmpDateienLöschen = new Button();
            ZugriffsrechtPrüfen = new Button();
            KopierenMax = new NumericUpDown();
            label13 = new Label();
            PlotterLog = new RichTextBox();
            log = new RichTextBox();
            label14 = new Label();
            label15 = new Label();
            GlobalLogKopieren = new Button();
            PlotterLogKopieren = new Button();
            MadMaxTmp1OrdnerBT = new Button();
            MadMaxTmp1OrdnerTB = new TextBox();
            PlotsVorhalten = new NumericUpDown();
            label16 = new Label();
            AuszahlungsadresseL = new Label();
            Auszahlungsadresse = new TextBox();
            FarmerNameL = new Label();
            FarmerName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)AnzahlPlots).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GPUGemeinsameSpeicherGUI).BeginInit();
            MadMaxRAMG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ThreadsND).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BucketsND).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Buckets3ND).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ThreadmultiplierforP2ND).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KopierenMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlotsVorhalten).BeginInit();
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
            // LogLöschen
            // 
            LogLöschen.Location = new Point(559, 1007);
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
            // FarmerKeyL
            // 
            FarmerKeyL.AutoSize = true;
            FarmerKeyL.Location = new Point(720, 88);
            FarmerKeyL.Name = "FarmerKeyL";
            FarmerKeyL.Size = new Size(151, 25);
            FarmerKeyL.TabIndex = 15;
            FarmerKeyL.Text = "Farmer public key";
            // 
            // PoolContractAdresseL
            // 
            PoolContractAdresseL.AutoSize = true;
            PoolContractAdresseL.Location = new Point(720, 125);
            PoolContractAdresseL.Name = "PoolContractAdresseL";
            PoolContractAdresseL.Size = new Size(183, 25);
            PoolContractAdresseL.TabIndex = 16;
            PoolContractAdresseL.Text = "Pool contract address";
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
            // AnzahlPlotsL
            // 
            AnzahlPlotsL.AutoSize = true;
            AnzahlPlotsL.Location = new Point(1170, 165);
            AnzahlPlotsL.Name = "AnzahlPlotsL";
            AnzahlPlotsL.Size = new Size(109, 25);
            AnzahlPlotsL.TabIndex = 18;
            AnzahlPlotsL.Text = "Anzahl Plots";
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
            PlotterGefunden.CheckedChanged += PlotterGefunden_CheckedChanged;
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
            PlotsPrüfenCB.Visible = false;
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
            PlotterAuswahl.Items.AddRange(new object[] { "Chia GPU Plotter", "MadMax CPU Plotter", "MadMax GPU Plotter", "noSSD Plotter" });
            PlotterAuswahl.Location = new Point(597, 197);
            PlotterAuswahl.Name = "PlotterAuswahl";
            PlotterAuswahl.Size = new Size(219, 33);
            PlotterAuswahl.TabIndex = 29;
            PlotterAuswahl.Text = "wähle den Plotter";
            PlotterAuswahl.SelectedIndexChanged += PlotterAuswahl_SelectedIndexChanged;
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
            KompressionAuswahl.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "26", "27", "28", "29", "30", "31", "32", "33" });
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
            // PlotterAuswahlL
            // 
            PlotterAuswahlL.AutoSize = true;
            PlotterAuswahlL.Location = new Point(597, 165);
            PlotterAuswahlL.Name = "PlotterAuswahlL";
            PlotterAuswahlL.Size = new Size(64, 25);
            PlotterAuswahlL.TabIndex = 34;
            PlotterAuswahlL.Text = "Plotter";
            // 
            // KLevelAuswahlL
            // 
            KLevelAuswahlL.AutoSize = true;
            KLevelAuswahlL.Location = new Point(822, 165);
            KLevelAuswahlL.Name = "KLevelAuswahlL";
            KLevelAuswahlL.Size = new Size(66, 25);
            KLevelAuswahlL.TabIndex = 35;
            KLevelAuswahlL.Text = "K Level";
            // 
            // KompressionAuswahlL
            // 
            KompressionAuswahlL.AutoSize = true;
            KompressionAuswahlL.Location = new Point(924, 165);
            KompressionAuswahlL.Name = "KompressionAuswahlL";
            KompressionAuswahlL.Size = new Size(116, 25);
            KompressionAuswahlL.TabIndex = 36;
            KompressionAuswahlL.Text = "Kompression";
            // 
            // GPUGemeinsameSpeicherGUIL
            // 
            GPUGemeinsameSpeicherGUIL.AutoSize = true;
            GPUGemeinsameSpeicherGUIL.Location = new Point(1068, 165);
            GPUGemeinsameSpeicherGUIL.Name = "GPUGemeinsameSpeicherGUIL";
            GPUGemeinsameSpeicherGUIL.Size = new Size(102, 25);
            GPUGemeinsameSpeicherGUIL.TabIndex = 37;
            GPUGemeinsameSpeicherGUIL.Text = "SMem GPU";
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
            MadMaxRAMFull.CheckedChanged += MadMaxRAMFull_CheckedChanged;
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
            MadMaxRAMHalb.CheckedChanged += MadMaxRAMHalb_CheckedChanged;
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
            MadMaxRAMViertel.CheckedChanged += MadMaxRAMViertel_CheckedChanged;
            // 
            // MadMaxRAMG
            // 
            MadMaxRAMG.Controls.Add(MadMaxRAMViertel);
            MadMaxRAMG.Controls.Add(MadMaxRAMHalb);
            MadMaxRAMG.Controls.Add(MadMaxRAMFull);
            MadMaxRAMG.Location = new Point(1300, 158);
            MadMaxRAMG.Margin = new Padding(2);
            MadMaxRAMG.Name = "MadMaxRAMG";
            MadMaxRAMG.Padding = new Padding(2);
            MadMaxRAMG.Size = new Size(259, 72);
            MadMaxRAMG.TabIndex = 41;
            MadMaxRAMG.TabStop = false;
            MadMaxRAMG.Text = "MadMax RAM verfügbar";
            // 
            // MadMaxTmp2OrdnerTB
            // 
            MadMaxTmp2OrdnerTB.Location = new Point(1503, 260);
            MadMaxTmp2OrdnerTB.Name = "MadMaxTmp2OrdnerTB";
            MadMaxTmp2OrdnerTB.Size = new Size(433, 31);
            MadMaxTmp2OrdnerTB.TabIndex = 41;
            // 
            // MadMaxTmp2OrdnerBT
            // 
            MadMaxTmp2OrdnerBT.Location = new Point(1366, 260);
            MadMaxTmp2OrdnerBT.Name = "MadMaxTmp2OrdnerBT";
            MadMaxTmp2OrdnerBT.Size = new Size(131, 31);
            MadMaxTmp2OrdnerBT.TabIndex = 42;
            MadMaxTmp2OrdnerBT.Text = "Tmp2 Ordner";
            MadMaxTmp2OrdnerBT.UseVisualStyleBackColor = true;
            MadMaxTmp2OrdnerBT.Click += MadMaxTmpOrdnerBT_Click;
            // 
            // MadMaxTmp3OrdnerTB
            // 
            MadMaxTmp3OrdnerTB.Location = new Point(1503, 297);
            MadMaxTmp3OrdnerTB.Name = "MadMaxTmp3OrdnerTB";
            MadMaxTmp3OrdnerTB.Size = new Size(433, 31);
            MadMaxTmp3OrdnerTB.TabIndex = 43;
            // 
            // MadMaxTmp3OrdnerBT
            // 
            MadMaxTmp3OrdnerBT.Location = new Point(1366, 297);
            MadMaxTmp3OrdnerBT.Name = "MadMaxTmp3OrdnerBT";
            MadMaxTmp3OrdnerBT.Size = new Size(131, 31);
            MadMaxTmp3OrdnerBT.TabIndex = 44;
            MadMaxTmp3OrdnerBT.Text = "Tmp3 Ordner";
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
            // ThreadsNDL
            // 
            ThreadsNDL.AutoSize = true;
            ThreadsNDL.Location = new Point(598, 233);
            ThreadsNDL.Name = "ThreadsNDL";
            ThreadsNDL.Size = new Size(74, 25);
            ThreadsNDL.TabIndex = 47;
            ThreadsNDL.Text = "Threads";
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
            // BucketsNDL
            // 
            BucketsNDL.AutoSize = true;
            BucketsNDL.Location = new Point(734, 233);
            BucketsNDL.Name = "BucketsNDL";
            BucketsNDL.Size = new Size(72, 25);
            BucketsNDL.TabIndex = 49;
            BucketsNDL.Text = "Buckets";
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
            // Buckets3NDL
            // 
            Buckets3NDL.AutoSize = true;
            Buckets3NDL.Location = new Point(871, 233);
            Buckets3NDL.Name = "Buckets3NDL";
            Buckets3NDL.Size = new Size(87, 25);
            Buckets3NDL.TabIndex = 51;
            Buckets3NDL.Text = "Buckets 3";
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
            // ThreadmultiplierforP2NDL
            // 
            ThreadmultiplierforP2NDL.AutoSize = true;
            ThreadmultiplierforP2NDL.Location = new Point(1190, 233);
            ThreadmultiplierforP2NDL.Name = "ThreadmultiplierforP2NDL";
            ThreadmultiplierforP2NDL.Size = new Size(170, 25);
            ThreadmultiplierforP2NDL.TabIndex = 54;
            ThreadmultiplierforP2NDL.Text = "Thread multiplier P2";
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
            ZugriffsrechtPrüfen.Location = new Point(296, 794);
            ZugriffsrechtPrüfen.Name = "ZugriffsrechtPrüfen";
            ZugriffsrechtPrüfen.Size = new Size(257, 34);
            ZugriffsrechtPrüfen.TabIndex = 59;
            ZugriffsrechtPrüfen.Text = "Zugriffsrecht prüfen";
            ZugriffsrechtPrüfen.UseVisualStyleBackColor = true;
            ZugriffsrechtPrüfen.Click += ZugriffsrechtPrüfen_Click;
            // 
            // KopierenMax
            // 
            KopierenMax.Location = new Point(397, 131);
            KopierenMax.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            KopierenMax.Name = "KopierenMax";
            KopierenMax.Size = new Size(69, 31);
            KopierenMax.TabIndex = 60;
            KopierenMax.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(237, 133);
            label13.Name = "label13";
            label13.Size = new Size(163, 25);
            label13.TabIndex = 61;
            label13.Text = "Plots kopieren Max";
            // 
            // PlotterLog
            // 
            PlotterLog.Location = new Point(720, 539);
            PlotterLog.Name = "PlotterLog";
            PlotterLog.Size = new Size(1660, 502);
            PlotterLog.TabIndex = 62;
            PlotterLog.Text = "";
            // 
            // log
            // 
            log.Location = new Point(720, 340);
            log.Name = "log";
            log.Size = new Size(1660, 193);
            log.TabIndex = 63;
            log.Text = "";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(597, 340);
            label14.Name = "label14";
            label14.Size = new Size(98, 25);
            label14.TabIndex = 64;
            label14.Text = "Global Log";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(597, 542);
            label15.Name = "label15";
            label15.Size = new Size(99, 25);
            label15.TabIndex = 65;
            label15.Text = "Plotter Log";
            // 
            // GlobalLogKopieren
            // 
            GlobalLogKopieren.Location = new Point(576, 499);
            GlobalLogKopieren.Name = "GlobalLogKopieren";
            GlobalLogKopieren.Size = new Size(120, 34);
            GlobalLogKopieren.TabIndex = 66;
            GlobalLogKopieren.Text = "log kopieren";
            GlobalLogKopieren.UseVisualStyleBackColor = true;
            GlobalLogKopieren.Click += GlobalLogKopieren_Click;
            // 
            // PlotterLogKopieren
            // 
            PlotterLogKopieren.Location = new Point(559, 967);
            PlotterLogKopieren.Name = "PlotterLogKopieren";
            PlotterLogKopieren.Size = new Size(120, 34);
            PlotterLogKopieren.TabIndex = 67;
            PlotterLogKopieren.Text = "log kopieren";
            PlotterLogKopieren.UseVisualStyleBackColor = true;
            PlotterLogKopieren.Click += PlotterLogKopieren_Click;
            // 
            // MadMaxTmp1OrdnerBT
            // 
            MadMaxTmp1OrdnerBT.Location = new Point(1366, 223);
            MadMaxTmp1OrdnerBT.Name = "MadMaxTmp1OrdnerBT";
            MadMaxTmp1OrdnerBT.Size = new Size(131, 31);
            MadMaxTmp1OrdnerBT.TabIndex = 69;
            MadMaxTmp1OrdnerBT.Text = "Tmp1 Ordner";
            MadMaxTmp1OrdnerBT.UseVisualStyleBackColor = true;
            MadMaxTmp1OrdnerBT.Click += MadMaxTmp1OrdnerBT_Click;
            // 
            // MadMaxTmp1OrdnerTB
            // 
            MadMaxTmp1OrdnerTB.Location = new Point(1503, 223);
            MadMaxTmp1OrdnerTB.Name = "MadMaxTmp1OrdnerTB";
            MadMaxTmp1OrdnerTB.Size = new Size(433, 31);
            MadMaxTmp1OrdnerTB.TabIndex = 68;
            // 
            // PlotsVorhalten
            // 
            PlotsVorhalten.Location = new Point(162, 131);
            PlotsVorhalten.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            PlotsVorhalten.Name = "PlotsVorhalten";
            PlotsVorhalten.Size = new Size(69, 31);
            PlotsVorhalten.TabIndex = 70;
            PlotsVorhalten.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(35, 133);
            label16.Name = "label16";
            label16.Size = new Size(130, 25);
            label16.TabIndex = 71;
            label16.Text = "Plots vorhalten";
            // 
            // AuszahlungsadresseL
            // 
            AuszahlungsadresseL.AutoSize = true;
            AuszahlungsadresseL.Location = new Point(720, 306);
            AuszahlungsadresseL.Name = "AuszahlungsadresseL";
            AuszahlungsadresseL.Size = new Size(172, 25);
            AuszahlungsadresseL.TabIndex = 73;
            AuszahlungsadresseL.Text = "Auszahlungsadresse";
            // 
            // Auszahlungsadresse
            // 
            Auszahlungsadresse.Location = new Point(906, 303);
            Auszahlungsadresse.Name = "Auszahlungsadresse";
            Auszahlungsadresse.Size = new Size(945, 31);
            Auszahlungsadresse.TabIndex = 72;
            // 
            // FarmerNameL
            // 
            FarmerNameL.AutoSize = true;
            FarmerNameL.Location = new Point(720, 269);
            FarmerNameL.Name = "FarmerNameL";
            FarmerNameL.Size = new Size(118, 25);
            FarmerNameL.TabIndex = 75;
            FarmerNameL.Text = "Farmer Name";
            // 
            // FarmerName
            // 
            FarmerName.Location = new Point(906, 266);
            FarmerName.Name = "FarmerName";
            FarmerName.Size = new Size(945, 31);
            FarmerName.TabIndex = 74;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2388, 1053);
            Controls.Add(FarmerNameL);
            Controls.Add(FarmerName);
            Controls.Add(AuszahlungsadresseL);
            Controls.Add(Auszahlungsadresse);
            Controls.Add(PlotsVorhalten);
            Controls.Add(KopierenMax);
            Controls.Add(label16);
            Controls.Add(MadMaxTmp1OrdnerBT);
            Controls.Add(MadMaxTmp1OrdnerTB);
            Controls.Add(PlotterLogKopieren);
            Controls.Add(GlobalLogKopieren);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(log);
            Controls.Add(PlotterLog);
            Controls.Add(label13);
            Controls.Add(ZugriffsrechtPrüfen);
            Controls.Add(TmpDateienLöschen);
            Controls.Add(PlotGleichmäßigVerteilen);
            Controls.Add(WakeUpHddsTB);
            Controls.Add(WakeUpHddsB);
            Controls.Add(ThreadmultiplierforP2NDL);
            Controls.Add(ThreadmultiplierforP2ND);
            Controls.Add(WaitForCopyCB);
            Controls.Add(Buckets3NDL);
            Controls.Add(Buckets3ND);
            Controls.Add(BucketsNDL);
            Controls.Add(BucketsND);
            Controls.Add(ThreadsNDL);
            Controls.Add(ThreadsND);
            Controls.Add(WakeUpHDDCB);
            Controls.Add(MadMaxTmp3OrdnerBT);
            Controls.Add(MadMaxTmp3OrdnerTB);
            Controls.Add(MadMaxTmp2OrdnerBT);
            Controls.Add(MadMaxTmp2OrdnerTB);
            Controls.Add(MadMaxRAMG);
            Controls.Add(GPUGemeinsameSpeicherGUIL);
            Controls.Add(KompressionAuswahlL);
            Controls.Add(KLevelAuswahlL);
            Controls.Add(PlotterAuswahlL);
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
            Controls.Add(AnzahlPlotsL);
            Controls.Add(AnzahlPlots);
            Controls.Add(PoolContractAdresseL);
            Controls.Add(FarmerKeyL);
            Controls.Add(label1);
            Controls.Add(PoolContractAdresse);
            Controls.Add(FarmerKey);
            Controls.Add(ChiaCudaPlotterWählen);
            Controls.Add(KopierenAnhalten);
            Controls.Add(LogLöschen);
            Controls.Add(ZielverzeichnissLöschen);
            Controls.Add(ZielverzeichnissEinfügen);
            Controls.Add(zielPfadListe);
            Controls.Add(QuellordnerWählen);
            Controls.Add(quellPfad);
            Controls.Add(KopierenStarten);
            Controls.Add(Kopieren);
            Name = "Form1";
            Text = "mech2youDV v1.2.3";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)AnzahlPlots).EndInit();
            ((System.ComponentModel.ISupportInitialize)GPUGemeinsameSpeicherGUI).EndInit();
            MadMaxRAMG.ResumeLayout(false);
            MadMaxRAMG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ThreadsND).EndInit();
            ((System.ComponentModel.ISupportInitialize)BucketsND).EndInit();
            ((System.ComponentModel.ISupportInitialize)Buckets3ND).EndInit();
            ((System.ComponentModel.ISupportInitialize)ThreadmultiplierforP2ND).EndInit();
            ((System.ComponentModel.ISupportInitialize)KopierenMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlotsVorhalten).EndInit();
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
        private Button LogLöschen;
        private Button KopierenAnhalten;
        private Button ChiaCudaPlotterWählen;
        private TextBox FarmerKey;
        private TextBox PoolContractAdresse;
        private Label label1;
        private Label FarmerKeyL;
        private Label PoolContractAdresseL;
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
        private NumericUpDown KopierenMax;
        private Label label13;
        private RichTextBox richTextBox1;
        private RichTextBox PlotterLog;
        private RichTextBox richTextBox2;
        private RichTextBox log;
        private Label label14;
        private Label label15;
        private Button GlobalLogKopieren;
        private Button PlotterLogKopieren;
        private Label AnzahlPlotsL;
        private Label PlotterAuswahlL;
        private Label KLevelAuswahlL;
        private Label KompressionAuswahlL;
        private Label GPUGemeinsameSpeicherGUIL;
        private GroupBox MadMaxRAMG;
        private Label ThreadsNDL;
        private Label BucketsNDL;
        private Label ThreadmultiplierforP2NDL;
        private Button MadMaxTmp1OrdnerBT;
        private TextBox MadMaxTmp1OrdnerTB;
        private Label Buckets3NDL;
        private NumericUpDown numericUpDown1;
        private Label label16;
        private NumericUpDown PlotsVorhalten;
        private Label AuszahlungsadresseL;
        private TextBox Auszahlungsadresse;
        private Label FarmerNameL;
        private TextBox FarmerName;
    }
}