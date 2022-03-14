using ServicioTecnico.BLL;
using ServicioTecnico.Utilerias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioTecnico.Catalogos.Clientes
{
    public partial class AltaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                string apaterno = txtApPaterno.Text;
                string amaterno = txtApMaterno.Text;
                string email = txtEmail.Text;
                string telefono = txtTelefono.Text;

                BLLClientes.InsertarCliente(nombre, apaterno, amaterno, telefono, email);
                UtilControls.SweetBoxConfirm("Registro guardado", "El registro se ingresó correctamente", "success", "ListaClientes.aspx", this.Page, this.GetType());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}