using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Modelos.Logicos.Datos;
using BusinessLogic.Datos;
using BusinessLogic.Threads;

namespace BusinessLogic.OSI
{
    public abstract class CapaRed
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
            if (paquete.IpDestino == CapaDatos.Puerto.IPAddress)
            {
                if (paquete.Datos is EchoReplyMessage)
                {
                    OnEchoMessage(true, paquete.IpOrigen);
                    return;
                }
                else if (paquete.Datos is EchoMessage)
                {
                    EnviarPaquete(paquete.IpOrigen, new Packet(CapaDatos.Puerto.IPAddress, paquete.IpOrigen, new EchoReplyMessage()));
                    OnEchoMessage(false, paquete.IpOrigen);
                }
            }



        }
        public event EventHandler<PingEventArgs> EchoMessage;
        protected void OnEchoMessage(bool esReply, string ipOrigen)
        {
            if (EchoMessage != null)
                EchoMessage(this, new PingEventArgs(esReply, ipOrigen, ThreadManager.HoraActual));
        }
        public virtual void EnviarPaquete(string direccionIP, Packet packet)
        {
            _capaDatos.EnviarPaquete(packet, direccionIP);
        }



        public virtual void Dispose()
    {
        _capaDatos.PaqueteRecibido -= new EventHandler<PaqueteRecibidoEventArgs>(OnPaqueteRecibido);
        _capaDatos.Dispose();
    }

    }
}
