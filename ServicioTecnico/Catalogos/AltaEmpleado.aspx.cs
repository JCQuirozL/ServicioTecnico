using ServicioTecnico.Utilerias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioTecnico.Catalogos
{
    public partial class AltaEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //llenar el dropdownL estado
                    UtilControls.EnumToListBox(typeof(Estado), DDLEstado, false);
                    //llenar el ddl tipo de empleado
                    UtilControls.EnumToListBox(typeof(TipoEmpleado), DDLTipoEmpleado, false);
                }
                
            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("Error", ex.ToString(), "error", this.Page, this.GetType());
                throw;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                string apaterno = txtApPaterno.Text;
                string amaterno = txtApMaterno.Text;
                DateTime fechaNac = DateTime.Parse(fechaNacimiento.Value);
                string email = txtEmail.Text;
                string telefono = txtTelefono.Text;
                string estado = DDLEstado.SelectedValue;
                string ciudad = txtCiudad.Text;
                string calle = txtCalle.Text;
                string numero = txtNumero.Text;
                string cp = txtCP.Text;
                string tipoEmpleado = DDLTipoEmpleado.SelectedValue;

                BLL.BLLEmpleados.InsertarEmpleado(nombre, apaterno, amaterno, fechaNac, email, telefono, estado, ciudad, calle, numero, cp, tipoEmpleado);

                UtilControls.SweetBoxConfirm("Registro guardado", "El registro se ha guardado satisfactoriamente", "success", "ListaEmpleados.aspx", this.Page, this.GetType());

            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("Error", ex.ToString(), "error", this.Page, this.GetType());
              
                throw;
            }
        }
    }
}