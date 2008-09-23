using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace SimuladorCliente.Formularios
{
    public class RedBrowserModel
    {
        private Image _imagen;

        public Image Imagen
        {
            get { return _imagen; }
        }
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
        }
        public RedBrowserModel(byte[] imagen,string nombre)
        {
            _nombre = nombre;
            using (MemoryStream ms = new MemoryStream(imagen))
            {

                _imagen = Image.FromStream(ms);

            }
        }
    }
}
