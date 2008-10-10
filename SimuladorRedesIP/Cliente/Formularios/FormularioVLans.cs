using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedesIP.Vistas.Equipos.Componentes;
using RedesIP.SOA;
using BusinessLogic;
using SOA.Componentes;

namespace SimuladorCliente.Formularios
{
    public partial class FormularioVLans : Form
    {
        public FormularioVLans()
        {
            InitializeComponent();

        }

        private List<PuertoBaseSOA> _puertosTotales;
        private BindingList<PuertoBaseSOA> _puertosDisponibles;
        private BindingList<PuertoBaseSOA> _puertosVlan = new BindingList<PuertoBaseSOA>();
        private BindingList<VLanSOA> _vLans;
        internal void Inicializar(List<PuertoBaseSOA> puertosTotales,List<PuertoBaseSOA> puertosEthernetDisponibles,List<VLanSOA> vLans)
        {
            _puertosTotales = puertosTotales;
            _puertosDisponibles = new BindingList<PuertoBaseSOA>(puertosEthernetDisponibles);
            _vLans = new BindingList<VLanSOA>(vLans);
            _vLansBS.DataSource = _vLans;
            _puertosVLanBS.DataSource = _puertosVlan;
            _puertosDisponiblesBS.DataSource = _puertosDisponibles;
            _vLansBS.CurrentChanged += new EventHandler(_vLansBS_CurrentChanged);
            LLenarPuertosActualesVLan();
            ActualizarControlesVLansDisponibles();
            
        }
        private void ActualizarControlesVLansDisponibles()
        {
            if (_vLans.Count == 0)
            {
                _btnAddMultiple.Enabled = false;
                _btnAddSingle.Enabled = false;
                _btnRemoveSingle.Enabled = false;
                _btnRemoveMultiple.Enabled = false;
                _btnEliminarVLan.Enabled = false;
                _nombrevLan.Enabled = false;
            }
            else
            {
                if (_puertosDisponibles.Count == 0)
                {
                    _btnAddMultiple.Enabled = false;
                    _btnAddSingle.Enabled = false;
                    _btnRemoveSingle.Enabled = true;
                    _btnRemoveMultiple.Enabled = true;
                }
                else
                {

                    if (_puertosVlan.Count == 0)
                    {
                        _btnAddMultiple.Enabled = true;
                        _btnAddSingle.Enabled = true;
                        _btnRemoveSingle.Enabled = false;
                        _btnRemoveMultiple.Enabled = false;
                    }
                    else
                    {
                        _btnAddMultiple.Enabled = true;
                        _btnAddSingle.Enabled = true;
                        _btnRemoveSingle.Enabled = false;
                        _btnRemoveMultiple.Enabled = false;
                    }
                    _btnAddMultiple.Enabled = true;
                    _btnAddSingle.Enabled = true;
                    _btnRemoveSingle.Enabled = true;
                    _btnRemoveMultiple.Enabled = true;
                    _btnEliminarVLan.Enabled = true;
                }

            }
        }




        void _vLansBS_CurrentChanged(object sender, EventArgs e)
        {
            LLenarPuertosActualesVLan();
        }

        private void LLenarPuertosActualesVLan()
        {
            if (_vLans.Count == 0)
                return;
            VLanSOA vlanSeleccionada = (VLanSOA)_vLansBS.Current;
            _puertosVlan.Clear();
            foreach (PuertoBaseSOA puerto in _puertosTotales)
            {
                if (vlanSeleccionada.IdPuertos.Contains(puerto.Id))
                    _puertosVlan.Add(puerto);
            }
            ActualizarControlesVLansDisponibles();
        }

        private void _Aceptar_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
        }

        private void _agregar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VLanSOA vlan = new VLanSOA(Guid.NewGuid(), "VLan_"+(_vLans.Count+1).ToString());
            _vLans.Add(vlan);
            _vLansBS.Position = _vLansBS.IndexOf(vlan);
            ActualizarControlesVLansDisponibles();
        }

        private void _btnAddSingle_Click(object sender, EventArgs e)
        {
            PuertoBaseSOA puertoDisponibleSeleccionado = (PuertoBaseSOA)_puertosDisponiblesBS.Current;
            VLanSOA vlanSeleccionada = (VLanSOA)_vLansBS.Current;
            AgregarPuertoAVLAn(puertoDisponibleSeleccionado, vlanSeleccionada);
            ActualizarControlesVLansDisponibles();

        }

        private void AgregarPuertoAVLAn(PuertoBaseSOA puertoDisponibleSeleccionado, VLanSOA vlanSeleccionada)
        {
            vlanSeleccionada.IdPuertos.Add(puertoDisponibleSeleccionado.Id);
            _puertosVlan.Add(puertoDisponibleSeleccionado);
            _puertosDisponibles.Remove(puertoDisponibleSeleccionado);
        }

        private void _btnRemoveSingle_Click(object sender, EventArgs e)
        {
            PuertoBaseSOA puertoVLanSeleccionado = (PuertoBaseSOA)_puertosVLanBS.Current;
            VLanSOA vlanSeleccionada = (VLanSOA)_vLansBS.Current;
            EliminarPuertoDeVLan(puertoVLanSeleccionado, vlanSeleccionada);

            ActualizarControlesVLansDisponibles();
        }

        private void EliminarPuertoDeVLan(PuertoBaseSOA puertoVLanSeleccionado, VLanSOA vlanSeleccionada)
        {
            vlanSeleccionada.IdPuertos.Remove(puertoVLanSeleccionado.Id);
            _puertosVlan.Remove(puertoVLanSeleccionado);
            _puertosDisponibles.Add(puertoVLanSeleccionado);
        }

        private void _eliminar_Click(object sender, EventArgs e)
        {
            VLanSOA vlanSeleccionada = (VLanSOA)_vLansBS.Current;
            foreach (PuertoBaseSOA puerto in _puertosTotales)
            {
                if (vlanSeleccionada.IdPuertos.Contains(puerto.Id))
                {
                    _puertosVlan.Remove(puerto);
                    _puertosDisponibles.Add(puerto);
                }
            }
            _vLans.Remove(vlanSeleccionada);
            ActualizarControlesVLansDisponibles();

        }

        private void _btnAddMultiple_Click(object sender, EventArgs e)
        {
            VLanSOA vlanSeleccionada = (VLanSOA)_vLansBS.Current;

            foreach (PuertoBaseSOA puerto in _puertosDisponibles.ToList())
            {
                AgregarPuertoAVLAn(puerto, vlanSeleccionada);
            }
            ActualizarControlesVLansDisponibles();

        }

        private void _btnRemoveMultiple_Click(object sender, EventArgs e)
        {
            VLanSOA vlanSeleccionada = (VLanSOA)_vLansBS.Current;
            foreach (PuertoBaseSOA puerto in _puertosVlan.ToList())
            {
                EliminarPuertoDeVLan(puerto, vlanSeleccionada);
            }
            ActualizarControlesVLansDisponibles();
        }



    }
}
