using ServicioTecnico.BLL;
using ServicioTecnico.Utilerias;
using ServicioTecnico.VO;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ServicioTecnico.Catalogos
{
    public partial class ListaEmpleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ActualizarLista();
                }
            }
            catch (Exception)
            {

                throw;
            }



        }

        private void ActualizarLista()
        {

            List<EmpleadoVO> ListaEmpleados = BLLEmpleados.ListarEmpleados(null);
            GVEmpleados.DataSource = ListaEmpleados;
            GVEmpleados.DataBind();
        }

        protected void GVEmpleados_RowEditing(object sender, GridViewEditEventArgs e)
        {

            //antes del modo edición
            Label lblEstado = (Label)GVEmpleados.Rows[e.NewEditIndex].FindControl("lblEstado");
            string estado = lblEstado.Text;

            Label lblTipoEmpleado = (Label)GVEmpleados.Rows[e.NewEditIndex].FindControl("lblTipoEmpleado");
            string tipoEmpleado = lblTipoEmpleado.Text;

            ////Entrar en el modo edición 
            GVEmpleados.EditIndex = e.NewEditIndex;
            ActualizarLista();


            DropDownList DDLEstado = (DropDownList)GVEmpleados.Rows[e.NewEditIndex].FindControl("DDLEstado");
            UtilControls.EnumToListBox(typeof(Estado), DDLEstado, false);

            DropDownList DDLTipoEmpleado = (DropDownList)GVEmpleados.Rows[e.NewEditIndex].FindControl("DDLTipoEmpleado");
            UtilControls.EnumToListBox(typeof(TipoEmpleado), DDLTipoEmpleado, false);

            DDLEstado.SelectedValue = estado;
            DDLTipoEmpleado.SelectedValue = tipoEmpleado;
            DDLTipoEmpleado.Enabled = false;

        }

        protected void GVEmpleados_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Salir del modo edición
            GVEmpleados.EditIndex = -1;
            ActualizarLista();
        }

        protected void GVEmpleados_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string id = (GVEmpleados.DataKeys[e.RowIndex].Values["Id"]).ToString();
                string nombre = e.NewValues["Nombre"].ToString();
                string apaterno = e.NewValues["ApPaterno"].ToString();
                string amaterno = e.NewValues["ApMaterno"].ToString();
                string email = e.NewValues["Email"].ToString();
                string telefono = e.NewValues["Telefono"].ToString();
                //la función FindControl("DDLEstado"); hace referencia a encontrar el control DDLEstado en la vista
                DropDownList DDLEstado = (DropDownList)GVEmpleados.Rows[e.RowIndex].FindControl("DDLEstado");
                string ciudad = e.NewValues["Ciudad"].ToString();
                string calle = e.NewValues["Calle"].ToString();
                string numero = e.NewValues["Numero"].ToString();
                string cp = e.NewValues["CP"].ToString();
                DropDownList DDLTipoEmpleado = (DropDownList)GVEmpleados.Rows[e.RowIndex].FindControl("DDLTipoEmpleado");
                
                string result = BLLEmpleados.UpdEmpleado(int.Parse(id), nombre, apaterno, amaterno, null, email, telefono, DDLEstado.SelectedValue.ToString(), ciudad, calle, numero, cp, DDLTipoEmpleado.SelectedValue.ToString());

                if (result == "error")
                {
                    UtilControls.SweetBox("Error", "El empleado no se puede modificar debido a que está en el histórico de servicios", "error", this.Page, this.GetType());
                }
                else
                {
                    UtilControls.SweetBox("Registro modificado", "El registro se ha modificado satisfactoriamente", "success", this.Page, this.GetType());

                }

                GVEmpleados.EditIndex = -1;
                ActualizarLista();
            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("Error", ex.ToString(), "error", this.Page, this.GetType());

            }
        }

        protected void GVEmpleados_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                string idEmpleado = GVEmpleados.DataKeys[e.RowIndex].Values["Id"].ToString();
                string result = BLLEmpleados.DeleteEmpleado(int.Parse(idEmpleado));

                if (result == "error")
                {
                    UtilControls.SweetBox("Error", "El empleado no se puede borrar debido a que está en el histórico de servicios", "error", this.Page, this.GetType());
                }
                else
                {
                    UtilControls.SweetBox("Registro borrado", "El registro se ha borrado satisfactoriamente", "error", this.Page, this.GetType());
                }

                ActualizarLista();
            }
            catch (Exception ex)
            {

                UtilControls.SweetBox("Error", ex.ToString(), "error", this.Page, this.GetType());
            }
        }

        protected void GVEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());//referencia al renglon selccionado
                string id = GVEmpleados.DataKeys[index].Values["Id"].ToString();//recuperar el valor de la columna Id del renglón seleccionado
                Response.Redirect("EdicionEmpleado.aspx?id=" + id);
            }
        }
    }
}