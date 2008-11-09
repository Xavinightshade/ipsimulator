using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Logicos.Equipos;
using SOA.Equipos;
using RedesIP.Modelos.Equipos.Componentes;
using RedesIP.SOA;
using System.Collections.ObjectModel;
using RedesIP;
using RedesIP.Modelos.Datos;

namespace BusinessLogic.Equipos
{
    public class HUBLogico : EquipoLogico
    {
        public static HUBSOA CrearHUBSOA(HUBLogico hubLogico)
        {
            HUBSOA hubRespuesta = new HUBSOA(hubLogico.TipoDeEquipo, hubLogico.Id, hubLogico.X, hubLogico.Y, hubLogico.Nombre);
            foreach (PuertoEthernetLogicoBase puerto in hubLogico.PuertosEthernet)
            {
                hubRespuesta.AgregarPuerto(new PuertoBaseSOA(puerto.Id, puerto.Nombre, puerto.Habilitado));
            }
            return hubRespuesta;
        }

        private List<PuertoEthernetLogicoBase> _puertosEthernet = new List<PuertoEthernetLogicoBase>();


        public ReadOnlyCollection<PuertoEthernetLogicoBase> PuertosEthernet
        {
            get { return _puertosEthernet.AsReadOnly(); }
        }
        public HUBLogico(Guid id, int X, int Y, string nombre)
            : base(id, TipoDeEquipo.HUB, X, Y, nombre)
        {


        }






        public void AgregarPuerto(Guid idPuerto, string nombre, bool habilitado)
        {
            PuertoEthernetLogicoBase puerto = new PuertoEthernetLogicoBase(idPuerto, nombre, habilitado);
            _puertosEthernet.Add(puerto);
        }


        public override void InicializarEquipo()
        {
              InicializarPuertos();
        }

        private void InicializarPuertos()
        {
            foreach (PuertoEthernetLogicoBase puerto in _puertosEthernet)
            {
                puerto.FrameRecibido += new EventHandler<FrameRecibidoEventArgs>(puerto_FrameRecibido);
            }
        }

        void puerto_FrameRecibido(object sender, FrameRecibidoEventArgs e)
        {
            PuertoEthernetLogicoBase puertoOrigen = (PuertoEthernetLogicoBase)sender;
            Frame frame = e.FrameRecibido;
            foreach (PuertoEthernetLogicoBase puerto in _puertosEthernet)
            {
                if (puerto == puertoOrigen)
                    continue;
                ((IEnvioReciboDatos)puerto).TransmitirFrame(frame);
            }

        }

        private  void DesconectarEquipo()
        {
            foreach (PuertoEthernetLogicoBase puerto in _puertosEthernet)
            {
                puerto.FrameRecibido -= new EventHandler<FrameRecibidoEventArgs>(puerto_FrameRecibido);
            }
            _puertosEthernet.Clear();
            _puertosEthernet = null;
        }
        public override void Dispose()
        {
            DesconectarEquipo();

           
        }
    }
}
