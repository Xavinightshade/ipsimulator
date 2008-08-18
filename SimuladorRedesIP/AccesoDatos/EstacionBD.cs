using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccesoDatos
{
    public partial class  Estaciones
    {
        private List<Equipos> _equipos = new List<Equipos>();

        public List<Equipos> Equipos
        {
            get { return _equipos; }
        }
        public void AgregarEquipo(Equipos equipo)
        {
            _equipos.Add(equipo);
        }
        public void AgregarEquipos(IEnumerable<Equipos> equipos)
        {
            _equipos.AddRange(equipos);
         
        }

        private List<Cables> _cables = new List<Cables>();

        public List<Cables> Cables
        {
            get { return _cables; }
        }
        public void AgregarCable(Cables cable)
        {
            _cables.Add(cable);
        }
        public void AgregarCables(IEnumerable<Cables> cables)
        {
            _cables.AddRange(cables);
        }
    }
}
