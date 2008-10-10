using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Vistas.Equipos.Componentes;
using System.Collections.ObjectModel;
using SimuladorCliente.Properties;
using RedesIP.SOA;
using System.Drawing;
using SimuladorCliente.Formularios;
using System.Windows.Forms;
using SOA.Componentes;

namespace RedesIP.Vistas.Equipos
{
    public class SwitchVLanView : EquipoView
    {
        private List<PuertoEthernetViewBase> _puertosEthernet = new List<PuertoEthernetViewBase>();

        public ReadOnlyCollection<PuertoEthernetViewBase> PuertosEthernet
        {
            get { return _puertosEthernet.AsReadOnly(); }
        }
        private List<VLanSOA> _vLans;

        public SwitchVLanView(SwitchVLanSOA equipo)
            : base(equipo.Id, equipo.Nombre, equipo.X, equipo.Y, Resources.SwitchVLan.Size.Width, Resources.SwitchVLan.Size.Height)
        {
            CrearPuertos(equipo.Puertos);
            _vLans = CloneLista(equipo.VLans);
        }

        private List<VLanSOA> CloneLista(List<VLanSOA> vLans)
        {
            List<VLanSOA> vLansCopia = new List<VLanSOA>();
            foreach (VLanSOA vLan in vLans)
            {
                VLanSOA vLanCopia = new VLanSOA(vLan.Id, vLan.Nombre);
                foreach (Guid idPuerto in vLan.IdPuertos)
                {
                    vLanCopia.IdPuertos.Add(idPuerto);
                }
                vLansCopia.Add(vLanCopia);
            }
            return vLansCopia;
            
        }

        private void CrearPuertos(IEnumerable<PuertoBaseSOA> puertos)
        {
            int i = 0;
            foreach (PuertoBaseSOA puerto in puertos)
            {

                _puertosEthernet.Add(new PuertoEthernetViewBase(puerto.Id, (i * 20) + 3, 7, this, puerto.Nombre, puerto.Habilitado));
                i++;
            }

        }


        public override System.Drawing.Image Imagen
        {
            get { return Resources.SwitchVLan; }
        }
        public override void DibujarElemento(System.Drawing.Graphics grafico)
        {
            base.DibujarElemento(grafico);
            for (int i = 0; i < _puertosEthernet.Count; i++)
            {
                _puertosEthernet[i].DibujarElemento(grafico);
            }
        }
        protected override string GetFullInfoMapa()
        {
            string tip = base.GetFullInfoMapa();
            tip += Environment.NewLine;
            foreach (VLanSOA vLan  in _vLans)
            {
                tip += " (*) VLan:  " + vLan.Nombre + Environment.NewLine +
                    "   ";
                foreach (PuertoEthernetViewBase  puerto in _puertosEthernet)
                {
                    if (vLan.IdPuertos.Contains(puerto.Id))
                    {
                        tip += puerto.Nombre + Environment.NewLine + "   ";
                    }
                }
                tip = tip.Remove(tip.Length - 4, 4);
            }
            return tip;
        }
        public override bool HitTest(int x, int y)
        {
            return base.HitTest(x, y);
        }
        protected override void OnMouseDobleClick(System.Windows.Forms.MouseEventArgs e)
        {
            using (FormularioVLans swiForm = new FormularioVLans())
            {
                List<PuertoBaseSOA> puertosTotales = new List<PuertoBaseSOA>();
                foreach (PuertoEthernetViewBase item in _puertosEthernet)
                {
                    PuertoBaseSOA puerto = new PuertoBaseSOA(item.Id, item.Nombre, item.Habilitado);
                    puertosTotales.Add(puerto);

                }
                List<PuertoBaseSOA> puertosDisponibles = CalcularPuertosDisponibles(puertosTotales);
                List<VLanSOA> vLansActuales = CloneLista(_vLans);
                swiForm.Inicializar(puertosTotales, puertosDisponibles,vLansActuales);
                if (swiForm.ShowDialog() == DialogResult.OK)
                {
                    base.Contenedor.Contrato.PeticionActualizarVLans(this.Id, vLansActuales);

                }
            }
        }



        private List<PuertoBaseSOA> CalcularPuertosDisponibles(List<PuertoBaseSOA> puertosTotales)
        {
            List<PuertoBaseSOA> puertosDisponibles = new List<PuertoBaseSOA>();
            foreach (PuertoBaseSOA puerto in puertosTotales)
            {
                bool puertoPresenteEnVLans = false;
                foreach (VLanSOA vLan in _vLans)
                {
                    if (vLan.IdPuertos.Contains(puerto.Id))
                    {
                        puertoPresenteEnVLans = true;
                        break;
                    }
                }
                if (!puertoPresenteEnVLans)
                {
                    PuertoBaseSOA puertoDisponible = new PuertoBaseSOA(puerto.Id, puerto.Nombre, puerto.Habilitado);
                    puertosDisponibles.Add(puertoDisponible);
                }
            }
            return puertosDisponibles;
        }

        internal void SetVLans(List<VLanSOA> vLansActuales)
        {
            _vLans = CloneLista(vLansActuales);
        }
    }
}
