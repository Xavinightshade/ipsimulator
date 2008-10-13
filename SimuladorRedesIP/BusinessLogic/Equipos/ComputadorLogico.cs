using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Datos;
using RedesIP.Modelos.Equipos.Componentes;
using System.Collections.ObjectModel;
using RedesIP.Common;
using BusinessLogic.Modelos.Logicos.Datos;
using BusinessLogic.OSI;
using BusinessLogic.Protocolos;
using BusinessLogic;
using BusinessLogic.Componentes;
using SOA;
using BusinessLogic.Datos;
using BusinessLogic.Threads;


namespace RedesIP.Modelos.Logicos.Equipos
{
    public class ComputadorLogico : EquipoLogico
    {
        private Dictionary<Guid, ArchivoSOA> _archivosRecibidos = new Dictionary<Guid, ArchivoSOA>();
        public Dictionary<Guid, ArchivoSOA> ArchivosRecibidos
        {
            get { return _archivosRecibidos; }
        }
        private ControladorTCP _controladorTCP;

        public ControladorTCP ControladorTCP
        {
            get { return _controladorTCP; }
        }
        private PuertoEthernetCompleto _puertoEthernet;
        private CapaRedPC _capaRed;

        public CapaRedPC CapaRed
        {
            get { return _capaRed; }
        }
        private string _defaultGateWay;
        /// <summary>
        /// Puerto Ethernet Del PC
        /// </summary>
        public PuertoEthernetCompleto PuertoEthernet
        {
            get { return _puertoEthernet; }
        }
        /// <summary>
        /// Nombre Del Pc
        /// </summary>
        public string DefaultGateWay
        {
            get { return _defaultGateWay; }
            set { _defaultGateWay = value; }
        }
        /// <summary>
        /// Crea un nuevo PC
        /// </summary>
        /// <param name="nombre"></param>
        public ComputadorLogico(Guid id, int X, int Y, string nombre, string defaultGateWay)
            : base(id, TipoDeEquipo.Computador, X, Y, nombre)
        {

            _defaultGateWay = defaultGateWay;

        }





        public event EventHandler<ArchivoRecibido> ArchivoRecibido;





        public void AgregarPuerto(Guid idPuerto, string nombre, string macAddress, string direccionIP, int? mask,bool habilitado)
        {
            _puertoEthernet = new PuertoEthernetCompleto(macAddress, idPuerto, nombre, mask, direccionIP,habilitado);
        }

        public override void InicializarEquipo()
        {
            CapaDatos capaDatos = new CapaDatos(new ARP(), _puertoEthernet);
            _capaRed = new CapaRedPC(capaDatos,this);
            _capaRed.Inicializar();
            _controladorTCP = new ControladorTCP(_capaRed);
            _controladorTCP.ArchivoRecibido += new EventHandler<EventArgs>(_controladorTCP_ArchivoRecibido);
        }

        void _controladorTCP_ArchivoRecibido(object sender, EventArgs e)
        {
            ControladorSesionServer cont = (ControladorSesionServer)sender;
            ArchivoSOA archivo = new ArchivoSOA(Guid.NewGuid(), cont.FileName);
            archivo.Data = cont.Data;
            _archivosRecibidos.Add(archivo.Id, archivo);
            if (ArchivoRecibido != null)
            {
                ArchivoRecibido(this, new ArchivoRecibido(new ArchivoSOA(archivo.Id, archivo.FileName), ThreadManager.HoraActual, Id));
            }
        }





        internal void Ping(string ipDestino)
        {

            _capaRed.Ping(ipDestino);
            
        }

        public override void DesconectarEquipo()
        {
          
        }

        internal void EnviarStream(string ipDestino, int puertoOrigen, int puertoDestino, byte[] stream,
            int segmentSize,string fileName)
        {
            _controladorTCP.EnviarStream(ipDestino, puertoOrigen, puertoDestino,stream,segmentSize,fileName);
        }
    }
}
