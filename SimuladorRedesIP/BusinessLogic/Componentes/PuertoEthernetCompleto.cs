using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.SOA;
using BusinessLogic.Protocolos;

namespace RedesIP.Modelos.Equipos.Componentes
{
    public class PuertoEthernetCompleto : PuertoEthernetLogicoBase
    {
        private ARP _arp;

        public ARP Arp
        {
            get { return _arp; }
            set { _arp = value; }
        }
        public static PuertoCompletoSOA ConvertirPuerto(PuertoEthernetCompleto puertoLogico)
        {
            PuertoCompletoSOA puertoSOA = new PuertoCompletoSOA(puertoLogico.Id, puertoLogico.MACAddress, puertoLogico.Nombre,puertoLogico.IPAddress,puertoLogico.Mascara,puertoLogico.Habilitado);
            return puertoSOA;
        }
        private string _MACAddress;

        public string MACAddress
        {
            get { return _MACAddress; }
        }
        private string _IPAddress;

        public string IPAddress
        {
            get { return _IPAddress; }
            set { _IPAddress = value; }
        }
        private int? _mascara;

        public int? Mascara
        {
            get { return _mascara; }
            set { _mascara = value; }
        }

        public PuertoEthernetCompleto(string MACAddress, Guid id,string nombre,int? mask,string ipAddress,bool habilitado)
            : base(id,nombre,habilitado)
        {
            _MACAddress = MACAddress;
            _mascara = mask;
            _IPAddress = ipAddress;
        }
    }
}
