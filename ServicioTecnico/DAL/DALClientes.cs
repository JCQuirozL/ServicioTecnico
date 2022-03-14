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
    public class DALClientes
    {
        //INsertar

        public static SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);

        //Validar en BLL
        public static void InsertarCliente(string nombre, string apaterno, string amaterno, string telefono, string email)
        {
            try
            {
                string StoredProc = "Clientes_Insertar";
                SqlCommand cmd = new SqlCommand(StoredProc, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@APaterno", apaterno);
                cmd.Parameters.AddWithValue("@AMaterno", amaterno);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                cmd.Parameters.AddWithValue("@Email", email);

                cnx.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cnx.Close();
            }

        }

        public static void UpdCliente(int id, string nombre, string apaterno, string amaterno, string telefono, string email)
        {
            try
            {
                string StoredProc = "Clientes_Actualizar";
                SqlCommand cmd = new SqlCommand(StoredProc, cnx);
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@APaterno", apaterno);
                cmd.Parameters.AddWithValue("@AMaterno", amaterno);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                cmd.Parameters.AddWithValue("@Email", email);

                cnx.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cnx.Close();
            }
        }

        public static void DelCliente(int id)
        {
            try
            {
                string StoredProc = "Cliente_Eliminar";
                SqlCommand cmd = new SqlCommand(StoredProc, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                cnx.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cnx.Close();
            }
        }

        public static List<ClientesVO> ListarClientes()
        {
            try
            {
                string StoredProc = "Clientes_Listar";
                SqlCommand cmd = new SqlCommand(StoredProc, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataSet dsClientes = new DataSet();
                adapter.Fill(dsClientes);

                List<ClientesVO> LstClientes = new List<ClientesVO>();

                foreach (DataRow dr in dsClientes.Tables[0].Rows)
                {
                    LstClientes.Add(new ClientesVO(dr));
                }

                return LstClientes;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cnx.Close();
            }
        }

        public static ClientesVO GetById(int id)
        {
            try
            {
                string StoredProc = "Clientes_GetById";
                SqlCommand cmd = new SqlCommand(StoredProc, cnx);
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dsCliente = new DataSet();
                adapter.Fill(dsCliente);

                //Encontro el cliente
                if (dsCliente.Tables[0].Rows.Count > 0)
                {
                    //crear una fila y asignarle el registro que se encontró
                    DataRow dr = dsCliente.Tables[0].Rows[0];

                    //crear el objeto cliente y llenarlo con la fila que se encontró
                    ClientesVO cliente = new ClientesVO(dr);

                    return cliente;
                }
                else
                {
                    //Devolvemos el objeto vacío
                    ClientesVO cliente = new ClientesVO();

                    return cliente;
                }


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cnx.Close();
            }
        }

        public static bool EnServicio(int id, string tabla)
        {
            try
            {
                string StoredProc = "Entidades_EnServicios";
                SqlCommand cmd = new SqlCommand(StoredProc, cnx);
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Tabla", tabla);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dsCliente = new DataSet();
                adapter.Fill(dsCliente);

                //Encontro el cliente
                if (dsCliente.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    
                    return false;
                }


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cnx.Close();
            }
        }
    }
}