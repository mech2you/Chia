using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Daten_kopieren_Chia_GPU_Plotter
{
    public class Kopiervorgang : KopierDaten
    {
        public String zielpfad = "";// Quellpfad vom Kopieren
        public BackgroundWorker BWkopieren = new BackgroundWorker();// Kopiervorgang wird Async mit dem BW durchgeführt

        public event EventHandler<String> neuerLog ;// Dient zur übergabe von Log Nachrichten am Main
        public String endkürzel = ".tmp"; // Beim kopieren wird dieser Anhang hinzugefügt
        public ProgressBar Kopierstatus = new ProgressBar();
        public Kopiervorgang(String _zielpfad)
        {
            BWkopieren.DoWork += new DoWorkEventHandler(BWkopiervorgang_starten);
            BWkopieren.ProgressChanged += BWkopiervorgang_status;
            BWkopieren.WorkerSupportsCancellation = true;
            BWkopieren.WorkerReportsProgress= true;
            zielpfad = _zielpfad;
        }
        private delegate void ProgressbarUpdateDelegate(int value);
        private void BWkopiervorgang_status(object sender, ProgressChangedEventArgs e)
        {
            if (Kopierstatus.InvokeRequired)
            {
                Kopierstatus.Invoke((MethodInvoker)delegate
                {
                    // Show the current time in the form's title bar.
                    Kopierstatus.Value = e.ProgressPercentage;
                });
            }
            else{
                Kopierstatus.Value = e.ProgressPercentage;
                if (Kopierstatus.Value == 100)
                {
                    Kopierstatus.Value = 0;
                }
            }
               
        }

        public void copy (String _quelldatei, String _zieldatei)
        {
            FileStream fsout = new FileStream(_zieldatei, FileMode.Create);
            FileStream fsin = new FileStream(_quelldatei, FileMode.Open);
            byte[] data = new byte[1048576];//in MiB
            int readbyte;
            while ((readbyte=fsin.Read(data,0,data.Length))>0)
            {
                fsout.Write(data, 0, readbyte);
                BWkopieren.ReportProgress((int)(fsin.Position*100/fsin.Length));
            }
            fsin.Close();
            fsout.Close();
        }
        /// <summary>
        /// kopiert die Daten von Quellpfad zum Zielpfad ohne zu prüfen. Ist eine .tmp enthalten mit den Zielpfadnamen wird diese gelöscht
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BWkopiervorgang_starten(object sender, DoWorkEventArgs e)
        {
            DateTime zeit = DateTime.Now;// für die StartZeit
            Log("kopieren von " + quellpfad+dateiname + "nach " + zielpfad + dateiname + endkürzel + " Uhrzeit: " + zeit.ToShortTimeString());
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Thread.Sleep(5000);// Wird zum testen verwendet
            if (File.Exists(zielpfad + dateiname + endkürzel))// Die temp Datei ist bereits vorhanden und kann gelöscht werden
            {
                File.Delete(zielpfad + dateiname + endkürzel);
            }
            //System.IO.File.Move(quellpfad + dateiname, zielpfad + dateiname + endkürzel);//Kopieren vom Plot
            copy(quellpfad + dateiname, zielpfad + dateiname + endkürzel);
            System.IO.File.Move(zielpfad + dateiname + endkürzel, zielpfad + dateiname);// Umbenennen
            watch.Stop();
            // Kopiervorgang wird in die Liste als abgeschlossen eingetragen
            fertig = true;
            Log("kopieren nach " + quellpfad + dateiname + " Dauer: " + watch.Elapsed.TotalSeconds + " s");
            
        }
        /// <summary>
        /// Log wird als Event ausglöst
        /// </summary>
        /// <param name="_log">Was für Logdaten sollen an Main übertragen werden</param>
        public virtual void Log(String _log)
        {
            neuerLog?.Invoke(this, _log);

        }

    }
}
