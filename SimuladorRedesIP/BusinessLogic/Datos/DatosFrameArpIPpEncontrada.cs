using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Datos;

namespace BusinessLogic.Datos
{
    public class DatosFrameArpIPEncontrada : IFrameMessage
    {
        string _direccionIP;

        public string DireccionIP
        {
            get { return _direccionIP; }
        }
        private string _macAddress;

        public string MacAddress
        {
            get { return _macAddress; }
        }
        private Guid _idPacketOriginal;

        public Guid IdPacketOriginal
        {
            get { return _idPacketOriginal; }
        }
        public DatosFrameArpIPEncontrada(string direccionIP, string macAddress,Guid idPacketOriginal)
        {
            _direccionIP = direccionIP;
            _macAddress = macAddress;
            _idPacketOriginal = idPacketOriginal;
        }
        public override string ToString()
        {
            return "ARP: "+"La dirección MAC:"+ _macAddress+" le corresponde la dirección IP "+ _direccionIP;
        } 
    }
}
