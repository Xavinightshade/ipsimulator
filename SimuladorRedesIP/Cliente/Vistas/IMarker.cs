using System;
using System.Collections.Generic;
using System.Text;

namespace SimuladorCliente.Vistas
{
    public interface IMarker
    {
         event EventHandler<NuevoMarcadorEventArgs> NuevoMarcador;
         event EventHandler<NuevoMensajeEventArgs> NuevoMensaje;
    }
}
