using ServicioTecnico.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioTecnico.BLL
{
    public class BLLServicios
    {
        public static long InsServicio(int clienteId, int empleadoId, int equipoId, int origenId, int destinoId, DateTime fSalida, DateTime fLlegada, string observaciones)
        {
            return DALServicios.InsServicio(clienteId, empleadoId, equipoId, origenId, destinoId, fSalida, fLlegada, observaciones);
        }
    }
}