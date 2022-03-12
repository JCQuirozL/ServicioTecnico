using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ServicioTecnico
{
    public enum TipoEmpleado
    {
        Vendedor,
        [Description("Técnico")]
        Tecnico
    }

    public enum Marca
    {
        Lanix,
        HP,
        Lenovo,
        Acer,
        Asus,
        Samsung,
        LG,
        Apple,
        Dell,
        Alienware,
        Razer,
        MSI,
        Ensamblada
    }

    public enum Estatus
    {
        Recibida,
        [Description("En revisión")]
        Revisión,
        [Description("Para entrega")]
        Reparada,
        Entregada
    }

    public enum Estado
    {
        [Description("Baja California")]
        BajaCalifornia,
        [Description("Baja California Sur")]
        BajaCaliforniaSur,
        Campeche,
        Chiapas,
        Chihuahua,
        [Description("Ciudad de México")]
        CDMX,
        Coahuila,
        Colima,
        Durango,
        [Description("Estado de México")]
        EDOMX,
        Guanajuato,
        Guerrero,
        Hidalgo,
        Jalisco,
        [Description("Michoacán")]
        Michoacan,
        Morelos,
        Nayarit,
        [Description("Nuevo León")]
        NuevoLeon,
        Oaxaca,
        Puebla,
        Queretaro,
        [Description("Quintana Roo")]
        QuintanaRoo,
        [Description("San Luis Potosí")]
        SLP,
        Sinaloa,
        Sonora,
        Tabasco,
        Tamaulipas,
        Tlaxcala,
        Veracruz,
        [Description("Yucatán")]
        Yucatan,
        Zacatecas
    }
}