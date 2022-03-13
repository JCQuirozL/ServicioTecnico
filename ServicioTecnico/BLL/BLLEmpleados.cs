﻿using ServicioTecnico.DAL;
using ServicioTecnico.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioTecnico.BLL
{
    public class BLLEmpleados
    {

        //Listar Empleados

        public static List<EmpleadoVO> ListarEmpleados(string tipo)
        {
            return DAL.DALEmpleados.ListarEmpleados(tipo);
        }

        //Insertar
        public static void InsertarEmpleado(string nombre, string appaterno, string apmaterno, DateTime fechaNac, string email, string telefono, string estado, string ciudad, string calle, string numero, string cp, string tipoEmpleado)
        {
            try
            {
                DAL.DALEmpleados.InsertarEmpleado(nombre, appaterno, apmaterno, fechaNac, email, telefono, estado, ciudad, calle, numero, cp, tipoEmpleado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Actualizar empleado
        public static string UpdEmpleado(int id, string nombre, string appaterno, string apmaterno, DateTime? fechaNac, string email, string telefono, string estado, string ciudad, string calle, string numero, string cp, string tipoEmpleado)
        {
            try
            {
                bool enServicio = DAL.DALEmpleados.EnServicio(id);

                //No se puede modificar un tipo de empleado "TECNICO" a otro tipo si ya tiene asignada una orden o detalle de servicio
                if ((tipoEmpleado != "Técnico") && (enServicio))
                {
                    //EmpleEmpleado con orden de servicio
                    return "error";
                }
                else
                {
                   DALEmpleados.UpdEmpleado(id, nombre, appaterno, apmaterno, fechaNac, email, telefono, estado, ciudad, calle, numero, cp, tipoEmpleado);

                    return "modificado";
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        //Delete
        public static string DeleteEmpleado(int id)
        {

            try
            {   //para q un empleado esté asignado a un detalle de servicio debe ser técnico
                //bool esTecnico = DAL.DALEmpleados.EsTecnico("Técnico");
                bool enServicio = DAL.DALEmpleados.EnServicio(id);
                //Si está en un detalle de servicio no lo vamos a borrar
                if (enServicio)
                {
                    return "error";
                }
                else
                {
                    DAL.DALEmpleados.DeleteEmpleado(id);
                    return "borrado";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static EmpleadoVO GetById(int id)
        {
            return DALEmpleados.GetById(id);
        }

    }
}