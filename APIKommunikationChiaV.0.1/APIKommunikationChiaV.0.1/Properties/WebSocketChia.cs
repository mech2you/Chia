using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Security;
using System.Net.WebSockets;
using System.Threading;
using System.Net.Http;

namespace APIKommunikationChiaV._0._1.Properties
{
    class WebSocketChia
    {
        private const string NodeHostAddress = "";
        private Int16 port = 0;
        private String adresse="";
        private String certPfad = "";
        private String keyPfad = "";
        public Int16 error = 0;
        Uri ConnectURL;

        /// <summary>
        /// Inizaliseiert alle notwendigen Dateien. 
        /// </summary>
        /// <param name="_adresse">Adresse zum Chia Server z.B. localhost oder 127.0.0.1</param>
        /// <param name="_port">Port zum Server</param>
        /// <param name="_certPfad">Pfad zu der Zertifikat Datei von Chia (siehe ca Ordner) </param>
        /// <param name="_keyPfad">Pfad zu Key von Chia (siehe ca Ordner) </param>
        public WebSocketChia(String _adresse, Int16 _port, String _certPfad, String _keyPfad)
        {
            adresse = _adresse;
            port = _port;

            ConnectURL=new Uri($"https://{adresse}:{port}");
            if (!File.Exists(_certPfad))
            {
                error = 1;
            }
            else
            {
                certPfad = _certPfad;
            }
            if (!File.Exists(_keyPfad))
            {
                error = 2;
            }
            else
            {
                keyPfad = _keyPfad;
            }

        }

    }
}
