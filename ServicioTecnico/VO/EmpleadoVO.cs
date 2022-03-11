using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ServicioTecnico.VO
{
    public class EmpleadoVO
    {
        private int _Id;
        private string _Nombre;
        private string _ApPaterno;
        private string _ApMaterno;
        private string _Email;
        private string _Telefono;
        private string _Estado;
        private string _Ciudad;
        private string _Calle;
        private string _Numero;
        private string _CP;
        private string _TipoEmpleado;

        //Encapsulación POO
        public int Id { get => _Id; set => _Id = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string ApPaterno { get => _ApPaterno; set => _ApPaterno = value; }
        public string ApMaterno { get => _ApMaterno; set => _ApMaterno = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public string Ciudad { get => _Ciudad; set => _Ciudad = value; }
        public string Calle { get => _Calle; set => _Calle = value; }
        public string Numero { get => _Numero; set => _Numero = value; }
        public string CP { get => _CP; set => _CP = value; }
        public string TipoEmpleado { get => _TipoEmpleado; set => _TipoEmpleado = value; }
        public EmpleadoVO()
        {
            Id = 0;
            Nombre = string.Empty;
            ApPaterno = string.Empty;
            ApMaterno = string.Empty;
            Email = string.Empty;
            Telefono = string.Empty;
            Estado = string.Empty;
            Ciudad = string.Empty;
            Calle = string.Empty;
            Numero = string.Empty;
            CP = string.Empty;
            TipoEmpleado = string.Empty;

        }

        public EmpleadoVO(DataRow dataRow)
        {
            Id = int.Parse(dataRow["Id"].ToString());
            Nombre = dataRow["Nombre"].ToString();
            ApPaterno= dataRow["ApPaterno"].ToString();
            ApMaterno = dataRow["ApMaterno"].ToString();
            Email = dataRow["Email"].ToString();
            Telefono = dataRow["Telefono"].ToString();
            Estado = dataRow["Estado"].ToString();
            Ciudad = dataRow["Ciudad"].ToString();
            Calle = dataRow["Calle"].ToString();
            Numero = dataRow["Numero"].ToString();
            CP = dataRow["CP"].ToString();
            TipoEmpleado = dataRow["TipoEmpleado"].ToString();

        }


    }
}