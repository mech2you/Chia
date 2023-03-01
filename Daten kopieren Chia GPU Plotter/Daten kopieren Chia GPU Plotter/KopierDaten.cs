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
        public String pfad="";
        public String zielort="";
        public bool kopiert=false;
        public bool fertig = false;
        public KopierDaten(String _pfad)
        {
           pfad= _pfad;
        }
    }
}
