using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Modelos.Logicos.Datos;
using BusinessLogic.Datos;

namespace BusinessLogic.OSI
{
    public class CapaRed
    {
        private CapaDatos _capaDatos;

        public CapaDatos CapaDatos
        {
            get { return _capaDatos; }
        }
        public CapaRed(CapaDatos capaDatos)
        {
            _capaDatos = capaDatos;
        }
        public void Inicializar()
        {
            _capaDatos.PaqueteRecibido += new EventHandler<PaqueteRecibidoEventArgs>(OnPaqueteRecibido);
        }

        private void OnPaqueteRecibido(object sender, PaqueteRecibidoEventArgs e)
        {
            ProcesarPaquete(e.PaqueteRecibido);
        }

        protected virtual void ProcesarPaquete(Packet paquete)
        {
            if (paquete.Datos.Contains("Reply"))
            {
                return;
            }
            
            if (paquete.IpDestino == _capaDatos.Puerto.IPAddress)
            {
                EnviarPaquete(new Packet(_capaDatos.Puerto.IPAddress, paquete.IpOrigen, "Reply " + paquete.Datos),paquete.IpOrigen);
            }
        }

        internal void EnviarPaquete(Packet paquete,string ipDestino)
        {
            _capaDatos.EnviarPaquete(paquete, ipDestino);
        }
    }
}
