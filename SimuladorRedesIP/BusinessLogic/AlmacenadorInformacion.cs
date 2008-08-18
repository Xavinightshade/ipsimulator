using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.Modelos.Equipos.Componentes;
using AccesoDatos;
using RedesIP.Modelos;

namespace BusinessLogic
{
    public static class AlmacenadorInformacion
    {
        public static void AlmacenarEstacion(Estacion estacion)
        {
            Estaciones estacionBD = new Estaciones();
            estacionBD.Id = estacion.Id;
            foreach (KeyValuePair<Guid,EquipoLogico> par in estacion.Equipos)
            {
                EquipoLogico equipoLogico = par.Value;
                Equipos equipoBD = new Equipos();
                equipoBD.Id = equipoLogico.Id;
                equipoBD.TipoDeEquipo = (int)equipoLogico.TipoDeEquipo;
                equipoBD.IdEstacion = estacion.Id;
                equipoBD.X = equipoLogico.X;
                equipoBD.Y = equipoLogico.Y;
                foreach (PuertoEthernetLogico puertoLogico in equipoLogico.PuertosEthernet)
                {
                    Puertos puertoBD = new Puertos();
                    puertoBD.Id = puertoLogico.Id;
                    puertoBD.IdEquipo = equipoLogico.Id;
                    equipoBD.AgregarPuerto(puertoBD);
                }
               
            }
            foreach (KeyValuePair<Guid, CableDeRedLogico> par in estacion.Cables)
            {
                CableDeRedLogico cableLogico = par.Value;
                Cables cableBD = new Cables();
                cableBD.Id = cableLogico.Id;
                cableBD.IdPuerto1 = cableLogico.Puerto1.Id;
                cableBD.IdPuerto2 = cableLogico.Puerto2.Id;
                estacionBD.AgregarCable(cableBD);

            }
            AccesoDatosBD.GuardarEstacion(estacionBD);
        }
    }
}
