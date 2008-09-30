﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Datos;
using BusinessLogic.Datos;
using RedesIP.Common;

namespace BusinessLogic.Protocolos
{
    public class ARP
    {
        private Dictionary<string, string> _IP_To_MAC = new Dictionary<string, string>();

        public Dictionary<string, string> IP_To_MAC
        {
            get { return _IP_To_MAC; }
            set { _IP_To_MAC = value; }
        }
        public string GetMacAddressFromIPAddress(string direccion)
        {
            return _IP_To_MAC[direccion];
        }
        public bool ContieneLaDireccionDe(string ipAddress)
        {
            return _IP_To_MAC.ContainsKey(ipAddress);
        }
        public IFrameMessage CrearFramePidiendoLaDireccion(string direccionMACOrigen, string ipAddress)
        {
            return new DatosFrameArpBuscando(ipAddress);
            
        }
        public void ActualizarARP(DatosFrameArpIPEncontrada datosFrame)
        {
           
            _IP_To_MAC.Add(datosFrame.DireccionIP, datosFrame.MacAddress);
            OnCambioDeTablaDeArp();
        }
        public event EventHandler<TiempoEventArgs> CambioDeTablaArp;
        private void OnCambioDeTablaDeArp()
        {
            if (CambioDeTablaArp != null)
                CambioDeTablaArp(this, new TiempoEventArgs(DateTime.Now));
        }
    }
}
