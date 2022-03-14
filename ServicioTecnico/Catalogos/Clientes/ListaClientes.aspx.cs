using ServicioTecnico.BLL;
using ServicioTecnico.Utilerias;
using ServicioTecnico.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioTecnico.Catalogos.Clientes
{
    public partial class ListaClientes : System.Web.UI.Page
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
            List<ClientesVO> ListaClientes = BLL.BLLClientes.ListarClientes();
            GVClientes.DataSource = ListaClientes;
            GVClientes.DataBind();
        }

        protected void GVClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Entrar en modo edición
            GVClientes.EditIndex = e.NewEditIndex;
            ActualizarLista();
        }

        protected void GVClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVClientes.EditIndex = -1;
            ActualizarLista();
        }

        protected void GVClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //indicar q el índice o la clave del registro es el id
                string id = GVClientes.DataKeys[e.RowIndex].Values["Id"].ToString();
                string nombre = e.NewValues["Nombre"].ToString();
                string apaterno = e.NewValues["ApPaterno"].ToString();
                string amaterno = e.NewValues["ApMaterno"].ToString();
                

                BLLClientes.UpdCliente(int.Parse(id), nombre, apaterno, amaterno,null,null);

                UtilControls.SweetBox("Guardado", "El registro se modificó exitosamente", "success", this.Page, this.GetType());

                GVClientes.EditIndex = -1;
                ActualizarLista();
            }
            catch (Exception)
            {

                throw;
            }
        }

       
        protected void GVClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string id = GVClientes.DataKeys[e.RowIndex].Values["Id"].ToString();

                string result = BLLClientes.DelCliente(int.Parse(id),"Clientes");

                if(result== "Registro eliminado")
                {
                    UtilControls.SweetBox("Registro borrado", result, "success", this.Page, this.GetType());
                    ActualizarLista();
                }
                else
                {
                    UtilControls.SweetBox("Error", result, "error", this.Page, this.GetType());
                    ActualizarLista();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        protected void GVClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());//referencia al renglon selccionado
                string id = GVClientes.DataKeys[index].Values["Id"].ToString();//recuperar el valor de la columna Id del renglón seleccionado
                Response.Redirect("EdicionCliente.aspx?id=" + id);
            }
        }
    }
}