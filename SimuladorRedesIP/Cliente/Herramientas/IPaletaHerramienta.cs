using System;
namespace SimuladorCliente.Herramientas
{
    interface IPaletaHerramienta
    {
        void SetValor(int valor);
        void EstablecerEstadoSimulacion(bool pausado);
    }
}
