using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;

namespace BusinessLogic.Componentes
{
    public class VLan
    {
        private string _nombre;
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
        }

        public string Nombre
        {
            get { return _nombre; }
        }
        private CapaSwitcheo _capaSwitcheo;
        public List<PuertoEthernetLogicoBase> Puertos
        {
            get { return _capaSwitcheo.PuertosEthernet; }
        }
        public VLan(Guid id,string nombre, CapaSwitcheo capaSwitcheo)
        {
            _id = id;
            _nombre = nombre;
            _capaSwitcheo = capaSwitcheo;
        }
        public void AgregarPuerto(PuertoEthernetLogicoBase puerto)
        {
            _capaSwitcheo.AgregarPuerto(puerto);
        }
        public void Dispose()
        {
            _capaSwitcheo.Dispose();
        }
    }
}
