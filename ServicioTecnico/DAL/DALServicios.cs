using ServicioTecnico.Utilerias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioTecnico.DAL
{
    public class DALServicios
    {
        //Insertar ruta

        public static long InsServicio( int clienteId, int empleadoId, int equipoId, int origenId, int destinoId, DateTime fSalida, DateTime fLlegada, string observaciones)
        {
            try
            {
                return DBConnection.ExecuteNonQueryGetIdentity("Servicios_Insertar", "@ClienteId", clienteId, "@EmpleadoId", empleadoId, "@EquipoId", equipoId, "@DireccionOrigenId", origenId, "@DireccionEntregaId", destinoId, "@FechaSalida", fSalida, "@FechaLlegada", fLlegada, "@Observaciones",observaciones);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}