using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daten_kopieren_Chia_GPU_Plotter
{
    public class KopierDaten
    {
        public String quellpfad="";// Woher kommen die Daten mit Dateiname
        public String dateiname = ""; // Wie lautet der Dateinname
        public bool fertig = false;// Ist der Kopiervorgang abgeschlossen

        public KopierDaten()
        {

        }
        public KopierDaten(String _quellpfad, string _dateiname)
        {
            quellpfad=_quellpfad;
            dateiname=_dateiname;   
        }
    }
}
