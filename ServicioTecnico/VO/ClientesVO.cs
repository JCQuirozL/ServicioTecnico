using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ServicioTecnico.VO
{
    public class ClientesVO
    {
        private int _Id;
        private string _Nombre;
        private string _ApPaterno;
        private string _ApMaterno;
        private string _Telefono;
        private string _Email;

        public int Id { get => _Id; set => _Id = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string ApPaterno { get => _ApPaterno; set => _ApPaterno = value; }
        public string ApMaterno { get => _ApMaterno; set => _ApMaterno = value; }
        public string NombreCompletoC { get => Nombre + " " + ApPaterno + " " + ApMaterno; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public ClientesVO()
        {
            Id = 0;
            Nombre = string.Empty;
            ApPaterno = string.Empty;
            ApMaterno = string.Empty;
            Telefono = string.Empty;
            Email = string.Empty;
        }

        public ClientesVO(DataRow dr)
        {
            Id = int.Parse(dr["Id"].ToString());
            Nombre = dr["Nombre"].ToString();
            ApPaterno = dr["ApPaterno"].ToString();
            ApMaterno = dr["ApMaterno"].ToString();
            Telefono = dr["Telefono"].ToString();
            Email = dr["Email"].ToString();
        }


    }
}