using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Datos;

namespace BusinessLogic.Componentes
{
    public class ControladorSesionServer : ControladorSesion
    {
        public ControladorSesionServer(string ipOrigen, string ipDestino, int puertoOrigem, int PuertoDestino)
            : base(ipOrigen, ipDestino, puertoOrigem, PuertoDestino)
        {

        }

        internal TCPSegment ProcesarSegmento(TCPSegment segmentoOrigen)
        {
            TCPSegment segmentoRetorno = null;

            if (segmentoOrigen.SYN_Flag)
            {
                segmentoRetorno = new TCPSegment(PuertoOrigen, PuertoDestino, null);
                segmentoRetorno.SYN_Flag = true;
                segmentoRetorno.ACK_Flag = true;
                segmentoRetorno.SEQ_Number = (uint)R.Next();
                segmentoRetorno.ACK_Number = segmentoOrigen.SEQ_Number+1;
                return segmentoRetorno;
            }
            return null;
        }
    }
}
