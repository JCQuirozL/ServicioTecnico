using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServicioTecnico
{
    /// <summary>
    /// Descripción breve de WebServiceDirecciones
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class WebServiceDirecciones : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        
        
        [WebMethod]
        public string[] GetDirecciones(string prefixText)
        {
            //conusme el SP Direcciones_Busqueda de la tabla Direcciones_Entrega
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Direcciones_Busqueda", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@prefijo", prefixText);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dsDirecciones = new DataSet();
            adapter.Fill(dsDirecciones);
            string[] direcciones = new string[dsDirecciones.Tables[0].Rows.Count];

            int registro = 0;

            //recorremos el dataset para obtener las direcciones

            foreach (DataRow dr in dsDirecciones.Tables[0].Rows)
            {
                direcciones.SetValue(dr["direccioncompleta"].ToString(), registro);

                registro++;
            }
            return direcciones;
        }
    }
}
