using ServicioTecnico.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ServicioTecnico.BLL
{
    public class BLLEquipos
    {

        //Listar
        public static List<EquiposVO> ListaEquipos(bool? EnReparacion)
        {
            return DAL.DALEquipos.GetLstEquipos(EnReparacion);
        }

        //Insertar
        public static string InsertarEquipo(string Marca, string Color, string Espec, string Serie)
        {
            try
            {
                bool duplicado = false;

                List<EquiposVO> Equipos = DAL.DALEquipos.GetLstEquipos(false);
                foreach(EquiposVO item in Equipos)
                {
                    if (item.Serie == Serie)
                    {
                        duplicado = true;
                    }
                }
                if (duplicado)
                {
                    return "La serie del equipo ya está dada de alta";
                }
                else
                {
                    DAL.DALEquipos.InsertarEquipo(Marca, Color, Espec, Serie);
                    return "Equipo registrado";
                }

                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Actualizar
        public static void UpdEquipo(int Id, string Marca, string Color, string Espec, string Serie, bool? EnReparacion)
        {
            try
            {
                DAL.DALEquipos.UpdEquipo(Id, Marca, Color, Espec, Serie, EnReparacion);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Borrar

        public string EliminarEquipo(int id)
        {
            try
            {
                bool enServicio = DAL.DALEquipos.EquipoEnServicio(id);
                List<EquiposVO> enReparacion = DAL.DALEquipos.GetLstEquipos(true);

                //si ésta condicion se cumple quiere decir que NO hay equipos en repqrqción y no se pueden eliminar (lógica de negocio)
                if (enReparacion.Count == 0 && !enServicio)
                {
                    DAL.DALEquipos.DelEquipo(id);
                    return "Equipo eliminado";
                }
                else
                {
                    return "El equipo esta en reparacion o servicio";
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }




    }
}