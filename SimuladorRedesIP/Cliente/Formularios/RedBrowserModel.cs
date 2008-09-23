using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SimuladorCliente.Formularios
{
    public class RedBrowserModel
    {
        private Image _imagen;

        public Image Imagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
    }
}
