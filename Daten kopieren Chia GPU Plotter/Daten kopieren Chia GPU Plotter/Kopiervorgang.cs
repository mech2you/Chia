using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daten_kopieren_Chia_GPU_Plotter
{
    internal class Kopiervorgang : KopierDaten
    {
        public String quellpfad = "";// Quellpfad vom Kopieren
        public BackgroundWorker BWkopieren = new BackgroundWorker();// Kopiervorgang wird Async mit dem BW durchgeführt
        public event EventHandler<String> newLog ;
        public Kopiervorgang(String _quellpfad)
        {
            BWkopieren.DoWork += new DoWorkEventHandler(BWkopiervorgang_DoWork);
            quellpfad = _quellpfad;
        }
        /// <summary>
        /// kopiert die Daten von Quellpfad zum Zielpfad ohne zu prüfen. Ist eine .tmp enthalten mit den Zielpfadnamen wird diese gelöscht
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BWkopiervorgang_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime zeit = DateTime.Now;// für die StartZeit
            String endkürzel = ".tmp";
            Log("kopieren von " + quellpfad + "nach " + zielort + endkürzel + " Uhrzeit: " + zeit.ToShortTimeString());
            Stopwatch watch = new Stopwatch();
            watch.Start();
            //Thread.Sleep(20000);// Wird zum testen verwendet
            if (File.Exists(zielort + endkürzel))// Die temp Datei ist bereits vorhanden und kann gelöscht werden
            {
                File.Delete(zielort + endkürzel);
            }
            System.IO.File.Move(quellpfad, zielort + endkürzel);//Kopieren vom Plot
            System.IO.File.Move(zielort + endkürzel, zielort);// Umbenennen
            watch.Stop();
            // Kopiervorgang wird in die Liste als abgeschlossen eingetragen
            fertig = true;
            Log("kopieren nach " + zielort + " Dauer: " + watch.Elapsed.TotalSeconds + " s");
        }
        //Log wird als Event ausglöst
        public void Log(String _log)
        {
            newLog(this,_log);

        }

    }
}
