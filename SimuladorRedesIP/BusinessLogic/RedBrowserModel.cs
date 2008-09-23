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
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
        }
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

        public string Descripcion
        {
            get { return _nombre+Environment.NewLine+_id.ToString()+Environment.NewLine+DateTime.Now.ToString(); }
        }
        public RedBrowserModel(byte[] imagen,string nombre,Guid id)
        {
            _id = id;
            _nombre = nombre;
            using (MemoryStream ms = new MemoryStream(imagen))
            {

                _imagen = Image.FromStream(ms);

            }
        }
    }
}
