using ServicioTecnico.BLL;
using ServicioTecnico.Utilerias;
using ServicioTecnico.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioTecnico.Catalogos.Equipos
{
    public partial class ListaEquipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ActualizarLista();
            }
        }

        private void ActualizarLista()
        {
            List<EquiposVO> Equipos = BLLEquipos.ListaEquipos(null);
            GVEquipos.DataSource = Equipos;
            GVEquipos.DataBind();
        }

        protected void GVEquipos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //antes del modo edición
            Label lblMarca = (Label)GVEquipos.Rows[e.NewEditIndex].FindControl("lblMarca");
            string marca = lblMarca.Text;

            GVEquipos.EditIndex = e.NewEditIndex;
            ActualizarLista();


            //Después de entrar en Editing Mode
            DropDownList DDLMarca = (DropDownList)GVEquipos.Rows[e.NewEditIndex].FindControl("DDLMarca");
            UtilControls.EnumToListBox(typeof(Marca), DDLMarca, false);

            DDLMarca.SelectedValue = marca;
        }

        protected void GVEquipos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Salir del modo edición y actualizar la lista
            GVEquipos.EditIndex = -1;
            ActualizarLista();

        }

        protected void GVEquipos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string id = GVEquipos.DataKeys[e.RowIndex].Values["Id"].ToString();
                DropDownList DDLMarca = (DropDownList)GVEquipos.Rows[e.RowIndex].FindControl("DDLMarca");
                string color = e.NewValues["Color"].ToString();
                string desc = e.NewValues["Descripcion"].ToString();
                string espec = e.NewValues["Especificaciones"].ToString();
                string serie = e.NewValues["Serie"].ToString();
                //bool enRep = bool.Parse(e.NewValues["EnReparacion"].ToString());

                BLLEquipos.UpdEquipo(int.Parse(id), DDLMarca.SelectedValue.ToString(), color,desc, espec, serie, null, null);

                UtilControls.SweetBox("Registro modificado", "Registro modificado con éxito", "success", this.Page, this.GetType());

                //Salir del editMode y actualizar el grid
                GVEquipos.EditIndex = -1;
                ActualizarLista();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GVEquipos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string id = GVEquipos.DataKeys[e.RowIndex].Values["Id"].ToString();
                string result = BLL.BLLEquipos.EliminarEquipo(int.Parse(id));

                if (result == "eliminado")
                {
                    UtilControls.SweetBox("Registro eliminado", "El registro se eliminó", "success", this.Page, this.GetType());
                }
                else
                {
                    UtilControls.SweetBox("Error", "El equipo se encuentra en reparación o asignado a una orden de servicio", "error", this.Page, this.GetType());
                }

                ActualizarLista();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GVEquipos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());//referencia al renglon selccionado
                string id = GVEquipos.DataKeys[index].Values["Id"].ToString();//recuperar el valor de la columna Id del renglón seleccionado
                //Finalmente redireccionamos al webFrom correspondiente
                Response.Redirect("EdicionEquio.aspx?Id=" + id);
            }
        }
    }
}