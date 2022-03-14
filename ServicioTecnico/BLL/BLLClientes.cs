using ServicioTecnico.DAL;
using ServicioTecnico.Utilerias;
using ServicioTecnico.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioTecnico.BLL
{
    public class BLLClientes
    {
        //Insertar
        public static void InsertarCliente(string nombre, string apaterno, string amaterno, string telefono, string email)
        {
            DALClientes.InsertarCliente(nombre, apaterno, amaterno, telefono, email);
        }

        //Actualizar
        public static void UpdCliente(int id, string nombre, string apaterno, string amaterno, string telefono, string email)
        {
            DALClientes.UpdCliente(id, nombre, apaterno, amaterno, telefono, email);
        }

        public static string DelCliente(int id, string tabla)
        {
            try
            {
                bool enServicio = DALClientes.EnServicio(id, tabla);

                //si hay un cliente asignado al histórico de tabla servicios no se puede eliminar, por integridad referencial
                if (enServicio)
                {
                    return "No se puede borrar cliente, ya ha sido asignado anteriormente a algún servicio";
                }
                else
                {
                    DALClientes.DelCliente(id);
                    return "Registro eliminado";
                }

            }
            catch (Exception ex)
            {
                return ex.ToString();
                throw;
            }
        }

        //Listar
        public static List<ClientesVO> ListarClientes()
        {
            return DALClientes.ListarClientes();
        }

        public static ClientesVO GetById(int id)
        {
            return DALClientes.GetById(id);
        }
    }
}