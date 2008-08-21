using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.SOA;

namespace RedesIP.Modelos.Equipos.Componentes
{
    public class PuertoEthernetCompleto : PuertoEthernetLogicoBase
    {
        public static PuertoCompletoSOA ConvertirPuerto(PuertoEthernetCompleto puertoLogico)
        {
            PuertoCompletoSOA puertoSOA = new PuertoCompletoSOA(puertoLogico.Id, puertoLogico.MACAddress, puertoLogico.Nombre,puertoLogico.IPAddress);
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
        public PuertoEthernetCompleto(string MACAddress, Guid id,string nombre)
            : base(id,nombre)
        {
            _MACAddress = MACAddress;
        }
    }
}
