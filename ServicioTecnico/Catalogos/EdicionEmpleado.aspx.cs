using ServicioTecnico.BLL;
using ServicioTecnico.Utilerias;
using ServicioTecnico.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioTecnico.Catalogos
{
    public partial class EdicionEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["Id"] == null)
                {
                    Response.Redirect("ListaEmpleados.aspx");
                }

                int IdEmpleado = int.Parse(Request.QueryString["Id"]);
                Id.Text = IdEmpleado.ToString();

                EmpleadoVO empleado = BLLEmpleados.GetById(IdEmpleado);

                if (empleado.Id == 0)
                {
                    UtilControls.SweetBoxConfirm("Error", "El empleado no se encuentra en la base de datos", "warning", "ListaEmpleados.aspx", this.Page, this.GetType());
                }

                UtilControls.EnumToListBox(typeof(Estado), DDLEstado, false);
                UtilControls.EnumToListBox(typeof(TipoEmpleado), DDLTipoEmpleado, false);

                txtNombre.Text = empleado.Nombre;
                txtApPaterno.Text = empleado.ApPaterno;
                txtApMaterno.Text = empleado.ApMaterno;
                fechaNacimiento.Value = empleado.FechaNacimiento.ToString("dd/MM/yyyy");
                txtEmail.Text = empleado.Email;
                txtTelefono.Text = empleado.Telefono;
                DDLEstado.SelectedValue = empleado.Estado.ToString();
                txtCiudad.Text = empleado.Ciudad;
                txtCalle.Text = empleado.Calle;
                txtNumero.Text = empleado.Numero;
                txtCP.Text = empleado.CP;
                DDLTipoEmpleado.SelectedValue = empleado.TipoEmpleado.ToString();


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
                DateTime fechaNac = DateTime.Parse(fechaNacimiento.Value);
                string email = txtEmail.Text;
                string telefono = txtTelefono.Text;
                string estado = DDLEstado.SelectedValue.ToString();
                string ciudad = txtCiudad.Text;
                string calle = txtCalle.Text;
                string numero = txtNumero.Text;
                string cp = txtCP.Text;
                string tipoEmpleado = DDLTipoEmpleado.SelectedValue.ToString();

                string restultado = BLLEmpleados.UpdEmpleado(id, nombre, apaterno, amaterno, fechaNac, email, telefono, estado, ciudad, calle, numero, cp, tipoEmpleado);

                if (restultado == "error")
                {
                    UtilControls.SweetBox("Error", "El empleado está asignado a una orden de servicio", "error", this.Page, this.GetType());

                }
                else if (restultado == "modificado")
                {
                    UtilControls.SweetBoxConfirm("Registro modificado", "El registro se ha modificado satisfactoriamente", "success", "ListaEmpleados.aspx", this.Page, this.GetType());

                }

            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("Error", ex.ToString(), "error", this.Page, this.GetType());

                throw;
            }
        }
    }
}