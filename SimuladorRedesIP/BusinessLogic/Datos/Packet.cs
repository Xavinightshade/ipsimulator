using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Datos;
using BusinessLogic.Datos;

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
        private IPacketMessage _datos;

        public IPacketMessage Datos
        {
            get { return _datos; }
        }
        public Packet(string ipOrigen, string ipDestino, IPacketMessage datos)
        {
            _ipOrigen = ipOrigen;
            _ipDestino = ipDestino;
            _datos = datos;
        }
        public override string ToString()
        {
            string info = string.Empty;
            info += "Ip Origen: " + _ipOrigen + ",,";
            info += "Ip Destino: " + _ipDestino + ",,";
            info += "Dato: " + _datos;
            return info;
        }
    }
}
