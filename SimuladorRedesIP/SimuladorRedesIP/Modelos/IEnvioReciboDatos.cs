using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.Modelos.Datos;

namespace RedesIP.Modelos
{
    public interface IEnvioReciboDatos


    {
         void TransmitirFrame(Frame frame);

        void RecibirFrame(Frame frame);


    }
}
