using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServicioTecnico.Utilerias
{
    public class DBConnection
    {
        private String _StringDeConexion;

        public string StringDeConexion { get => _StringDeConexion; set => _StringDeConexion = value; }

        public DBConnection(String cnxString)
        {
            this.StringDeConexion = cnxString;
        }

        public static string connectionString = ConfigurationManager.ConnectionStrings["Conn"] != null ? ConfigurationManager.ConnectionStrings["Conn"].ConnectionString : "";

        public static DataSet ExecuteQuery(SqlConnection conn, SqlTransaction tran, string spName, out int retValue, params object[] parametros)
        {
            if (parametros != null && parametros.Length % 2 != 0)
                throw new Exception("los parámetros deben venir en pares");

            SqlCommand comm = DBConnection.fillSqlCommand_Parameters(spName, parametros);
            comm.Connection = conn;

            if (tran != null)
                comm.Transaction = tran;
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            adapter.Fill(ds); //acá se ejeecuta la consulta    
            retValue = comm.Parameters["RetVal"].Value != null ? (int)comm.Parameters["RetVal"].Value : 0;
            return ds;
        }

        public static long ExecuteNonQueryGetIdentity(SqlConnection conn, SqlTransaction tran, string spName, params object[] parametros)
        {
            if (parametros != null && parametros.Length % 2 != 0)
                throw new Exception("los parámetros deben venir en pares");

            SqlCommand comm = DBConnection.fillSqlCommand_Parameters(spName, parametros);
            comm.Connection = conn;

            if (tran != null)
            {
                comm.Transaction = tran;
            }

            object objReturn = comm.ExecuteScalar();
            comm = conn.CreateCommand();
            comm.Transaction = tran;
            comm.CommandText = "SELECT @@IDENTITY";
            object val = comm.ExecuteScalar();
            long identity = long.Parse(val.ToString());
            comm.Dispose();
            return identity;
        }

        public static long ExecuteNonQueryGetIdentity(string spName, params object[] parametros)
        {
            return ExecuteGetIdentityWithStrCon(DBConnection.connectionString, spName, parametros);
        }

        public static long ExecuteGetIdentityWithStrCon(string stringDeConexxion, string spName, params Object[] parametros)
        {
            SqlConnection conn = new SqlConnection(stringDeConexxion);
            conn.Open();
            long identity = ExecuteNonQueryGetIdentity(conn, null, spName, parametros);
            conn.Close();
            return identity;
        }

        public static DataSet ExecuteDatasetWithStrCon(string stringDeConexion, string spName, out int retValue, params object[] parametros)
        {
            SqlConnection conn = new SqlConnection(stringDeConexion);
            conn.Open();
            DataSet ds = ExecuteQuery(conn, null, spName, out retValue, parametros);
            conn.Close();
            return ds;
        }

        public static DataSet ExecuteDataSet(string spName, out int retValue, params object[] parametros)
        {
            return ExecuteDatasetWithStrCon(DBConnection.connectionString, spName, out retValue, parametros);
        }

        public static DataSet ExecuteDataSet(string spName, params object[] parametros)
        {
            int retValue;
            SqlConnection conn = new SqlConnection(DBConnection.connectionString);
            conn.Open();
            DataSet ds = ExecuteQuery(conn, null, spName, out retValue, parametros);
            conn.Close();
            return ds;
        }

        public static int ExecuteNonQuery(string spName, out int retValue, params object[] parametros)
        {
            return ExecuteNonQueryWithStrCon(DBConnection.connectionString, spName, out retValue, parametros);
        }

        public static int ExecuteNonQueryWithStrCon(string stringDeConexion, string spName, out int retValue, params object[] parametros)
        {
            SqlConnection conn = new SqlConnection(stringDeConexion);
            conn.Open();
            int numRowAffected = 0;
            numRowAffected = ExecuteNonQuery(conn, null, spName, out retValue, parametros);
            conn.Close();
            return numRowAffected;
        }

        public static int ExecuteNonQuery(string spName, params object[] parametros)
        {
            int retVal;
            return ExecuteNonQuery(spName, out retVal, parametros);
        }

        public static int ExecuteNonQuery(SqlConnection conexion, SqlTransaction tran, string spName, out int retValue, params object[] parametros)
        {
            if (parametros != null && parametros.Length % 2 != 0)
                throw new Exception("los parámetros deben venir en pares");

            SqlCommand comm = DBConnection.fillSqlCommand_Parameters(spName, parametros);
            comm.Connection = conexion;

            if (tran != null)
                comm.Transaction = tran;

            int numsRowAffected = comm.ExecuteNonQuery();
            retValue = comm.Parameters["RetVal"].Value != null ? (int)comm.Parameters["RetVal"].Value : 0;

            return numsRowAffected;
        }

        public static object ExecuteScalar(string spName, out int retValue, params object[] parametros)
        {
            if (parametros != null && parametros.Length % 2 != 0)
                throw new Exception("Los parámetros deben de venir en pares");

            SqlConnection conn = new SqlConnection(DBConnection.connectionString);
            SqlCommand comm = DBConnection.fillSqlCommand_Parameters(spName, parametros);

            conn.Open();
            comm.Connection = conn;
            object objReturn = comm.ExecuteScalar();
            conn.Close();

            retValue = comm.Parameters["RetVal"].Value != null ? (int)comm.Parameters["RetVal"].Value : 0;

            return objReturn;
        }

        public static object ExecuteScalar(string strConnectionString, string storedProcedure, out int intRetValue, params object[] objParametros)
        {
            if (objParametros != null && objParametros.Length % 2 != 0)
                throw new Exception("Los parámetros deben de venir en pares");

            SqlConnection miSqlConnection = new SqlConnection(strConnectionString);

            SqlCommand miSqlCommand = DBConnection.fillSqlCommand_Parameters(storedProcedure, objParametros);

            miSqlConnection.Open();
            miSqlCommand.Connection = miSqlConnection;
            object objReturn = miSqlCommand.ExecuteScalar();

            miSqlConnection.Close();
            intRetValue = miSqlCommand.Parameters["RetVal"].Value != null ? (int)miSqlCommand.Parameters["RetVal"].Value : 0;

            return objReturn;
        }

        private static SqlCommand fillSqlCommand_Parameters(string spName, params object[] parametros)
        {
            SqlCommand comm = new SqlCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = spName;

            if (parametros != null)
            {
                for (int i = 0; i < parametros.Length; i += 2)
                {
                    comm.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                }
            }

            SqlParameter retValue = new SqlParameter("RetVal", SqlDbType.Int);

            retValue.Direction = ParameterDirection.ReturnValue;
            comm.Parameters.Add(retValue);

            return comm;
        }
    }
}