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
using Namotion.Reflection;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using System.IO;
using System.Configuration;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;
using System.Management.Automation.Language;

namespace Daten_kopieren_Chia_GPU_Plotter
{
    public partial class Form1 : Form
    {
        String quelle = "";
        String pfadBladBitGPUPlotter = "";
        String kompression = "0";
        String plotterAuswahl = "";
        String gpuSharedMemory = "1";
        String tmp1Ordner = "";
        String tmp2Ordner = "";
        String tmp3Ordner = "";
        int abstandZwischenStatusanzeigen = 2;
        String hddWakeUp = "standbyStop.txt";
        String kSize = "";
        String threads = "";
        String buckets = "";
        String buckets3 = "";
        String waitforcopy = "";
        String threadmultiplierforP2 = "";
        String pfadWakeUpHDD = "";
        string tmpEndung = "plot"; // Wie ist die Endung der fertigen Plots
        public bool plotterAktiv = false;

        List<Kopiervorgang> DatenKopierer = new List<Kopiervorgang>();// Jedes Ziellaufwerk erhält einen kopierer


        public List<KopierDaten> Kopierliste = new List<KopierDaten>();// Quelldatei und Zustand
        private static System.Timers.Timer aTimer = new System.Timers.Timer(2000);// In welchen Abstand in ms soll nach neuen Plots gesucht werden

        BackgroundWorker PSBackgroundWorker = new BackgroundWorker();// Wird für die Powershell verwendet für den Plotter 


        /// <summary>
        /// Für den Event Handler Log
        /// </summary>
        /// <param name="sendere"></param>
        /// <param name="_log"></param>
        public void LogKopiervorgang(object sendere, String _log)
        {
            logGlobal(_log);
        }
        /// <summary>
        /// Event Handler der bei einen Fehler vom Kopiervorgang ausgelöst wird
        /// </summary>
        /// <param name="sendere"></param>
        /// <param name="_dateiQuelle"></param>
        public void FehlerKopiervorgang(object sendere, KopierDaten _dateiQuelle)
        {
            //logGlobal("Event FehlerKopiervorgang für "+_dateiQuelle.dateiname);
            foreach (KopierDaten inhalt in Kopierliste)//  Es wird nach dem Plot gesucht die nicht kopiert werden konnte
            {
                if (inhalt.dateiname == _dateiQuelle.dateiname)// Wenn ein Plot gefunden wurde wird das Kopieren des Plots in der Liste zurückgesetzt
                {
                    inhalt.fertig = false;
                }
            }
        }




