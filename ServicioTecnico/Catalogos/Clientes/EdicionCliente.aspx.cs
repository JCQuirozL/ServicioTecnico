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
    public partial class EdicionCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    Response.Redirect("ListaClientes.aspx");
                }

                int IdCliente = int.Parse(Request.QueryString["Id"]);
                Id.Text = IdCliente.ToString();

                ClientesVO cliente = BLLClientes.GetById(IdCliente);

                if (cliente.Id == 0)
                {
                    UtilControls.SweetBoxConfirm("Error", "El cliente no se encuentra en la base de datos", "warning", "ListaClientes.aspx", this.Page, this.GetType());
                }


                txtNombre.Text = cliente.Nombre;
                txtApPaterno.Text = cliente.ApPaterno;
                txtApMaterno.Text = cliente.ApMaterno;
                txtEmail.Text = cliente.Email;
                txtTelefono.Text = cliente.Telefono;


            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Id.Text);
                string nombre = txtNombre.Text;
                string apaterno = txtApPaterno.Text;
                string amaterno = txtApMaterno.Text;
                string email = txtEmail.Text;
                string telefono = txtTelefono.Text;

                BLLClientes.UpdCliente(id, nombre, apaterno, amaterno, telefono, email);
                UtilControls.SweetBoxConfirm("Registro guardado", "El registro se ingresó correctamente", "success", "ListaClientes.aspx", this.Page, this.GetType());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}