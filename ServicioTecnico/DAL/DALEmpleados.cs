using ServicioTecnico.Utilerias;
using ServicioTecnico.VO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServicioTecnico.DAL
{
    public class DALEmpleados
    {     //Variable de tipo conexion de sql para utilizarla en toda la clase
        private static SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);

        //Listar
        public static List<EmpleadoVO> ListarEmpleados(string Tipo)
        {
            try
            {//Obtener  la lista de Empleados
                //Declaramos un DataSet
                DataSet dsEmpleados = new DataSet();

                if (Tipo.Equals(null))
                {
                    //Obetenr todo los empleados de todo tipo
                    dsEmpleados = DBConnection.ExecuteDataSet("Empleados_Listar");
                }
                else
                {
                    //Obtener empleados según el tipo
                    dsEmpleados = DBConnection.ExecuteDataSet("Empleados_Listar", "@Tipo", Tipo);
                }

                //creamos la lista donde agregar cada EmpleadoVO
                List<EmpleadoVO> ListaEmpleados = new List<EmpleadoVO>();


                //Iteramos para ir agregando cada DataRow(fila) en al lista
                foreach (DataRow dr in dsEmpleados.Tables[0].Rows)
                {
                    ListaEmpleados.Add(new EmpleadoVO(dr));
                }

                //retornamos la lista llena
                return ListaEmpleados;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Insertar Empleado
        public static void InsertarEmpleado(string nombre, string appaterno, string apmaterno, string email, string telefono, string estado, string ciudad, string calle, string numero, string cp, string tipoEmpleado)
        {
            try
            {
                DBConnection.ExecuteNonQuery("Empleados_Insertar", "@Nombre", nombre, "@ApPaterno", appaterno, "@ApMaterno", apmaterno, "@Email", email, "@Telefono", telefono, "@Estado", estado, "@Ciudad", ciudad, "@Calle", calle, "@Numero", numero, "@CP", cp, "@TipoEmpleado", tipoEmpleado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Actualizar

        public static void UpdEmpleado(int id, string nombre, string appaterno, string apmaterno, string email, string telefono, string estado, string ciudad, string calle, string numero, string cp, string tipoEmpleado)
        {
            try
            {
                DBConnection.ExecuteNonQuery("Empleados_Actualizar", "@Id", id, "@Nombre", nombre, "@ApPaterno", appaterno, "@ApMaterno", apmaterno, "@Email", email, "@Telefono", telefono, "@Estado", estado, "@Ciudad", ciudad, "@Calle", calle, "@Numero", numero, "@CP", cp, "@TipoEmpleado", tipoEmpleado);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void DeleteEmpleado(int id)
        {
            try
            {
                string Query = "Empleado_Eliminar";
                SqlConnection cnx = new SqlConnection();
                SqlCommand cmd = new SqlCommand(Query, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                cnx.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }

        }


        //Pude usar el mismo procedimiento de listar pero éste lo hago por comodidad para usar
        public static bool EsTecnico(string tipo)
        {
            try
            {
                string Query = "Tecnicos_Listar";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    
                DataSet dsEmpleado = new DataSet();

                adapter.Fill(dsEmpleado);

                //Si encuentra registros queire decir que si encontró empleados que son técnicos
                if (dsEmpleado.Tables[0].Rows.Count > 0)
                {
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {

                throw;
            }
          
        }   

        public static bool EnServicio(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("En_Servicio", cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataSet dsEmpleado = new DataSet();
                adapter.Fill(dsEmpleado);

                //si encuentra registros quiere decir que encontró a aquellos empleados técnicos asignados a alguna orden de servicio (histórico)
                if (dsEmpleado.Tables[0].Rows.Count > 0)
                {
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {

                throw;
            }
            
        }


    }
}