        BackgroundWorker HHD_BW = new BackgroundWorker();// Wird für HDDs verwendet damit diese nicht in slepp gehen
        public Form1()
        {
            InitializeComponent();
            PSBackgroundWorker.DoWork += PSBackgroundWorker_DoWork;
            PSBackgroundWorker.WorkerSupportsCancellation = true;
            PSBackgroundWorker.RunWorkerCompleted += PSBackgroundWorker_Completed;

            HHD_BW.WorkerSupportsCancellation = true;
            HHD_BW.DoWork += HHD_BW_DoWork;

        }
        /// <summary>
        /// Vorbereitung aber noch nicht in Verwendung
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PSBackgroundWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {

            }
            else if (e.Error != null)
            {

            }
            else
            {

            }
        }
        /// <summary>
        /// Wird verwendet festplatten nicht schalfen zu lassen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HHD_BW_DoWork(object? sender, DoWorkEventArgs e)
        {
            if (sender != null)
            {
                BackgroundWorker worker = (BackgroundWorker)sender;
                if (Directory.Exists(pfadWakeUpHDD))
                {
                    string[] pfade = Directory.GetDirectories(pfadWakeUpHDD);
                    foreach (string pfad in pfade)
                    {
                        if (!File.Exists(pfad + "\\" + hddWakeUp))// Erstellt eine Datei falls diese nicht vorhanden ist
                        {
                            try
                            {
                                File.Create(pfad + "\\" + hddWakeUp);
                            }
                            catch (Exception ex)
                            {
                                logGlobal("Fehler Pfad fehlt " + ex.Message.ToString());
                            }

                        }
                    }
                    logGlobal("HDD Wake Up start");
                    while (worker.CancellationPending != true)// Bricht das WakeUp für die HDD´s ab
                    {
                        foreach (string pfad in pfade)
                        {
                            if (File.Exists(pfad + "\\" + hddWakeUp))// Nur wenn die Datei vorhanden ist darf geschrieben werden 
                            {
                                try
                                {
                                    string[] lines = { "Test" };
                                    File.WriteAllLinesAsync(pfad + "\\" + hddWakeUp, lines);
                                }
                                catch (Exception ex)
                                {
                                    logGlobal("Fehler Schreizugriff fehlt?!" + ex.Message.ToString());
                                }


                            }
                        }

                        Thread.Sleep(50000);
                    }
                    logGlobal("HDD Wake Up stop");
                }
            }
            else
            {
                logGlobal("HDD Wake Up Pfade nicht vorhanden");
            }


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
                if (sender != null)
                {
                    BackgroundWorker worker = (BackgroundWorker)sender;
                    IDictionary parameters = new Dictionary<String, String>();
                    String argumente = "";
                    if (plotterAuswahl == "Chia GPU Plotter")
                    {
                        parameters.Add("-n", Convert.ToString(AnzahlPlots.Value));
                        parameters.Add("--compress", kompression);
                        parameters.Add("-f", FarmerKey.Text);
                        parameters.Add("-c", PoolContractAdresse.Text);
                        parameters.Add("cudaplot", quelle);
                    }

                    if (plotterAuswahl == "MadMax GPU Plotter")
                    {
                        parameters.Add("-n", Convert.ToString(AnzahlPlots.Value));
                        parameters.Add("-M", gpuSharedMemory);
                        parameters.Add("-C", kompression);
                        parameters.Add("-f", FarmerKey.Text);
                        parameters.Add("-c", PoolContractAdresse.Text);
                        parameters.Add("waitforcopy", "");
                        parameters.Add("-t", tmp1Ordner);
                        if (MadMaxRAMHalb.Checked == true)
                        {
                            parameters.Add("-2", tmp2Ordner);
                        }
                        if (MadMaxRAMViertel.Checked == true)
                        {
                            parameters.Add("-2", tmp2Ordner);
                            parameters.Add("-3", tmp3Ordner);
                        }
                        parameters.Add("-d", quelle);
                    }
                    if (plotterAuswahl == "MadMax CPU Plotter")
                    {
                        parameters.Add("-k", kSize);
                        parameters.Add("-C", kompression);
                        parameters.Add("-n", Convert.ToString(AnzahlPlots.Value));
                        parameters.Add("-r", threads);
                        parameters.Add("-u", buckets);
                        parameters.Add("-v", buckets3);
                        parameters.Add("-t", tmp1Ordner);
                        parameters.Add("-2", tmp2Ordner);
                        parameters.Add("-d", quelle);
                        parameters.Add(waitforcopy, "");
                        parameters.Add("-c", PoolContractAdresse.Text);
                        parameters.Add("-f", FarmerKey.Text);
                        parameters.Add("-K", threadmultiplierforP2);
                    }
                    if (plotterAuswahl == "noSSD Plotter")
                    {
                        parameters.Add("-c", kompression);
                        parameters.Add("-a", Auszahlungsadresse.Text);
                        parameters.Add("-w", FarmerName.Text);
                        parameters.Add("--no-gpu-mining", null);
                        parameters.Add("--no-temp", null);
                        parameters.Add("--no-benchmark", null);
                        parameters.Add("--no-rescan", null);
                        parameters.Add("-d", quelle);
                        //parameters.Add("-s", quelle + "TMP");
                    }

                    //Powershell wird gestartet und die Argumenten mit dem jeweiligen Plotter ausgeführt
                    using (PowerShell powershell = PowerShell.Create().AddCommand(pfadBladBitGPUPlotter).AddParameters(parameters))//https://learn.microsoft.com/en-us/powershell/scripting/developer/hosting/runspace03-sample?view=powershell-7.3
                    {
                        PSDataCollection<PSObject> outputCollection = new PSDataCollection<PSObject>();
                        IAsyncResult results = powershell.BeginInvoke<PSObject, PSObject>(null, outputCollection);
                        foreach (PSObject outItem in outputCollection)
                        {
                            logPlotter(outItem.BaseObject.ToString());
                            if (worker.CancellationPending == true)// Bricht die Powershell ab
                            {
                                logGlobal("Plotter wird angehalten!!");
                                //powershell.Stop();

                                System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName("libclient.dll", "."); // use "." for this machine // Schließt den Prozess für noSSD
                                foreach (var proc in procs)
                                {
                                    proc.Kill(true);
                                }
                                logGlobal("Plotter angehalten!!");
                                powershell.Dispose();
                                break;
                            }
                        }
                    }
                    string[] dateien = Directory.GetFiles(quelle);// Löscht defekten Plot da der Plotter abgebrochen oder beendet wurde
                    foreach (string dateiname in dateien)
                    {
                        if (dateiname.Substring(dateiname.Length - 3) == "tmp")// handelt es sich um einen defekten Plot
                        {
                            if (File.Exists(dateiname))// Nur wenn die Datei existiert geht es weiter
                            {
                                try
                                {
                                    File.Delete(dateiname);
                                }
                                catch (Exception ex)
                                {
                                    logGlobal(ex.ToString());
                                }
                            }

                        }
                    }








                }
            }
            catch (Exception ex)
            {
                logGlobal(ex.Message);
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
        public void OnTimedEvent(Object source, ElapsedEventArgs e)
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
                        try
                        {
                            log.AppendText(message + Environment.NewLine);
                            log.SelectionStart = log.Text.Length;
                            log.ScrollToCaret();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }


                    }));
                }
                else
                {
                    try
                    {
                        log.Text += message + Environment.NewLine;
                        log.SelectionStart = log.Text.Length;
                        log.ScrollToCaret();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                }
            }
        }
        public void logPlotter(string message)
        {

            if (PlotterLog != null)
            {
                if (PlotterLog.InvokeRequired)
                {
                    PlotterLog.Invoke(new Action(() =>
                    {
                        PlotterLog.AppendText(message + Environment.NewLine);
                        PlotterLog.SelectionStart = PlotterLog.Text.Length;
                        PlotterLog.ScrollToCaret();

                    }));
                }
                else
                {
                    PlotterLog.Text += message + Environment.NewLine;
                    PlotterLog.SelectionStart = PlotterLog.Text.Length;
                    PlotterLog.ScrollToCaret();
                }
            }
        }
        /// <summary>
        /// Entfernt das Laufwerk aus allen Variablen und auch aus der GUI
        /// </summary>
        /// <param name="_pfad"></param>
        public void LaufwerkEntfernen(String _pfad)
        {
            if (zielPfadListe.Items.Count > 0)// Es muss ein Element oder mehere Element vorhanden sein
            {
                Invoke((MethodInvoker)delegate
                {
                    for (int k = 0; k < zielPfadListe.Items.Count; k++)// Löscht aus der Zielliste das Element
                    {
                        if (zielPfadListe.Items[k].ToString() == _pfad)
                        {
                            zielPfadListe.Items.RemoveAt(k);
                            break;
                        }
                    }
                });


                int i = 0;
                int w = 0;
                if (DatenKopierer.Count > 0)
                {
                    foreach (Kopiervorgang item in DatenKopierer)// Löscht alle Prozentbalken aus der GUI (Vieleicht gibt es eine besser Lösung für diesen Teil)
                    {
                        this.Invoke((MethodInvoker)delegate// Wegen threadübergreifender zugriff auf steuerelement mus das so gelöst werden
                        {
                            this.Controls.Remove(item.Kopierstatus); //Löscht alle GUI Prozentbalken

                        });
                        if (item.zielpfad == _pfad)
                        {
                            w = i;
                        }
                        i++;
                    }
                    DatenKopierer.RemoveAt(w);
                }
                this.Invoke((MethodInvoker)delegate// Wegen threadübergreifender zugriff auf steuerelement muss das so gelöst werden
                {
                    for (int k = 0; k < DatenKopierer.Count; k++)// Fügt alle Prozentbalken der GUI wieder hinzu
                    {
                        this.Controls.Add(DatenKopierer[k].Kopierstatus);//Fügt alle GUI Prozentbalken hinzu
                        int tmpX = zielPfadListe.Location.X;
                        int tmpY = zielPfadListe.Location.Y;
                        DatenKopierer[k].Kopierstatus.Location = new Point(tmpX + zielPfadListe.Width, tmpY + (k) * (DatenKopierer[k].Kopierstatus.Height + abstandZwischenStatusanzeigen));

                    }
                });
            }
        }
        public bool kopiervorgangStarten(Kopiervorgang _kopierer, KopierDaten _daten)
        {
            long free = 0, dummy1 = 0, dummy2 = 0;
            long länge = 0;
            GetDiskFreeSpaceEx(_kopierer.zielpfad, ref free, ref dummy1, ref dummy2);// Gibt freie Speicherplatz zurück
            FileInfo info = new FileInfo(_daten.quellpfad + _daten.dateiname);
            try
            {
                länge = info.Length;
            }
            catch (Exception ex)
            {

                logGlobal(ex.ToString());
                return false;
            }


            if (free > länge)// Ist genug Speicher da?
            {
                if (_kopierer.BWkopieren.IsBusy == false)// Ist BW noch frei?
                {
                    _kopierer.quellpfad = _daten.quellpfad;
                    _kopierer.dateiname = _daten.dateiname;
                    _kopierer.fertig = true;// Sperrt die Datei das dies nun von ausgewählten BW bearbeitet wird 
                    _daten.fertig = true;
                    try
                    {
                        _kopierer.BWkopieren.RunWorkerAsync();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        logGlobal(ex.Message);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                logGlobal("Zielfreigabe hat zu wenig Speicher: " + _kopierer.zielpfad);
                LaufwerkEntfernen(_kopierer.zielpfad.ToString());
                return false;
            }
        }
        /// <summary>
        /// Gibt den nächste Datei zurück die noch kopiert werden soll. 
        /// </summary>
        /// <returns>Falls keine Datei gefunden wird null zurückgegeben ansonsten die KopierDaten</returns>
        public KopierDaten? getFreienKopierDaten()
        {
            KopierDaten? tmp = null;
            foreach (KopierDaten inhalt in Kopierliste)//  File wird ausgewählt die kopiert werden soll
            {
                if (inhalt.fertig == false)// Datei wird nicht bereits kopiert
                {
                    tmp = inhalt;
                }
            }
            return tmp;
        }



        //https://code.4noobz.net/determine-the-available-space-on-a-network-drive/
        [SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage"), SuppressUnmanagedCodeSecurity]
        [DllImport("Kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]


        private static extern bool GetDiskFreeSpaceEx
        (
            string lpszPath,                    // Must name a folder, must end with '\'.
            ref long lpFreeBytesAvailable,
            ref long lpTotalNumberOfBytes,
            ref long lpTotalNumberOfFreeBytes
        );

        /// <summary>
        /// Versteckter Button der die Listen für das Kopieren befüllt und den Backgroundworker starte.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kopieren_Click(object sender, EventArgs e)
        {
            bool abbrechen = false;
            if (PlotsPrüfenCB.Checked == true)// Prüft ob die Plots valide sind und löscht sie gegebenfalls
            {
                abbrechen = PlotsQuellePrüfen();
            }
            if (!abbrechen)
            {
                string[] dateien = Directory.GetFiles(quelle);
                foreach (string dateiname in dateien)
                {


                    if (dateiname.Substring(dateiname.Length - 4) == tmpEndung)// handelt es sich um einen fertigen Plot
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
                                for (int w = 0; w < Kopierliste.Count(); w++)
                                {
                                    if ((Kopierliste[w].quellpfad + Kopierliste[w].dateiname) == dateiname)
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
                bool abbrechen2 = false;
                int bwBeschäftigtAnzahl = 0;
                for (int j = 0; j < DatenKopierer.Count; j++)// Wieviel laufwerke sind beschäfigt
                {
                    if (DatenKopierer[j].BWkopieren.IsBusy == true)// 
                    {
                        bwBeschäftigtAnzahl++;
                    }
                }
                for (int i = 0; i < DatenKopierer.Count; i++)// foreach kann nicht verwendet werden da Elemente gelöscht werden
                {
                    if (plotterAktiv == true)//Plotvorgang ist hält den Plotter an oder lässt ihn wieder laufen je nachdem wieviele Plots vorhanden sind
                    {
                        int w = 0;
                        w -= Convert.ToInt32(KopierenMax.Value);// Plots vorhalten aber abzüglich der kopierenden Plots

                        foreach (string dateiname in dateien)
                        {
                            if (File.Exists(dateiname))// Nur wenn die Datei existiert werden diese gezählt + tmp Plots
                            {
                                w++;
                            }
                        }
                        if (w > Convert.ToInt32(PlotsVorhalten.Value))//Wenn X Plots mehr vorhanden sind als Kopiervorgänge dann wird das Plotten unterbrochen
                        {
                            PSBackgroundWorker.CancelAsync();
                        }
                        else
                        {
                            if (PSBackgroundWorker.IsBusy == false)// Setzt das Plotten fort da zu wenige Plots vorhanden sind
                            {
                                PSBackgroundWorker.RunWorkerAsync();
                            }

                        }
                    }
                    if (DatenKopierer[i].BWkopieren.IsBusy == false)// Ein Laufwerk wird ausgewählt wo der BW nicht beschäftigt mit kopieren ist
                    {

                        if (plotterAktiv == true)//Plotvorgang ist aktiv
                        {
                            if (KopierenMax.Value <= bwBeschäftigtAnzahl)// Mehr Kopiervorgänge aktiv sodas keine neuen gestartet werden sollen 
                            {
                                break;
                            }
                        }

                        if (PlotGleichmäßigVerteilen.Checked == true)
                        {
                            int freieSpeicher = 0;
                            long kleinstefreieSpeicher = 0;
                            for (int k = 0; k < DatenKopierer.Count; k++)//  File wird ausgewählt die kopiert werden soll
                            {

                                if (DatenKopierer[k].BWkopieren.IsBusy != true)
                                {
                                    long free = 0, dummy1 = 0, dummy2 = 0;
                                    GetDiskFreeSpaceEx(DatenKopierer[k].zielpfad, ref free, ref dummy1, ref dummy2);// Gibt den freien Speicherplatz zurück
                                    if (k == 0)// Beim ersten mal wird der Speichergröße einfach an kleinstefreieSpeicher übertragen
                                    {
                                        kleinstefreieSpeicher = free;
                                    }
                                    if (kleinstefreieSpeicher < free)// Es wurde ein Datenträger gefunden der noch mehr freien Speicher hat
                                    {
                                        kleinstefreieSpeicher = free;
                                        freieSpeicher = k;//Ermittelt welche DatenKopierer noch am wenigsten voll ist. Merken des Listenindex um den Datenkopier später direkt anzusprechen
                                    }
                                }
                            }
                            KopierDaten? kopierTMP = getFreienKopierDaten();
                            if (kopierTMP != null)
                            {
                                if (DatenKopierer.Count > freieSpeicher)
                                {
                                    kopiervorgangStarten(DatenKopierer[freieSpeicher], kopierTMP);

                                }
                                abbrechen2 = true;// Es wird kopiert oder der Speicher ist voll. In beiden Fällen muss man raus aus den Schleifen
                            }
                        }
                        else
                        {

                            foreach (KopierDaten inhalt in Kopierliste)//  File wird ausgewählt die kopiert werden soll
                            {
                                if (inhalt.fertig == false)// Datei wird nicht bereits kopiert
                                {
                                    long free = 0, dummy1 = 0, dummy2 = 0;
                                    GetDiskFreeSpaceEx(DatenKopierer[i].zielpfad, ref free, ref dummy1, ref dummy2);// Gibt freie Speicherplatz zurück
                                    FileInfo info = new FileInfo(inhalt.quellpfad + inhalt.dateiname);
                                    if (free > info.Length)// Ist genug Speicher da?
                                    {
                                        if (DatenKopierer[i].BWkopieren.IsBusy == false)// Ist BW noch frei?
                                        {
                                            DatenKopierer[i].quellpfad = inhalt.quellpfad;
                                            DatenKopierer[i].dateiname = inhalt.dateiname;
                                            DatenKopierer[i].fertig = true;// Sperrt die Datei das dies nun von ausgewählten BW bearbeitet wird 
                                            inhalt.fertig = true;
                                            DatenKopierer[i].BWkopieren.RunWorkerAsync();
                                        }
                                    }
                                    else
                                    {
                                        logGlobal("Zielfreigabe hat zu wenig Speicher: " + DatenKopierer[i].zielpfad);
                                        LaufwerkEntfernen(DatenKopierer[i].zielpfad.ToString());
                                    }
                                    abbrechen2 = true;// Es wird kopiert oder der Speicher ist voll. In beiden Fällen muss man raus aus den Schleifen
                                }
                                if (abbrechen2)
                                {
                                    break;
                                }
                            }
                        }
                    }

                    if (abbrechen2)
                    {
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Startet den Timer für das Kopieren der Dateien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    DatenKopierer[DatenKopierer.Count - 1].neuerLog += LogKopiervorgang;
                    DatenKopierer[DatenKopierer.Count - 1].fehlerKopieren += FehlerKopiervorgang;
                    // Prozessvortschrittsanzeige einfügen bei einen neuen Zielpfad
                    this.Controls.Add(DatenKopierer[DatenKopierer.Count - 1].Kopierstatus);
                    int tmpX = zielPfadListe.Location.X;
                    int tmpY = zielPfadListe.Location.Y;
                    DatenKopierer[DatenKopierer.Count - 1].Kopierstatus.Location = new Point(tmpX + zielPfadListe.Width, tmpY + (DatenKopierer.Count - 1) * (DatenKopierer[DatenKopierer.Count - 1].Kopierstatus.Height + abstandZwischenStatusanzeigen));

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
            MadMaxRAMFull.Checked = true;
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

            PoolContractAdresse.Text = Properties.Settings.Default.PoolKey;
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
                    DatenKopierer[DatenKopierer.Count - 1].neuerLog += LogKopiervorgang;
                    DatenKopierer[DatenKopierer.Count - 1].fehlerKopieren += FehlerKopiervorgang;

                    // Prozessvortschrittsanzeige einfügen bei einen neuen Zielpfad
                    this.Controls.Add(DatenKopierer[DatenKopierer.Count - 1].Kopierstatus);
                    int tmpX = zielPfadListe.Location.X;
                    int tmpY = zielPfadListe.Location.Y;
                    DatenKopierer[DatenKopierer.Count - 1].Kopierstatus.Location = new Point(tmpX + zielPfadListe.Width, tmpY + (DatenKopierer.Count - 1) * (DatenKopierer[DatenKopierer.Count - 1].Kopierstatus.Height + abstandZwischenStatusanzeigen));
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
            MadMaxTmp1OrdnerTB.Text = Properties.Settings.Default.Tmp1Ordner;
            tmp1Ordner = Properties.Settings.Default.Tmp1Ordner;
            MadMaxTmp2OrdnerTB.Text = Properties.Settings.Default.MadMaxTmp2Ordner;
            tmp2Ordner = Properties.Settings.Default.MadMaxTmp2Ordner;

            MadMaxTmp3OrdnerTB.Text = Properties.Settings.Default.MadMaxTmp3Ordner;
            tmp3Ordner = Properties.Settings.Default.MadMaxTmp3Ordner;

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
            ThreadsND.Value = Convert.ToDecimal(Properties.Settings.Default.Threads);
            BucketsND.Value = Convert.ToDecimal(Properties.Settings.Default.Buckets);
            Buckets3ND.Value = Convert.ToDecimal(Properties.Settings.Default.Buckets3);

            if (Properties.Settings.Default.WaitForCopy)
            {
                WaitForCopyCB.Checked = true;
            }
            else
            {
                WaitForCopyCB.Checked = false;
            }
            ThreadmultiplierforP2ND.Value = Convert.ToDecimal(Properties.Settings.Default.ThreadmultiplierforP2);
            if (Properties.Settings.Default.PlotsPrüfen)
            {
                PlotsPrüfenCB.Checked = true;
            }
            else
            {
                PlotsPrüfenCB.Checked = false;
            }
            if (Properties.Settings.Default.WakeUpHDD)
            {
                WakeUpHDDCB.Checked = true;
            }
            else
            {
                WakeUpHDDCB.Checked = false;
            }
            WakeUpHddsTB.Text = Properties.Settings.Default.pfadWakeUpHDD;
            pfadWakeUpHDD = WakeUpHddsTB.Text;

            if (Properties.Settings.Default.PlotGleichmäßigVerteilen)
            {
                PlotGleichmäßigVerteilen.Checked = true;
            }
            else
            {
                PlotGleichmäßigVerteilen.Checked = false;
            }
            KopierenMax.Value = Convert.ToDecimal(Properties.Settings.Default.kopierenMax);
            PlotsVorhalten.Value = Convert.ToDecimal(Properties.Settings.Default.PlotsVorhalten);

            Auszahlungsadresse.Text = Properties.Settings.Default.Auszahlungsadresse;
            FarmerName.Text = Properties.Settings.Default.FarmerName;

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
                    string? curItem = zielPfadListe.SelectedItem.ToString();
                    // Find the string in ListBox2.
                    if (curItem != null)
                    {
                        LaufwerkEntfernen(curItem);
                    }

                }
            }
        }

        private void LogLöschen_Click(object sender, EventArgs e)
        {
            log.Text = "";
            PlotterLog.Text = "";
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

            using (PowerShell powershell = PowerShell.Create())
            {
                Collection<PSObject> rückgabePS = new Collection<PSObject>();
                try
                {

                    rückgabePS = powershell.AddScript(pfadBladBitGPUPlotter + " --version").Invoke();
                    if (rückgabePS.Count() == 0)
                    {
                        rückgabePS = powershell.AddScript(pfadBladBitGPUPlotter + " -v --no-rescan --no-benchmark --no-gpu-mining --no-gpu-plotting").Invoke();// SSd Plotter gibt infos nur mit -v zurück
                    }
                    if (powershell.HadErrors)
                    {
                        foreach (var error in powershell.Streams.Error)
                        {
                            logGlobal(error.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    logGlobal(ex.Message);
                }
                foreach (PSObject zeile in rückgabePS)
                {
                    ///_______________________GPU CHIA
                    if (zeile.ToString().IndexOf("3.0.0-alpha1-dev") != -1)// Version Chia GPU Plotter gefunden
                    {
                        PlotterGefunden.Checked = true;
                        gefunden = true;
                        logGlobal("Chia GPU Plotter gefunden");
                        PlotterAuswahl.SelectedIndex = 0;
                    }
                    if (zeile.ToString().IndexOf("3.0.0-alpha3-dev") != -1)// Version Chia GPU Plotter gefunden
                    {
                        PlotterGefunden.Checked = true;
                        gefunden = true;
                        logGlobal("Chia GPU Plotter 3 alpha3 gefunden");
                        PlotterAuswahl.SelectedIndex = 0;
                    }
                    if (zeile.ToString().IndexOf("3.0.0-prealpha4") != -1)// Version Chia GPU Plotter gefunden
                    {
                        PlotterGefunden.Checked = true;
                        gefunden = true;
                        logGlobal("Chia GPU Plotter 3 alpha4 gefunden");
                        PlotterAuswahl.SelectedIndex = 0;
                    }
                    if (zeile.ToString().IndexOf("3.0.0") != -1)// Version Chia GPU Plotter gefunden
                    {
                        PlotterGefunden.Checked = true;
                        gefunden = true;
                        logGlobal("Chia GPU Plotter 3.0.0 gefunden");
                        PlotterAuswahl.SelectedIndex = 0;
                    }
                    ///_______________________CPU MADMAX
                    if (zeile.ToString().IndexOf("2.0.0-16eca1f") != -1)// Version MadMax CPU Plotter gefunden
                    {
                        PlotterGefunden.Checked = true;
                        gefunden = true;
                        logGlobal("Version MadMax CPU gefunden");
                        PlotterAuswahl.SelectedIndex = 1;
                    }

                    if (zeile.ToString().IndexOf("2.0.0-3e00fa3") != -1)// Version MadMax GPU Plotter gefunden
                    {
                        PlotterGefunden.Checked = true;
                        gefunden = true;
                        logGlobal("MadMax GPU Plotter gefunden");
                        PlotterAuswahl.SelectedIndex = 2;
                    }
                    if (zeile.ToString().IndexOf("2.0.0-29c814d") != -1)// Version MadMax CPU Plotter gefunden
                    {
                        PlotterGefunden.Checked = true;
                        gefunden = true;
                        logGlobal("Version MadMax GPU gefunden 2.0.0-29c814d");
                        PlotterAuswahl.SelectedIndex = 2;
                    }
                    if (zeile.ToString().IndexOf("2.0.0-b7375ce") != -1)// Version MadMax CPU Plotter gefunden
                    {
                        PlotterGefunden.Checked = true;
                        gefunden = true;
                        logGlobal("Version MadMax GPU gefunden 2.0.0-b7375ce");
                        PlotterAuswahl.SelectedIndex = 2;
                    }
                    ///_______________________noSSD Plotter
                    if (zeile.ToString().IndexOf("NoSSDChiaPool version 2.2") != -1)// Version MadMax CPU Plotter gefunden
                    {
                        PlotterGefunden.Checked = true;
                        gefunden = true;
                        logGlobal("Version NoSSD Plotter gefunden Version 2.2");
                        PlotterAuswahl.SelectedIndex = 3;
                    }
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
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Plotter (*.exe)|*.exe";
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
                            //Variabeln für den Plotter setzen
                            kompression = KompressionAuswahl.SelectedItem.ToString();
                            plotterAuswahl = PlotterAuswahl.SelectedItem.ToString();
                            StartPlot.Visible = false;
                            StopPlot.Visible = true;
                            kSize = KLevelAuswahl.SelectedItem.ToString();
                            gpuSharedMemory = Convert.ToString(GPUGemeinsameSpeicherGUI.Value);
                            threads = Convert.ToString(ThreadsND.Value);
                            buckets = Convert.ToString(BucketsND.Value);
                            buckets3 = Convert.ToString(Buckets3ND.Value);
                            if (WaitForCopyCB.Checked == true)
                            {
                                waitforcopy = " -w";
                            }
                            else
                            {
                                waitforcopy = "";
                            }
                            threadmultiplierforP2 = Convert.ToString(ThreadmultiplierforP2ND.Value);

                            if (KopierenStarten.Visible == true)// Starte das Kopieren wenn nicht bereits es an ist
                            {
                                KopierenStarten_Click(null, EventArgs.Empty);// Startet den Kopiervorgang
                            }
                            PSBackgroundWorker.RunWorkerAsync();
                            plotterAktiv = true;
                        }
                        else
                        {
                            logGlobal("Fehler Bladebit Cuda läuft bereits");
                        }
                    }
                }
            }
        }
        public void FortschrittsbalkenNeuLaden()
        {

        }
        private void StopPlot_Click(object sender, EventArgs e)
        {
            PSBackgroundWorker.CancelAsync();
            plotterAktiv = false;
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

            Properties.Settings.Default.PoolKey = PoolContractAdresse.Text;
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
            Properties.Settings.Default.Tmp1Ordner = MadMaxTmp1OrdnerTB.Text;
            Properties.Settings.Default.MadMaxTmp2Ordner = MadMaxTmp2OrdnerTB.Text;
            Properties.Settings.Default.MadMaxTmp3Ordner = MadMaxTmp3OrdnerTB.Text;
            if (MadMaxRAMFull.Checked == true)
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
            Properties.Settings.Default.Threads = ThreadsND.Value.ToString();
            Properties.Settings.Default.Buckets = BucketsND.Value.ToString();
            Properties.Settings.Default.Buckets3 = Buckets3ND.Value.ToString();
            if (WaitForCopyCB.Checked == true)
            {
                Properties.Settings.Default.WaitForCopy = true;
            }
            else
            {
                Properties.Settings.Default.WaitForCopy = false;
            }
            Properties.Settings.Default.ThreadmultiplierforP2 = ThreadmultiplierforP2ND.Value.ToString();
            if (PlotsPrüfenCB.Checked == true)
            {
                Properties.Settings.Default.PlotsPrüfen = true;
            }
            else
            {
                Properties.Settings.Default.PlotsPrüfen = false;
            }
            if (WakeUpHDDCB.Checked == true)
            {
                Properties.Settings.Default.WakeUpHDD = true;
            }
            else
            {
                Properties.Settings.Default.WakeUpHDD = false;
            }
            Properties.Settings.Default.pfadWakeUpHDD = WakeUpHddsTB.Text;

            if (PlotGleichmäßigVerteilen.Checked)
            {
                Properties.Settings.Default.PlotGleichmäßigVerteilen = true;
            }
            else
            {
                Properties.Settings.Default.PlotGleichmäßigVerteilen = false;
            }
            Properties.Settings.Default.kopierenMax = Convert.ToString(KopierenMax.Value);
            Properties.Settings.Default.PlotsVorhalten = Convert.ToString(PlotsVorhalten.Value);
            Properties.Settings.Default.Auszahlungsadresse = Auszahlungsadresse.Text;
            Properties.Settings.Default.FarmerName = FarmerName.Text;
            Properties.Settings.Default.Save();


        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
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
        private void MadMaxTmp1OrdnerBT_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog())
            {

                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    MadMaxTmp1OrdnerTB.Text = dialog.SelectedPath + "\\";
                    tmp1Ordner = MadMaxTmp1OrdnerTB.Text;
                }

            }
        }
        private void MadMaxTmpOrdnerBT_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog())
            {

                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    MadMaxTmp2OrdnerTB.Text = dialog.SelectedPath + "\\";
                    tmp2Ordner = MadMaxTmp2OrdnerTB.Text;
                }

            }
        }

        private void MadMaxTmp3OrdnerBT_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog())
            {

                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    MadMaxTmp3OrdnerTB.Text = dialog.SelectedPath + "\\";
                    tmp3Ordner = MadMaxTmp3OrdnerTB.Text;
                }

            }
        }

        private void WakeUpHDD_CheckStateChanged(object sender, EventArgs e)
        {
            if (WakeUpHDDCB.Checked == true)
            {
                HHD_BW.RunWorkerAsync();
            }
            else
            {
                HHD_BW.CancelAsync();
            }
        }

        private void WakeUpHddsB_Click(object sender, EventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {

                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    WakeUpHddsTB.Text = dialog.SelectedPath + "\\";
                    pfadWakeUpHDD = WakeUpHddsTB.Text;

                }

            }
        }
        /// <summary>
        /// löscht alle .tmp Dateien in den 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmpDateienLöschen_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(WakeUpHddsTB.Text))
            {
                PSBackgroundWorker.CancelAsync();

                //Bricht alle Kopiervorgänge ab
                foreach (var item in DatenKopierer)
                {
                    item.BWkopieren.CancelAsync();
                }

                string[] ordner = Directory.GetDirectories(WakeUpHddsTB.Text);
                // 
                foreach (string pfad in ordner)
                {
                    if (Directory.Exists(pfad))
                    {

                        string[] dateien = null;
                        try
                        {
                            dateien = Directory.GetFiles(pfad);
                        }
                        catch (Exception ex)
                        {
                            logGlobal("Fehler Unbekannt Pfad -> " + pfad);
                            logGlobal(ex.ToString());
                            dateien = new string[] { "" };
                        }
                        foreach (string dateipfad in dateien)
                        {
                            string[] pfad1 = null;
                            try
                            {
                                pfad1 = Directory.GetDirectories(pfad);
                            }
                            catch (Exception ex)
                            {
                                logGlobal("Fehler Unbekannt Pfad -> " + dateipfad);
                                logGlobal(ex.ToString());
                                pfad1 = new string[] { "" };
                            }

                            if (pfad1.Count() > 0)// es existiert ein Unterpfad
                            {
                                foreach (string unterpfad in pfad1)
                                {
                                    if (Directory.Exists(unterpfad))
                                    {
                                        FileAttributes attributes = File.GetAttributes(unterpfad);
                                        if ((attributes & FileAttributes.System) != FileAttributes.System)
                                        {

                                            string[] dateien1 = null;
                                            try
                                            {
                                                dateien1 = Directory.GetFiles(unterpfad);
                                            }
                                            catch (Exception ex)
                                            {
                                                logGlobal("Fehler Unbekannt Pfad -> " + unterpfad);
                                                logGlobal(ex.ToString());
                                                dateien1 = new string[] { "" };
                                            }
                                            foreach (string dateipfad1 in dateien1)
                                            {
                                                if (dateipfad1.Substring(dateipfad1.Length - 3) == "tmp")// handelt es sich um eine tmp File
                                                {
                                                    if (File.Exists(dateipfad1))// Nur wenn die Datei existiert geht es weiter
                                                    {
                                                        try
                                                        {
                                                            logGlobal("TMP Datei wurde gelöscht: " + dateipfad1);
                                                            File.Delete(dateipfad1);
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            logGlobal("Fehler TMP Datei konnte nicht gelöscht werden -> " + dateipfad1);
                                                            logGlobal(ex.ToString());
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (dateipfad.Substring(dateipfad.Length - 3) == "tmp")// handelt es sich um eine tmp File
                                {
                                    if (File.Exists(dateipfad))// Nur wenn die Datei existiert geht es weiter
                                    {

                                        try
                                        {
                                            logGlobal("TMP Datei wurde gelöscht: " + dateipfad);
                                            File.Delete(dateipfad);
                                        }
                                        catch (Exception ex)
                                        {
                                            logGlobal("Fehler TMP Datei konnte nicht gelöscht werden -> " + dateipfad);
                                            logGlobal(ex.ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        logGlobal("Fehler Pfad existiert nicht -> " + pfad);
                    }


                }
            }
        }
        /// <summary>
        /// Prüft ob die Zugrifssrechte vorhanden sind mit einer Datei test.txt
        /// Diese wird erstellt und ein Inhalt eingefügt. 
        /// Die Datei wird umbennant und danach wird der Inhalt gelesen.
        /// Stimmt der Inhalt mit dem geschriebenen über wird die Datei gelöscht
        /// Es wird nur true zurückgegeben wenn der Test ohne Fehler abläuft. 
        /// </summary>
        /// <param name="_pfad">Pfad zu der getestet werden soll z.B. "E:\\ChiaMM\\"</param>
        /// <returns>true wenn keine Fehler gefunden</returns>
        public bool GetZugriffsrechte(String _pfad)
        {
            if (Directory.Exists(_pfad))
            {
                logGlobal("Pfad vorhanden -> " + _pfad);
                try
                {
                    using (StreamWriter sw = File.CreateText(_pfad + "test.txt"))
                    {
                        sw.WriteLine("Hallo das ist ein Test ob geschrieben werden darf!");
                    }
                    logGlobal("Erstellen einer Testdatei -> " + _pfad + "test.txt");
                    try
                    {
                        File.Move(_pfad + "test.txt", _pfad + "test1.txt");
                        logGlobal("Datei unbenannt von -> " + _pfad + "test.txt zu " + _pfad + "test1.txt");
                        try
                        {
                            //https://learn.microsoft.com/de-de/troubleshoot/developer/visualstudio/csharp/language-compilers/read-write-text-file
                            StreamReader sr = new StreamReader(_pfad + "test1.txt");
                            //Read the first line of text
                            String line = sr.ReadLine();
                            //Continue to read until you reach end of file
                            bool lesenErfolgreich = false;
                            while (line != null)
                            {
                                //write the line to console window
                                if (line.IndexOf("Hallo das ist ein Test ob geschrieben werden darf!") != -1)
                                {
                                    lesenErfolgreich = true;
                                }
                                //Read the next line
                                line = sr.ReadLine();
                            }
                            //close the file
                            sr.Close();

                            if (lesenErfolgreich)
                            {
                                logGlobal("Inhalt der Datei konnte gelesen werden -> " + _pfad + "test1.txt");
                                try
                                {
                                    File.Delete(_pfad + "test1.txt");
                                    logGlobal("Datei konnte gelöscht werden -> " + _pfad + "test1.txt");
                                    logGlobal("Test Erfolgreich für Pfad " + _pfad);
                                    return true;
                                }
                                catch
                                {
                                    logGlobal("Fehler: Datei konnte nicht gelöscht werden -> " + _pfad + "test1.txt");
                                }

                            }
                            else
                            {
                                logGlobal("Fehler: Inhalt der Datei konnte nicht gelesen werden -> " + _pfad + "test1.txt");
                            }
                        }
                        catch
                        {
                            logGlobal("Fehler: Lesen war nicht erfolgreich -> " + _pfad + "test1.txt");
                        }
                    }
                    catch
                    {
                        logGlobal("Fehler: Dateiname konnte nicht unbenannt werden -> " + _pfad + "test.txt zu " + _pfad + "test1.txt");
                    }

                }
                catch
                {
                    logGlobal("Fehler: Erstellen einer Testdatei fehlgeschlagen. Zugriffsrechte fehlen -> " + _pfad + "test.txt");
                }
            }
            else
            {
                logGlobal("Fehler: Pfad nicht vorhanden oder Zugriff fehlt -> " + _pfad);
            }
            return false;
        }
        private void ZugriffsrechtPrüfen_Click(object sender, EventArgs e)
        {
            int i = 0;
            int k = 0;
            if (quellPfad.Items.Count > 0)
            {
                if (GetZugriffsrechte(quellPfad.Items[0].ToString()))
                {
                    i++;
                }
                k++;

            }
            foreach (Kopiervorgang item in DatenKopierer)
            {
                if (item.zielpfad != null)
                {
                    if (GetZugriffsrechte(item.zielpfad))
                    {
                        i++;
                    }
                    k++;
                }
            }
            if (k == i)
            {
                logGlobal("Test Erfolgreich für " + i + " Laufwerk/e");
            }
            else
            {
                k = k - i;
                logGlobal("Fehler: Test nicht Erfolgreich für " + k + " Laufwerk/e | Log prüfen");
            }

        }

        private void GlobalLogKopieren_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetDataObject(log.Text);
        }

        private void PlotterLogKopieren_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetDataObject(PlotterLog.Text);
        }

        private void PlotterGefunden_CheckedChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Wird verwendet um die verschiednen Einstellungen vom jeweiligen Plotter einzustellen und anzuzeigen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlotterAuswahl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ("Chia GPU Plotter" == PlotterAuswahl.SelectedItem.ToString())
            {
                tmpEndung = "plot";
                KLevelAuswahl.Visible = false;
                KLevelAuswahlL.Visible = false;

                KompressionAuswahl.Visible = true;
                KompressionAuswahlL.Visible = true;

                FarmerKey.Visible = true;
                FarmerKeyL.Visible = true;

                PoolContractAdresse.Visible = true;
                PoolContractAdresseL.Visible = true;

                AnzahlPlots.Visible = true;
                AnzahlPlotsL.Visible = true;

                GPUGemeinsameSpeicherGUI.Visible = false;
                GPUGemeinsameSpeicherGUIL.Visible = false;

                MadMaxRAMG.Visible = false;

                ThreadsND.Visible = false;
                ThreadsNDL.Visible = false;

                BucketsND.Visible = false;
                BucketsNDL.Visible = false;

                Buckets3ND.Visible = false;
                Buckets3NDL.Visible = false;

                ThreadmultiplierforP2ND.Visible = false;
                ThreadmultiplierforP2NDL.Visible = false;

                MadMaxTmp1OrdnerBT.Visible = false;
                MadMaxTmp1OrdnerTB.Visible = false;

                MadMaxTmp2OrdnerBT.Visible = false;
                MadMaxTmp2OrdnerTB.Visible = false;

                MadMaxTmp3OrdnerBT.Visible = false;
                MadMaxTmp3OrdnerTB.Visible = false;
            }
            if ("MadMax CPU Plotter" == PlotterAuswahl.SelectedItem.ToString())
            {
                tmpEndung = "plot";
                KLevelAuswahl.Visible = false;
                KLevelAuswahlL.Visible = false;

                FarmerKey.Visible = true;
                FarmerKeyL.Visible = true;

                PoolContractAdresse.Visible = true;
                PoolContractAdresseL.Visible = true;

                AnzahlPlots.Visible = true;
                AnzahlPlotsL.Visible = true;

                KompressionAuswahl.Visible = true;
                KompressionAuswahlL.Visible = true;

                GPUGemeinsameSpeicherGUI.Visible = false;
                GPUGemeinsameSpeicherGUIL.Visible = false;

                MadMaxRAMG.Visible = false;

                ThreadsND.Visible = true;
                ThreadsNDL.Visible = true;

                BucketsND.Visible = true;
                BucketsNDL.Visible = true;

                Buckets3ND.Visible = true;
                Buckets3NDL.Visible = true;

                ThreadmultiplierforP2ND.Visible = true;
                ThreadmultiplierforP2NDL.Visible = true;

                MadMaxTmp1OrdnerBT.Visible = true;
                MadMaxTmp1OrdnerTB.Visible = true;

                MadMaxTmp2OrdnerBT.Visible = true;
                MadMaxTmp2OrdnerTB.Visible = true;

                MadMaxTmp3OrdnerBT.Visible = false;
                MadMaxTmp3OrdnerTB.Visible = false;
            }
            if ("MadMax GPU Plotter" == PlotterAuswahl.SelectedItem.ToString())
            {
                tmpEndung = "plot";

                FarmerKey.Visible = true;
                FarmerKeyL.Visible = true;

                PoolContractAdresse.Visible = true;
                PoolContractAdresseL.Visible = true;

                AnzahlPlots.Visible = true;
                AnzahlPlotsL.Visible = true;

                KLevelAuswahl.Visible = false;
                KLevelAuswahlL.Visible = false;

                KompressionAuswahl.Visible = true;
                KompressionAuswahlL.Visible = true;

                GPUGemeinsameSpeicherGUI.Visible = true;
                GPUGemeinsameSpeicherGUIL.Visible = true;

                MadMaxRAMG.Visible = true;

                ThreadsND.Visible = false;
                ThreadsNDL.Visible = false;

                BucketsND.Visible = false;
                BucketsNDL.Visible = false;

                Buckets3ND.Visible = false;
                Buckets3NDL.Visible = false;

                ThreadmultiplierforP2ND.Visible = false;
                ThreadmultiplierforP2NDL.Visible = false;

                MadMaxTmp1OrdnerBT.Visible = true;
                MadMaxTmp1OrdnerTB.Visible = true;

                MadMaxTmp2OrdnerBT.Visible = false;
                MadMaxTmp2OrdnerTB.Visible = false;

                MadMaxTmp3OrdnerBT.Visible = false;
                MadMaxTmp3OrdnerTB.Visible = false;
                if (MadMaxRAMHalb.Checked)
                {
                    MadMaxTmp2OrdnerBT.Visible = true;
                    MadMaxTmp2OrdnerTB.Visible = true;
                }
                if (MadMaxRAMViertel.Checked)
                {
                    MadMaxTmp2OrdnerBT.Visible = true;
                    MadMaxTmp2OrdnerTB.Visible = true;

                    MadMaxTmp3OrdnerBT.Visible = true;
                    MadMaxTmp3OrdnerTB.Visible = true;
                }
            }
            if ("noSSD Plotter" == PlotterAuswahl.SelectedItem.ToString())
            {
                tmpEndung = ".fpt";
                KLevelAuswahl.Visible = false;
                KLevelAuswahlL.Visible = false;
                KompressionAuswahl.Visible = true;
                KompressionAuswahlL.Visible = true;
                GPUGemeinsameSpeicherGUI.Visible = false;
                GPUGemeinsameSpeicherGUIL.Visible = false;

                FarmerKey.Visible = false;
                FarmerKeyL.Visible = false;

                PoolContractAdresse.Visible = false;
                PoolContractAdresseL.Visible = false;

                AnzahlPlots.Visible = false;
                AnzahlPlotsL.Visible = false;

                MadMaxRAMG.Visible = false;

                ThreadsND.Visible = false;
                ThreadsNDL.Visible = false;

                BucketsND.Visible = false;
                BucketsNDL.Visible = false;

                Buckets3ND.Visible = false;
                Buckets3NDL.Visible = false;

                ThreadmultiplierforP2ND.Visible = false;
                ThreadmultiplierforP2NDL.Visible = false;

                MadMaxTmp1OrdnerBT.Visible = false;
                MadMaxTmp1OrdnerTB.Visible = false;

                MadMaxTmp2OrdnerBT.Visible = false;
                MadMaxTmp2OrdnerTB.Visible = false;

                MadMaxTmp3OrdnerBT.Visible = false;
                MadMaxTmp3OrdnerTB.Visible = false;

                MadMaxTmp2OrdnerBT.Visible = false;
                MadMaxTmp2OrdnerTB.Visible = false;

                MadMaxTmp2OrdnerBT.Visible = false;
                MadMaxTmp2OrdnerTB.Visible = false;

                MadMaxTmp3OrdnerBT.Visible = false;
                MadMaxTmp3OrdnerTB.Visible = false;

            }
        }

        private void MadMaxRAMHalb_CheckedChanged(object sender, EventArgs e)
        {
            MadMaxTmp2OrdnerBT.Visible = false;
            MadMaxTmp2OrdnerTB.Visible = false;

            MadMaxTmp3OrdnerBT.Visible = false;
            MadMaxTmp3OrdnerTB.Visible = false;
            if (MadMaxRAMHalb.Checked)
            {
                MadMaxTmp2OrdnerBT.Visible = true;
                MadMaxTmp2OrdnerTB.Visible = true;
            }
            if (MadMaxRAMViertel.Checked)
            {
                MadMaxTmp2OrdnerBT.Visible = true;
                MadMaxTmp2OrdnerTB.Visible = true;

                MadMaxTmp3OrdnerBT.Visible = true;
                MadMaxTmp3OrdnerTB.Visible = true;
            }
        }

        private void MadMaxRAMViertel_CheckedChanged(object sender, EventArgs e)
        {
            MadMaxTmp2OrdnerBT.Visible = false;
            MadMaxTmp2OrdnerTB.Visible = false;

            MadMaxTmp3OrdnerBT.Visible = false;
            MadMaxTmp3OrdnerTB.Visible = false;
            if (MadMaxRAMHalb.Checked)
            {
                MadMaxTmp2OrdnerBT.Visible = true;
                MadMaxTmp2OrdnerTB.Visible = true;
            }
            if (MadMaxRAMViertel.Checked)
            {
                MadMaxTmp2OrdnerBT.Visible = true;
                MadMaxTmp2OrdnerTB.Visible = true;

                MadMaxTmp3OrdnerBT.Visible = true;
                MadMaxTmp3OrdnerTB.Visible = true;
            }
        }

        private void MadMaxRAMFull_CheckedChanged(object sender, EventArgs e)
        {
            MadMaxTmp2OrdnerBT.Visible = false;
            MadMaxTmp2OrdnerTB.Visible = false;

            MadMaxTmp3OrdnerBT.Visible = false;
            MadMaxTmp3OrdnerTB.Visible = false;
            if (MadMaxRAMHalb.Checked)
            {
                MadMaxTmp2OrdnerBT.Visible = true;
                MadMaxTmp2OrdnerTB.Visible = true;
            }
            if (MadMaxRAMViertel.Checked)
            {
                MadMaxTmp2OrdnerBT.Visible = true;
                MadMaxTmp2OrdnerTB.Visible = true;

                MadMaxTmp3OrdnerBT.Visible = true;
                MadMaxTmp3OrdnerTB.Visible = true;
            }
        }
    }
}