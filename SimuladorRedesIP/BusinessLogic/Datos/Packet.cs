using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Datos;

namespace BusinessLogic.Modelos.Logicos.Datos
{
    public class Packet:IFrameMessage
    {
        private string _ipOrigen;

        public string IpOrigen
        {
            get { return _ipOrigen; }
        }
        private string _ipDestino;

        public string IpDestino
        {
            get { return _ipDestino; }
        }
        private string _datos;

        public string Datos
        {
            get { return _datos; }
        }
        public Packet(string ipOrigen,string ipDestino,string datos)
        {
            _ipOrigen = ipOrigen;
            _ipDestino = ipDestino;
            _datos = datos;
        }
    }
}
