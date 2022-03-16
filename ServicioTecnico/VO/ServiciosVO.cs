using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ServicioTecnico.VO
{
    public class ServiciosVO
    {
        private int _Id;
        private string _NombreC;
        private string _APaternoC;
        private string _AMaternoC;
        private string _TelefonoC;
        private string _NombreE;
        private string _APaternoE;
        private string _AMaternoE;
        private string _Equipo;
        private string _Color;
        private string _Descripcion;
        private DateTime _FechaRec;
        private string _Origen;
        private string _Destino;
        private double _Distancia;
        private DateTime _Salida;
        private DateTime _Llegada;
        private string _Observaciones;
        private bool _Reparada;
        private string _Status;


        public ServiciosVO()
        {
            Id = 0;
            NombreC = "";
            APaternoC = "";
            AMaternoC = "";
            TelefonoC = "";
            NombreE = "";
            APaternoE = "";
            AMaternoE = "";
            Equipo = "";
            Color = "";
            Descripcion = "";
            FechaRec = DateTime.Parse("1990-01-01");
            Origen = "";
            Destino = "";
            Distancia = 0;
            Salida = DateTime.Parse("1990-01-01");
            Llegada = DateTime.Parse("1990-01-01");
            Observaciones = "";
            Reparada = false;

        }

        public ServiciosVO(DataRow dr)
        {
            Id = int.Parse(dr["Id"].ToString());
            NombreC = dr["Nombre"].ToString();
            APaternoC = dr["APaternoC"].ToString();
            AMaternoC = dr["AMaternoC"].ToString();
            TelefonoC = dr["TelefonoC"].ToString();
            NombreE = dr["NombreE"].ToString();
            APaternoE = dr["APaternoE"].ToString();
            AMaternoE = dr["AMaternoE"].ToString();
            Equipo = dr["Equipo"].ToString();
            Color = dr["Color"].ToString();
            Descripcion = dr["Descripcion"].ToString();
            FechaRec = DateTime.Parse(dr["FechaRec"].ToString());
            Salida = DateTime.Parse(dr["Salida"].ToString());
            Llegada = DateTime.Parse(dr["Llegada"].ToString());
            Origen = dr["Origen"].ToString();
            Destino = dr["Destino"].ToString();
            Distancia = int.Parse(dr["Destino"].ToString());
            Observaciones = dr["Observaciones"].ToString();
            Status = dr["Status"].ToString();
            Reparada = bool.Parse(dr["Reparada"].ToString());
        }

        public int Id { get => _Id; set => _Id = value; }
        public string NombreC { get => _NombreC; set => _NombreC = value; }
        public string APaternoC { get => _APaternoC; set => _APaternoC = value; }
        public string AMaternoC { get => _AMaternoC; set => _AMaternoC = value; }
        public string TelefonoC { get => _TelefonoC; set => _TelefonoC = value; }
        public string NombreCompletoC { get => NombreC + " " + APaternoC + " " + AMaternoC; }
        public string NombreE { get => _NombreE; set => _NombreE = value; }
        public string APaternoE { get => _APaternoE; set => _APaternoE = value; }
        public string AMaternoE { get => _AMaternoE; set => _AMaternoE = value; }
        public string NombreCompletoE { get => NombreCompletoE + " " + APaternoE + " " + AMaternoE; }
        public string EquipoC { get => Equipo + " " + Descripcion + " " + Color; }
        public DateTime FechaRec { get => _FechaRec; set => _FechaRec = value; }
        public string Origen { get => _Origen; set => _Origen = value; }
        public string Destino { get => _Destino; set => _Destino = value; }
        public double Distancia { get => _Distancia; set => _Distancia = value; }
        public DateTime Salida { get => _Salida; set => _Salida = value; }
        public DateTime Llegada { get => _Llegada; set => _Llegada = value; }
        public string Observaciones { get => _Observaciones; set => _Observaciones = value; }
        public bool Reparada { get => _Reparada; set => _Reparada = value; }
        public string Status { get => _Status; set => _Status = value; }
        public string Color { get => _Color; set => _Color = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Equipo { get => _Equipo; set => _Equipo = value; }
    }
}