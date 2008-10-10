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
            Packet paquete = e.PaqueteRecibido;

                ProcesarPaquete(e.PaqueteRecibido);

        }

        protected virtual void ProcesarPaquete(Packet paquete)
        {
            if (paquete.Datos is EchoReplyMessage)
            {
                return;
            }
            else if (paquete.Datos is EchoMessage)
            {
                if (paquete.IpDestino == CapaDatos.Puerto.IPAddress)
                {
                    EnviarPaquete(paquete.IpOrigen, new Packet(CapaDatos.Puerto.IPAddress, paquete.IpOrigen, new EchoReplyMessage()));
                }
            }


        }

        protected virtual void EnviarPaquete(string direccionIP, Packet packet)
        {
            _capaDatos.EnviarPaquete(packet, direccionIP);
        }


    }
}
