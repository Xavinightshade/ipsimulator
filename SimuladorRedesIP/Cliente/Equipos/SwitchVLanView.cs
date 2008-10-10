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
	public class SwitchVLanView:EquipoView
	{
		private List<PuertoEthernetViewBase> _puertosEthernet = new List<PuertoEthernetViewBase>();

		public ReadOnlyCollection<PuertoEthernetViewBase> PuertosEthernet
		{
			get { return _puertosEthernet.AsReadOnly(); }
		}


        public SwitchVLanView(SwitchVLanSOA equipo)
            : base(equipo.Id, equipo.Nombre, equipo.X, equipo.Y, Resources.SwitchVLan.Size.Width, Resources.SwitchVLan.Size.Height)
		{
			CrearPuertos(equipo.Puertos);
		}

		private void CrearPuertos(IEnumerable<PuertoBaseSOA> puertos)
		{
			int i = 0;
			foreach (PuertoBaseSOA puerto in puertos)
	{

        _puertosEthernet.Add(new PuertoEthernetViewBase(puerto.Id, (i * 20)+3, 7, this,puerto.Nombre,puerto.Habilitado));
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
            foreach (PuertoEthernetViewBase puerto in _puertosEthernet)
            {
                tip += Environment.NewLine + "Puerto:  " + puerto.Nombre;
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
                List<PuertoBaseSOA> puertosDisponibles = new List<PuertoBaseSOA>();
                foreach (PuertoEthernetViewBase item in _puertosEthernet)
                {
                    PuertoBaseSOA puerto = new PuertoBaseSOA(item.Id, item.Nombre, item.Habilitado);
                    puertosTotales.Add(puerto);
                    puertosDisponibles.Add(puerto);

                }
                swiForm.Inicializar(puertosTotales, puertosDisponibles, new List<VLanSOA>());
                if (swiForm.ShowDialog() == DialogResult.OK)
                {
                    //SwitchSOA swi = new SwitchSOA();
                    //swi.Id = Id;
                    //swi.Nombre = swiForm.NombreSwitch;
                    //Contenedor.Contrato.PeticionEstablecerDatosSwitch(swi);

                    //foreach (PuertoBaseSOA puertoNuevo in puertos)
                    //{
                    //    Contenedor.Contrato.PeticionEstablecerDatosPuertoBase(puertoNuevo);
                    //}

                }
            }
        }
	}
}
