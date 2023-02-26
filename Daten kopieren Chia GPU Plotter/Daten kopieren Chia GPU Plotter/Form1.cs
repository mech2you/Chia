using Microsoft.VisualBasic.Logging;
using System.ComponentModel;
using System.Diagnostics;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Policy;

namespace Daten_kopieren_Chia_GPU_Plotter
{
    public partial class Form1 : Form
    {
        String quelle = "";
        String pfadBladBitGPUPlotter = "";



        List<KopierDaten> Kopierliste= new List<KopierDaten>();
        List<string> ZielPfad= new List<string>();
        BackgroundWorker PSBackgroundWorker =new BackgroundWorker();
        int i = 0; // Zähler das die Zielpfade gleichmäßig abgewechselt werden
        List<BackgroundWorker> workerList = new List<BackgroundWorker>();
        
        private static System.Timers.Timer aTimer = new System.Timers.Timer(2000);
        public static readonly PowerShell _ps = PowerShell.Create();
        Collection<PSObject> rückgabePS = new Collection<PSObject>();


        public Form1()
        {
            InitializeComponent();
            PSBackgroundWorker.DoWork += PSBackgroundWorker_DoWork;
        }
        /// <summary>
        /// Wird verwendet um den Cuda Plotter mit den jeweiligen Paramtern zu starten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PSBackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            try
            {
                String argumente = " -n "+Convert.ToString(AnzahlPlots.Value) + " --compress 0 -f " + FarmerKey.Text + " -c "+ PoolKey.Text + " cudaplot "+ quelle;
                rückgabePS.Clear();
                rückgabePS =_ps.AddScript(pfadBladBitGPUPlotter+ argumente).Invoke();
                if (_ps.HadErrors)
                {
                    foreach (var error in _ps.Streams.Error)
                    {
                        string tmp = error.ToString();
                        Console.WriteLine(error.ToString());
                    }
                }
                else
                {
                    logGlobal("Plotter gestartet");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SetTimer()
        {

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Kopieren_Click(null, EventArgs.Empty);
        }
        public bool datei_kopieren(KopierDaten auswahl)
        {
            bool doWork= false;// Wenn eine Arbeit an den BW vergeben worden ist dann wird true zurückgegeben. Damit ist der BW beschäftigt
            bool abbrechen=false;
            foreach (BackgroundWorker item in workerList) {
                if (item.IsBusy==false)
                {
                    DriveInfo[] allDrives = DriveInfo.GetDrives();
                    foreach (DriveInfo drive in allDrives)
                    {
                        if (auswahl.zielort.IndexOf(drive.Name) != -1)//Ist der Datenträger im Zielpfad?
                        {
                            FileInfo info = new FileInfo(auswahl.pfad);
                            logGlobal("Laufwerk Name " + drive.Name + " freie Speicher " + (drive.AvailableFreeSpace / 1024 / 1024 / 1024) + "GB Dateigröße " + (info.Length / 1024 / 1024 / 1024) + "GB");//Für Debug

                            if (drive.AvailableFreeSpace> info.Length)// Ist genug Speicher da?
                            {
                                item.RunWorkerAsync(auswahl);// kopiert die Datei
                                doWork = true;
                                abbrechen=true;
                            }
                            else
                            {
                                logGlobal("Zielpfad hat zu wenig Speicher: " + auswahl.zielort);
                                auswahl.zielort = "";
                                doWork = false;
                            }
                        }
                    }

                    if (abbrechen)
                    {
                        break;// Ein freier Kopiersolot wurde gefunden und die Suche kann beendet werden
                    }
                    
                }
            }
            return doWork;
        }
        /// <summary>
        /// Zuständig um den Log in die Logbox zu schreiben
        /// </summary>
        /// <param name="message"></param>
        public void logGlobal(string message)
        {
            if (log != null)
            {
                if (log.InvokeRequired)
                {
                    log.Invoke(new Action(() =>
                    {
                        log.AppendText(message+Environment.NewLine);

                    }));
                }
                else
                {
                    log.Text += message+ Environment.NewLine;
                    log.SelectionStart = log.Text.Length;
                    log.ScrollToCaret();
                }
            }

        }

        /// <summary>
        /// Wird verwendet um die Dateien von A nach B zu verschieben
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">beinahltet (KopierDaten)e.Argument ziel und quellstring</param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            KopierDaten auwahl = (KopierDaten)e.Argument;
            if (auwahl != null)
            {
                DateTime zeit = DateTime.Now;
                String endkürzel = ".tmp";
                logGlobal("kopieren von " + auwahl.pfad + " nach " + auwahl.zielort + endkürzel+ " Zeit: " +zeit.ToShortTimeString());
                Stopwatch watch = new Stopwatch();
                watch.Start();
                //Thread.Sleep(20000);// Wird zum testen verwendet
                System.IO.File.Move(auwahl.pfad, auwahl.zielort+ endkürzel);
                watch.Stop();
                logGlobal("kopieren nach "+ auwahl.zielort+" Zeit: "+watch.Elapsed.TotalSeconds+" s" );
                System.IO.File.Move(auwahl.zielort + endkürzel, auwahl.zielort);// Umbenennen
            }
        }
        //Versteckter Button der die Listen für das Kopieren befüllt und den Backgroundworker startet 
        private void Kopieren_Click(object sender, EventArgs e)
        {
            if(PlotsPrüfen.Checked==true)// Prüft ob die Plots valide sind und löscht sie gegebenfalls
            {
                PlotsQuellePrüfen();
            }
            
            string[] dateien = Directory.GetFiles(quelle);
            foreach (string datei in dateien)
            {
                if (datei.Substring(datei.Length-4) =="plot")
                {
                    // wenn die Liste leer ist füge ein Element hinzu
                    if (Kopierliste.Count==0) {
                        Kopierliste.Add(new KopierDaten(datei));
                    }
                    else
                    {
                        bool gefunden = true;
                        // fügt die Datei nur zum Kopieren hinzu wenn diese nicht auf der Liste ist
                        foreach (KopierDaten inhalt in Kopierliste)
                        {
                            if (datei == inhalt.pfad)
                            {
                                gefunden = false;
                            }
                        }
                        if (gefunden)
                        {
                            Kopierliste.Add(new KopierDaten(datei));
                        }
                    }
                    
                }
            }
            
            foreach (KopierDaten inhalt in Kopierliste)
            {
                // Daten werden kopiert falls noch nicht
                if (inhalt.kopiert==false)
                {
                    if (inhalt.zielort=="")//Falls kein Pfad zum kopieren eingetragen ist wird dies nun gemacht
                    {
                        String ziel = ZielPfad[i % ZielPfad.Count];// über die Modulo Rechnung wird immer der jeweilige nächste Pfad gewählt 
                        i++;
                        inhalt.zielort = ziel + System.IO.Path.GetFileName(inhalt.pfad);// Fügt den Zielpfad zum Kopieren ein
                        
                        //logGlobal("i "+ i);//Für Debug
                    }
                    inhalt.kopiert = datei_kopieren(inhalt);
                }
            }
        }
        /// <summary>
        /// Setzt alle Variablen für die Funkttionalität zurück
        /// </summary>
        void reset()
        {
            ZielPfad.Clear();
            foreach (String pfad in zielPfadListe.Items)
            {
                ZielPfad.Add(pfad + "\\");// Ziellaufwerke
            }
            workerList.Clear();
            for (int k = 0; k < ZielPfad.Count(); k++)
            {
                workerList.Add(new BackgroundWorker());
                workerList[k].DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            }
        }

        private void KopierenStarten_Click(object sender, EventArgs e)
        {
            if ((quellPfad.Items.Count>0)&& (zielPfadListe.Items.Count>0))// Stellt sicher das die Quell und Zielverzeichniss eingetragen sind
            {
                reset();
                SetTimer();
                KopierenAnhalten.Visible = true;
                KopierenStarten.Visible = false;
            }
           
        }
        /// <summary>
        /// Auswahl des Quellordners
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuellordnerWählen_Click(object sender, EventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {

                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    quelle = dialog.SelectedPath;
                    quellPfad.Items.Clear();
                    quellPfad.Items.Add(quelle);
                    KopierenAnhalten_Click(null, EventArgs.Empty);// Hält den Kopiervorgang an
                }

            }
        }

