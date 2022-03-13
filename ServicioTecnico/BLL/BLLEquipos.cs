using ServicioTecnico.DAL;
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
        public static string InsertarEquipo(string Marca, string Color, string Desc, string Espec, string Serie,string Foto)
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
                    return "Duplicado";
                }
                else
                {
                    DAL.DALEquipos.InsertarEquipo(Marca, Color, Desc, Espec, Serie, Foto);
                    return "Equipo registrado";
                }

                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Actualizar
        public static string UpdEquipo(int Id, string Marca, string Color, string Desc, string Espec, string Serie,string Foto, bool? EnReparacion)
        {
            try
            {
                bool duplicado = false;

                List<EquiposVO> Equipos = DAL.DALEquipos.GetLstEquipos(false);
                foreach (EquiposVO item in Equipos)
                {
                    if (item.Serie == Serie)
                    {
                        duplicado = true;
                    }
                }
                if (duplicado)
                {
                    return "Duplicado";
                }
                else
                {
                    DAL.DALEquipos.UpdEquipo(Id, Marca, Color, Desc, Espec, Serie, Foto, EnReparacion);
                    return "Equipo registrado";
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Borrar

        public static string EliminarEquipo(int id)
        {
            try
            {
                bool enServicio = DAL.DALEquipos.EquipoEnServicio(id,"Equipos");
                List<EquiposVO> enReparacion = DAL.DALEquipos.GetLstEquipos(true);

                //si ésta condicion se cumple quiere decir que NO hay equipos en repqrqción y se pueden eliminar (lógica de negocio)
                if (enReparacion.Count == 0 && !enServicio)
                {
                    DAL.DALEquipos.DelEquipo(id);
                    return "eliminado";
                }
                else
                {
                    //El equipo esta en reparacion o servicio
                    return "error";
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public static EquiposVO GetById(int id)
        {
            return DALEquipos.GetById(id);
        }



    }
}