using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ServicioTecnico.VO
{
    public class EquiposVO
    {
        private int _Id;
        private string _Marca;
        private string _Color;
        private string _Descripcion;
        private string _Especificaciones;
        private string _Foto;
        private string _Serie;
        private bool _EnReparacion;

        public EquiposVO()
        {
            Id = 0;
            Marca = string.Empty;
            Color = string.Empty;
            Descripcion = string.Empty;
            Especificaciones = string.Empty;
            Foto = string.Empty;
            Serie = string.Empty;
            EnReparacion = false;
        }

        public EquiposVO(DataRow dataRow)
        {
            Id = int.Parse(dataRow["Id"].ToString());
            Marca = dataRow["Marca"].ToString();
            Color = dataRow["Color"].ToString();
            Descripcion = dataRow["Descripcion"].ToString();
            Especificaciones = dataRow["Especificaciones"].ToString();
            Serie = dataRow["Serie"].ToString();
            Foto = dataRow["Foto"].ToString();
            EnReparacion = bool.Parse(dataRow["EnReparacion"].ToString());
        }

        public int Id { get => _Id; set => _Id = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
        public string Color { get => _Color; set => _Color = value; }
        public string Especificaciones { get => _Especificaciones; set => _Especificaciones = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Foto { get => _Foto; set => _Foto = value; }
        public bool EnReparacion { get => _EnReparacion; set => _EnReparacion = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
    }
}