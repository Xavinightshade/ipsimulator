using System;
using System.Collections.Generic;
using System.Text;
using RedesIP.ModelosLogicos.Datos;


namespace RedesIP.ModelosLogicos.Equipos.Componentes
{
    public interface IEnvioReciboDatos


    {
         void TransmitirFrame(Frame frame);

        void RecibirFrame(Frame frame);


    }
}
