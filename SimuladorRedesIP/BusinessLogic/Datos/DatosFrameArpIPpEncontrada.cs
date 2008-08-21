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
        public DatosFrameArpIPEncontrada(string direccionIP, string macAddress)
        {
            _direccionIP = direccionIP;
            _macAddress = macAddress;
        }
        public override string ToString()
        {
            return _direccionIP + " en " + _macAddress;
        } 
    }
}
