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
using System;

namespace Daten_kopieren_Chia_GPU_Plotter
{
    public partial class Form1 : Form
    {
        String quelle = "";
        String pfadBladBitGPUPlotter = "";
        String kompression = "0";
        String plotterAuswahl = "";
        String gpuSharedMemory = "1";
        String tmpOrdner = "";


        public void logKopiervorgang(object sendere, String _log)
        {
            logGlobal(_log);
        }

        List<Kopiervorgang> DatenKopierer = new List<Kopiervorgang>();// Jedes Ziellaufwerk erhält einen kopierer


        public List<KopierDaten> Kopierliste = new List<KopierDaten>();// Quelldatei und Zustand
        private static System.Timers.Timer aTimer = new System.Timers.Timer(2000);// In welchen Abstand in ms soll nach neuen Plots gesucht werden

        BackgroundWorker PSBackgroundWorker = new BackgroundWorker();// Wird für die Powershell verwendet      

        public static readonly PowerShell _ps = PowerShell.Create();
        Collection<PSObject> rückgabePS = new Collection<PSObject>();


        public Form1()
        {
            InitializeComponent();
            PSBackgroundWorker.DoWork += PSBackgroundWorker_DoWork;
            PSBackgroundWorker.WorkerSupportsCancellation = true;

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
                String argumente = "";
                rückgabePS.Clear();


                if (plotterAuswahl == "Chia GPU Plotter")
                {
                    argumente = " -n " + Convert.ToString(AnzahlPlots.Value) + " --compress " + kompression + " -f " + FarmerKey.Text + " -c " + PoolKey.Text + " cudaplot " + quelle;
                }

                if (plotterAuswahl == "MadMax GPU Plotter")
                {
                    if (MadMaxRAMViertel.Checked == true)
                    {
                        argumente = " -n " + Convert.ToString(AnzahlPlots.Value) + " -M " + gpuSharedMemory + " -C " + kompression + " -f " + FarmerKey.Text + " -c " + PoolKey.Text + " -w -3 " + tmpOrdner + " -t " + quelle;
                    }

                    if (MadMaxRAMHalb.Checked == true)
                    {
                        argumente = " -n " + Convert.ToString(AnzahlPlots.Value) + " -M " + gpuSharedMemory + " -C " + kompression + " -f " + FarmerKey.Text + " -c " + PoolKey.Text + " -w -2 " + tmpOrdner + " -t " + quelle;
                    }
                    if (MadMaxRAMFull.Checked==true)
                    {
                        argumente = " -n " + Convert.ToString(AnzahlPlots.Value) + " -M " + gpuSharedMemory + " -C " + kompression + " -f " + FarmerKey.Text + " -c " + PoolKey.Text + " -w -t " + quelle;
                    }
                   
                }

                rückgabePS = _ps.AddScript(pfadBladBitGPUPlotter + argumente).Invoke();
                if (_ps.HadErrors)
                {
                    foreach (var error in _ps.Streams.Error)
                    {
                        string tmp = error.ToString();
                        logGlobal(tmp);
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
        /// <summary>
        /// Prüft alle Zeitspanne ob neue Plots im Quellverzeichniss da sind
        /// </summary>
        private void SetTimer()
        {
            // Timer Event
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Kopieren_Click(null, EventArgs.Empty);
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
                        log.AppendText(message + Environment.NewLine);

                    }));
                }
                else
                {
                    log.Text += message + Environment.NewLine;
                    log.SelectionStart = log.Text.Length;
                    log.ScrollToCaret();
                }
            }

        }


        /// <summary>
        /// Versteckter Button der die Listen für das Kopieren befüllt und den Backgroundworker starte.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kopieren_Click(object sender, EventArgs e)
        {
            bool abbrechen = false;
            if (PlotsPrüfen.Checked == true)// Prüft ob die Plots valide sind und löscht sie gegebenfalls
            {
                abbrechen = PlotsQuellePrüfen();
            }
            if (!abbrechen)
            {
                string[] dateien = Directory.GetFiles(quelle);
                foreach (string dateiname in dateien)
                {
                    if (dateiname.Substring(dateiname.Length - 4) == "plot")// handelt es sich um einen fertigen Plot
                    {
                        if (File.Exists(dateiname))// Nur wenn die Datei existiert geht es weiter
                        {
                            // wenn die Liste leer ist füge ein Element hinzu
                            if (Kopierliste.Count == 0)
                            {
                                Kopierliste.Add(new KopierDaten(quelle, Path.GetFileName(dateiname)));
                            }
                            else
                            {
                                bool gefunden = false;
                                // fügt die Datei nur zum Kopieren hinzu wenn diese nicht auf der Liste ist
                                foreach (KopierDaten inhalt in Kopierliste)
                                {
                                    if ((inhalt.quellpfad + inhalt.dateiname) == dateiname)
                                    {
                                        gefunden = true;
                                    }
                                }
                                if (!gefunden)// Dateiname ist noch nicht vorhanden und muss auf die Liste
                                {
                                    Kopierliste.Add(new KopierDaten(quelle, Path.GetFileName(dateiname)));
                                }
                            }
                        }
                    }
                }
                foreach (var item in DatenKopierer)
                {
                    if (item.BWkopieren.IsBusy == false)// Ein Laufwerk wird ausgewählt wo der BW nicht beschäftigt mit kopieren ist
                    {
                        foreach (KopierDaten inhalt in Kopierliste)//  File wir ausgewählt die kopiert werden soll
                        {
                            if (inhalt.fertig == false)// Datei wird nicht bereits kopiert
                            {
                                item.quellpfad = inhalt.quellpfad;
                                item.dateiname = inhalt.dateiname;
                                item.fertig = true;// Sperrt die Datei das dies nun von ausgewählten BW bearbeitet wird 
                                inhalt.fertig = true;
                                item.BWkopieren.RunWorkerAsync();
                                break;
                            }

                        }

                    }

                }
            }
        }

        private void KopierenStarten_Click(object sender, EventArgs e)
        {
            if ((quellPfad.Items.Count > 0) && (zielPfadListe.Items.Count > 0))// Stellt sicher das die Quell und Zielverzeichniss eingetragen sind
            {
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
                    quelle = dialog.SelectedPath + "\\";
                    quellPfad.Items.Clear();
                    quellPfad.Items.Add(quelle);
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
                    // Pfad wird eingetragen in die HDD liste und ein neues Obejkt Kopiervorgang wird gleichzeitig in die DatenKopierer Liste eingetragen.
                    // Damit sorgt man das jeder Zielpfad immer einen Kopierer hat
                    zielPfadListe.Items.Add(dialog.SelectedPath + "\\");
                    DatenKopierer.Add(new Kopiervorgang(dialog.SelectedPath.ToString() + "\\"));
                    DatenKopierer[DatenKopierer.Count - 1].neuerLog += logKopiervorgang;
                    // Prozessvortschrittsanzeige einfügen bei einen neuen Zielpfad
                    this.Controls.Add(DatenKopierer[DatenKopierer.Count - 1].Kopierstatus);
                    int tmpX = zielPfadListe.Location.X;
                    int tmpY = zielPfadListe.Location.Y;
                    DatenKopierer[DatenKopierer.Count - 1].Kopierstatus.Location = new Point(tmpX + zielPfadListe.Width, tmpY + (DatenKopierer.Count - 1) * (DatenKopierer[DatenKopierer.Count - 1].Kopierstatus.Height + 8));

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Beim starten Laufwerke laden
            quellPfad.Items.Clear();

            zielPfadListe.Items.Clear();

            StopPlot.Visible = false;
            StartPlot.Visible = true;

            KopierenAnhalten.Visible = false;
            KopierenStarten.Visible = true;

            //Felder als erstes auswählen danach die Variablen laden 

            PlotterAuswahl.SelectedIndex = 0;
            KLevelAuswahl.SelectedIndex = 0;
            KompressionAuswahl.SelectedIndex = 0;
            MadMaxRAMFull.Checked=true;
            // Läd alle gespeicherten Werte in die GUI
            if (Properties.Settings.Default.AnzahlPlots > 0)// Verhindert Fehler bei Release exe
            {
                AnzahlPlots.Value = Properties.Settings.Default.AnzahlPlots;
            }
            else
            {
                AnzahlPlots.Value = 1;
            }
            FarmerKey.Text = Properties.Settings.Default.FarmerKey;

            PoolKey.Text = Properties.Settings.Default.PoolKey;
            if (Directory.Exists(Properties.Settings.Default.QuellPfad))
            {
                quellPfad.Items.Add(Properties.Settings.Default.QuellPfad);
                quelle = Properties.Settings.Default.QuellPfad;
            }
            if (File.Exists(Properties.Settings.Default.CudaPlotterPfad))
            {
                CudaPlotterPfad.Text = Properties.Settings.Default.CudaPlotterPfad;
                pfadBladBitGPUPlotter = Properties.Settings.Default.CudaPlotterPfad;
                CudaPlotterCheck();
            }
            // Teilt die Strings mit ; auf und fügt jeweils die Eventhandler + BackgroundWorker ein 
            string[] stringSeparators = Properties.Settings.Default.Zielpfade.Split(';');
            foreach (string separator in stringSeparators)
            {
                if (Directory.Exists(separator))
                {
                    zielPfadListe.Items.Add(separator);
                    DatenKopierer.Add(new Kopiervorgang(separator.ToString()));
                    DatenKopierer[DatenKopierer.Count - 1].neuerLog += logKopiervorgang;


                    // Prozessvortschrittsanzeige einfügen bei einen neuen Zielpfad
                    this.Controls.Add(DatenKopierer[DatenKopierer.Count - 1].Kopierstatus);
                    int tmpX = zielPfadListe.Location.X;
                    int tmpY = zielPfadListe.Location.Y;
                    DatenKopierer[DatenKopierer.Count - 1].Kopierstatus.Location = new Point(tmpX + zielPfadListe.Width, tmpY + (DatenKopierer.Count - 1) * (DatenKopierer[DatenKopierer.Count - 1].Kopierstatus.Height + 8));
                }
            }
            if (Properties.Settings.Default.PlotterAuswahl != "")
            {
                PlotterAuswahl.Text = Properties.Settings.Default.PlotterAuswahl;
            }
            if (Properties.Settings.Default.kompression != "")
            {
                KompressionAuswahl.Text = Properties.Settings.Default.kompression;
            }
            KLevelAuswahl.Text = Properties.Settings.Default.kGröße;

            GPUGemeinsameSpeicherGUI.Value = Convert.ToDecimal(Properties.Settings.Default.gpuSharedMemory);


            MadMaxTmpOrdnerTB.Text=Properties.Settings.Default.MadMaxTmpOrdner;
            switch (Properties.Settings.Default.MadMaxRamNutzung)
            {
                case "Full":
                    MadMaxRAMFull.Checked = true;
                    break;
                case "1/2":
                    MadMaxRAMHalb.Checked = true;
                    break;
                case "1/4":
                    MadMaxRAMViertel.Checked = true;
                    break;
            }
        }
        /// <summary>
        /// Dient zum löschen von Pfaden in der Liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZielverzeichnissLöschen_Click(object sender, EventArgs e)
        {
            if (zielPfadListe.Items.Count > 0)// Es muss ein Element oder mehere Element vorhanden sein
            {
                if (zielPfadListe.SelectedItem != null)// Es muss ein Element gewählt sein
                {
                    string curItem = zielPfadListe.SelectedItem.ToString();
                    // Find the string in ListBox2.
                    int index = zielPfadListe.FindString(curItem);
                    zielPfadListe.Items.RemoveAt(index);
                    int w = 0;
                    foreach (Kopiervorgang item in DatenKopierer)
                    {
                        if (item.quellpfad == curItem.ToString())
                        {
                            break;
                        }
                        w++;
                    }
                    this.Controls.Remove(DatenKopierer[DatenKopierer.Count - 1].Kopierstatus);
                    DatenKopierer.RemoveAt(w - 1);

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
            bool gefunden = false;
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
                if (zeile.ToString().IndexOf("3.0.0-alpha1-dev") != -1)// Version Chia GPU Plotter gefunden
                {
                    PlotterGefunden.Checked = true;
                    gefunden = true;
                }
                if (zeile.ToString().IndexOf("2.0.0-3e00fa3") != -1)// Version MadMax GPU Plotter gefunden
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
            if (pfadBladBitGPUPlotter != "")
            {
                if (File.Exists(pfadBladBitGPUPlotter))
                {
                    if (PlotterGefunden.Checked == true)
                    {
                        if (!PSBackgroundWorker.IsBusy)
                        {
                            kompression = KompressionAuswahl.SelectedItem.ToString();
                            plotterAuswahl = PlotterAuswahl.SelectedItem.ToString();
                            PSBackgroundWorker.RunWorkerAsync();
                            StartPlot.Visible = false;
                            StopPlot.Visible = true;
                            gpuSharedMemory = Convert.ToString(GPUGemeinsameSpeicherGUI.Value);
                            KopierenStarten_Click(null, EventArgs.Empty);// Startet den Kopiervorgang
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
                                        fehler = true;
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
            Properties.Settings.Default.FarmerKey = FarmerKey.Text;

            Properties.Settings.Default.PoolKey = PoolKey.Text;
            if (quellPfad.Items.Count > 0)
            {
                Properties.Settings.Default.QuellPfad = quellPfad.Items[0].ToString();
            }

            Properties.Settings.Default.CudaPlotterPfad = CudaPlotterPfad.Text;
            Properties.Settings.Default.Zielpfade = "";
            foreach (var item in zielPfadListe.Items)
            {
                Properties.Settings.Default.Zielpfade += item.ToString() + ";";
            }
            Properties.Settings.Default.PlotterAuswahl = PlotterAuswahl.SelectedItem.ToString();
            Properties.Settings.Default.kGröße = KLevelAuswahl.SelectedItem.ToString();
            Properties.Settings.Default.kompression = KompressionAuswahl.SelectedItem.ToString();
            Properties.Settings.Default.gpuSharedMemory = GPUGemeinsameSpeicherGUI.Value.ToString();
            Properties.Settings.Default.MadMaxTmpOrdner = MadMaxTmpOrdnerTB.Text;
            if (MadMaxRAMFull.Checked==true)
            {
                Properties.Settings.Default.MadMaxRamNutzung = "Full";
            }
            if (MadMaxRAMHalb.Checked == true)
            {
                Properties.Settings.Default.MadMaxRamNutzung = "1/2";
            }
            if (MadMaxRAMViertel.Checked == true)
            {
                Properties.Settings.Default.MadMaxRamNutzung = "1/4";
            }
            Properties.Settings.Default.Save();
            

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ps.Stop();
            PSBackgroundWorker.CancelAsync();

            //Bricht alle Kopiervorgänge ab
            foreach (var item in DatenKopierer)
            {
                item.BWkopieren.CancelAsync();
            }
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

        private void MadMaxTmpOrdnerBT_Click(object sender, EventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {

                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    MadMaxTmpOrdnerTB.Text = dialog.SelectedPath + "\\";
                    tmpOrdner = MadMaxTmpOrdnerTB.Text;
                }

            }
        }
    }
}