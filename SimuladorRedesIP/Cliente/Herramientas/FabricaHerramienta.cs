﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedesIP.Vistas
{
    public partial class EstacionView
    {
        public void CambiarHerramienta(Herramienta herramienta)
        {
            _herramienta = FabricaHerramienta.CrearHerramienta(herramienta, this);
        }
        private static class FabricaHerramienta
        {
            public static HerramientaBase CrearHerramienta(Herramienta herramienta,EstacionView estacion)
            {
                switch (herramienta)
                {
                    case Herramienta.Seleccion:
                        return new HerramientaSeleccion(estacion);
                    case Herramienta.CreacionEquipos:
                        return new HerramientaCreacionEquipos(estacion);
                   
                    case Herramienta.Conectar:
                        return new HerramientaConexion(estacion);
                    case Herramienta.Marcadores:
                        return new HerramientaMarcador(estacion);
                    default:
                        throw new NotImplementedException();
                }
            }
        }

    }
}