        private void ZielverzeichnissEinfügen_Click(object sender, EventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {

                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    zielPfadListe.Items.Add(dialog.SelectedPath);
                    KopierenAnhalten_Click(null, EventArgs.Empty);// Hält den Kopiervorgang an
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Beim starten Laufwerke laden
            quellPfad.Items.Clear();
            
            zielPfadListe.Items.Clear();

            /// ADAM können weg nur für Testzwecke
            /// 
            /*
            quellPfad.Items.Add("G:\\Chia");
            zielPfadListe.Items.Add("E:\\109_18TB_T_PP_BB");
            zielPfadListe.Items.Add("L:\\110_18TB_T_CP");
            quelle = "G:\\Chia";
            FarmerKey.Text = "80a740bf183764a7435044c247f49425571201c5733ce27e0951dff77eb569902e5b47e4da220ace758f2060f4778efb";
            PoolKey.Text = "xch1v6u8gftud9hnnaqlex50hec9skzklvanf0g958u8frgp35upf9wqfl0jsw";
            pfadBladBitGPUPlotter = "C:\\Users\\micro\\Documents\\GitHub\\bladebit\\bladebit_cuda.exe";
            PfadCudaPlotterListe.Items.Add(pfadBladBitGPUPlotter);
            PlotterGefunden.Checked = true;
            */
            ///
            StopPlot.Visible= false;
            StartPlot.Visible = true;

            KopierenAnhalten.Visible = false;
            KopierenStarten.Visible = true;

            // Läd alle gespeicherten Werte in die GUI
            if (Properties.Settings.Default.AnzahlPlots>0)// Verhindert Fehler bei Release exe
            {
                AnzahlPlots.Value = Properties.Settings.Default.AnzahlPlots;
            }
            else
            {
                AnzahlPlots.Value = 1;
            }
            FarmerKey.Text=Properties.Settings.Default.FarmerKey ;

            PoolKey.Text=Properties.Settings.Default.PoolKey;
            if (Directory.Exists(Properties.Settings.Default.QuellPfad))
            {
                quellPfad.Items.Add(Properties.Settings.Default.QuellPfad);
                quelle = Properties.Settings.Default.QuellPfad;
            }
            if (File.Exists(Properties.Settings.Default.CudaPlotterPfad))
            {
                CudaPlotterPfad.Text = Properties.Settings.Default.CudaPlotterPfad;
                pfadBladBitGPUPlotter= Properties.Settings.Default.CudaPlotterPfad;
                CudaPlotterCheck();
            }
            string[] stringSeparators = Properties.Settings.Default.Zielpfade.Split(';');
            foreach(string separator in stringSeparators)
            {
                if (Directory.Exists(separator))
                {
                    zielPfadListe.Items.Add(separator);
                }
            }

            

        }

        private void ZielverzeichnissLöschen_Click(object sender, EventArgs e)
        {
            KopierenAnhalten_Click(null, EventArgs.Empty);// Hält den Kopiervorgang an
            if (zielPfadListe.Items.Count!=0)
            {
                if (zielPfadListe.SelectedItem != null)
                {
                    string curItem = zielPfadListe.SelectedItem.ToString();
                    // Find the string in ListBox2.
                    int index = zielPfadListe.FindString(curItem);
                    zielPfadListe.Items.RemoveAt(index);

                }
            }
        }

        private void LogLöschen_Click(object sender, EventArgs e)
        {
            log.Text = "";
        }

        private void KopierenAnhalten_Click(object sender, EventArgs e)
        {
            aTimer.Stop();
            KopierenAnhalten.Visible = false;
            KopierenStarten.Visible = true;
        }
        /// <summary>
        /// Prüft ob der Chia GPU Plotter antwortet. Wenn ja wird der Hacken gesetzt und true ausgegeben
        /// </summary>
        /// <returns></returns>
        private bool CudaPlotterCheck()
        {
            bool gefunden=false;
            rückgabePS.Clear();
            _ps.Streams.Error.Clear();
            try
            {
                
                rückgabePS = _ps.AddScript(pfadBladBitGPUPlotter + " --version").Invoke();
                if (_ps.HadErrors)
                {
                    foreach (var error in _ps.Streams.Error)
                    {
                        Console.WriteLine(error.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            foreach (PSObject zeile in rückgabePS)
            {
                if (zeile.ToString().IndexOf("3.0.0-alpha1-dev") != -1)// Version Plotter gefunden
                {
                    PlotterGefunden.Checked = true;
                    gefunden = true;
                }

            }
            return gefunden;
        }
        /// <summary>
        /// Öffnet Dialog und um den Pfad vom Chia Cuda GPU Ploter auszuwählen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChiaCudaPlotterWählen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\micro\\Documents\\GitHub\\bladebit\\";
                openFileDialog.Filter = "Chia Cuda Plotter (*.exe)|*.exe";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    pfadBladBitGPUPlotter = openFileDialog.FileName;
                    CudaPlotterPfad.Text = pfadBladBitGPUPlotter;
                    CudaPlotterCheck();
                }
            }
        }

        private void StartPlot_Click(object sender, EventArgs e)
        {
            if (pfadBladBitGPUPlotter!="")
            {
                if(File.Exists(pfadBladBitGPUPlotter))
                {
                    if (PlotterGefunden.Checked==true)
                    {
                        if (!PSBackgroundWorker.IsBusy)
                        {
                            PSBackgroundWorker.RunWorkerAsync();
                            StartPlot.Visible = false;
                            StopPlot.Visible = true;
                            KopierenStarten_Click(null, EventArgs.Empty);// Hält den Kopiervorgang an
                        }
                        else
                        {
                            logGlobal("Fehler Bladebit Cuda läuft bereits");
                        }
                        

                    }
                }
            }
        }

        private void StopPlot_Click(object sender, EventArgs e)
        {
            _ps.Stop();
            StartPlot.Visible = true;
            StopPlot.Visible = false;
        }
        /// <summary>
        /// Prüft Plots im Quellverzeichnis und löscht diese Falls ein Defekt vorliegt
        /// </summary>
        /// <returns>Wenn true dann ist ein Fehler bei einen Plot aufgetaucht</returns>
        private bool PlotsQuellePrüfen()
        {
        PowerShell _psPlotCheck = PowerShell.Create();
        Collection<PSObject> rückgabePSPlotCheck = new Collection<PSObject>();
        bool fehler = false;
            rückgabePSPlotCheck.Clear();
            try
            {
                rückgabePSPlotCheck.Clear();
                String argumente = " plots check -n 30 -g " + quelle;
                String pfad = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Programs\\Chia\\resources\\app.asar.unpacked\\daemon\\chia.exe";
                _psPlotCheck.Streams.ClearStreams();
                _psPlotCheck.Streams.Error.Clear();
                rückgabePSPlotCheck = _psPlotCheck.AddScript(pfad + argumente).Invoke();
                if (_psPlotCheck.HadErrors)
                {
                    foreach (var error in _psPlotCheck.Streams.Error)
                    {
                        string tmp = error.ToString();
                        //tmp läuft Voll FEHLER!!!
                        //logGlobal(tmp);// Zeigt die Rückgabe an für Debug
                        Console.WriteLine(tmp);
                        if (tmp.IndexOf("WARNING") != -1) // Zeile enthält WARNING
                        {
                            string[] dateien = Directory.GetFiles(quelle);
                            foreach (string datei in dateien)// Vergleicht Dateinamen mit Inhalt der Ausgabe
                            {
                                if (tmp.IndexOf(datei) != -1)// Prüft alle Dateien ob diese Fehlerhaft sind. Ausgabe .\chia.exe plots check -g G:\Chia z.B. ....WARNING  G:\Chia\plot-k32-XXXX.plot... 
                                {
                                    //Der Plot ist fehlerhaft und wird gelöscht
                                    if (File.Exists(datei))
                                    {
                                        File.Delete(datei);
                                        logGlobal("Plot war fehlerhaft und wurde gelöscht -> " + datei);
                                        fehler =true;
                                        break;
                                    }
                                }
                            }
                            if (fehler)
                            {
                                break;
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _psPlotCheck.Stop();
            return fehler;
        }
        private void PlotCheck_Click(object sender, EventArgs e)
        {
            PlotsQuellePrüfen();
        }
        /// <summary>
        /// Speichert die Daten des Benutzers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsSpeichern_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AnzahlPlots = Convert.ToInt32(AnzahlPlots.Value);
            Properties.Settings.Default.FarmerKey=FarmerKey.Text;

            Properties.Settings.Default.PoolKey=PoolKey.Text;
            if (quellPfad.Items.Count>0)
            {
                Properties.Settings.Default.QuellPfad = quellPfad.Items[0].ToString();
            }
            
            Properties.Settings.Default.CudaPlotterPfad = CudaPlotterPfad.Text;
            Properties.Settings.Default.Zielpfade = "";
            foreach (var item in zielPfadListe.Items)
            {
                Properties.Settings.Default.Zielpfade += item.ToString()+";";
            }
            
            Properties.Settings.Default.Save();

        }
        /// <summary>
        /// Werbung!!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Werbelink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string target = "https://www.mech2you.shop/";
            Process.Start(new ProcessStartInfo() { FileName = target, UseShellExecute = true });
           
        }

        private void WerbungYouTube_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string target = "https://www.youtube.com/@AdamWilczek";
            Process.Start(new ProcessStartInfo() { FileName = target, UseShellExecute = true });
        }

        private void WerbungSpende_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string target = "https://www.paypal.com/donate/?hosted_button_id=T67HY3Z5H4222";
            Process.Start(new ProcessStartInfo() { FileName = target, UseShellExecute = true });
        }
    }
}