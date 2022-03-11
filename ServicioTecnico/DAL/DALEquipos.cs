using ServicioTecnico.Utilerias;
using ServicioTecnico.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServicioTecnico.DAL
{
    public class DALEquipos
    {
        //LISTAR

        //ÉSTE MISMO PREOCEDIMIENTO ALMACENADO ME TRAE LOS EQUIPOS QUE ESTAN EN REPARACION
        public static List<EquiposVO> GetLstEquipos(bool? EnReparacion)
        {
            //Obtener la lista de equipos (PC, laptops, impresoras, celulares, etc)
            //Declaramos un DataSet
            try
            {
                DataSet dsEquipos;

                if (EnReparacion == null)
                {
                    dsEquipos = DBConnection.ExecuteDataSet("Equipos_Listar");
                }
                else
                {

                    //Listar los equipos en reparación
                    dsEquipos = DBConnection.ExecuteDataSet("Equipos_Listar", "@EnRep", EnReparacion);
                }


                //instanciamos un Objeto de tipo List para llenarlo con el dataset (dsEquipos) y devolverlo

                List<EquiposVO> ListaEquipos = new List<EquiposVO>();

                foreach (DataRow dataRow in dsEquipos.Tables[0].Rows)
                {
                    ListaEquipos.Add(new EquiposVO(dataRow));
                }

                return ListaEquipos;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //--Insrtar
        public static void InsertarEquipo(string Marca, string Color, string Espec, string Serie)
        {
            try
            {
                DBConnection.ExecuteNonQuery("Equipos_Insertar", "@Marca", Marca, "@Color", Color, "@Especificaciones", Espec, "@Serie", Serie);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //--Actualizar

        public static void UpdEquipo(int Id, string Marca, string Color, string Espec, string Serie, bool? EnReparacion)
        {
            try
            {
                DBConnection.ExecuteNonQuery("Equipos_Actualizar", "@Id", Id, "@Marca", Marca, "@Color", Color, "@Especificaciones", Espec, "@Serie", Serie, "@EnRep", EnReparacion);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Eliminar

        public static void DelEquipo(int Id)
        {
            try
            {
                DBConnection.ExecuteNonQuery("Equipos_Eliminar", "@Id", Id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Get EquipoById
        public static EquiposVO GetById(int Id)
        {
            try
            {
                DataSet dsEquipo = DBConnection.ExecuteDataSet("Equipos_GetById", "@Id", Id);

                if (dsEquipo.Tables[0].Rows.Count > 0)
                {
                    DataRow dataRow = dsEquipo.Tables[0].Rows[0];
                    EquiposVO equipo = new EquiposVO(dataRow);
                    return equipo;
                }
                else
                {
                    EquiposVO equipo = new EquiposVO();
                    return equipo;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Aqui no puedo usar el mismo procedimiento que checa los tecnicos en servicio porq es en diferente tabla
        public static bool EquipoEnServicio(int id)
        {

            try
            {
                SqlConnection cnx = new SqlConnection();
                SqlCommand cmd = new SqlCommand("Equipo_EnServicio", cnx);
                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dsEquipo = new DataSet();
                adapter.Fill(dsEquipo);

                //si se cumple, quiere decir que encontró equipo en reparación
                if (dsEquipo.Tables[0].Rows.Count > 0)
                {
                    return true;
                }

                return false;


            }
            catch (Exception)
            {

                throw;
            }

        }

        

    }
}