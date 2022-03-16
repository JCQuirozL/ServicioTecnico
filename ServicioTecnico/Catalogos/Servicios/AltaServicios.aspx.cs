using ServicioTecnico.BLL;
using ServicioTecnico.Utilerias;
using ServicioTecnico.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioTecnico.Catalogos.Servicios
{

    public partial class AltaServicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarCliente();
                //Llena el dropdownL de empleados que son vendedores para recibir equipos
                LlenarEmpleado("Vendedor");
                //Llena el dropdownL de empleados que son técnicos para reparar equipos
                LlenarTecnico("Técnico");
                //cargar teléfono del cliente
                CargaTelefono();
                //llena el dropdownL de equipos q aun no están en una orden de reparación
                LlenarEquipo(false);
            }
        }

        private void LlenarEquipo(bool reparacion)
        {
            List<EquiposVO> ListaEquipos = BLLEquipos.ListaEquipos(reparacion);
            if (ListaEquipos != null)
            {
                UtilControls.FillDropDownList(DDLEquipo, DDLEquipo.DataValueField, DDLEquipo.DataTextField,ListaEquipos);
            }
        }
        private void CargaTelefono()
        {
            int idCliente = int.Parse(DDLCliente.SelectedValue);

            ClientesVO cliente = BLLClientes.GetById(idCliente);
            txtTelefono.Text = cliente.Telefono;
        }

        private void LlenarTecnico(string tipo)
        {
            List<EmpleadoVO> tecnicos = BLLEmpleados.ListarEmpleados(tipo);
            if (tecnicos != null)
            {
                UtilControls.FillDropDownList(DDLTecnico, DDLEmpleado.DataValueField, DDLEmpleado.DataTextField, tecnicos);
            }

            
        }

        private void LlenarEmpleado(string tipo)
        {
            List<EmpleadoVO> empleados = BLLEmpleados.ListarEmpleados(tipo);
            if (empleados != null)
            {
                UtilControls.FillDropDownList(DDLEmpleado, DDLEmpleado.DataValueField, DDLEmpleado.DataTextField, empleados);
            }

           
        }

        private void LlenarCliente()
        {
            List<ClientesVO> clientes = BLLClientes.ListarClientes();
            if (clientes != null)
            {
                UtilControls.FillDropDownList(DDLCliente, DDLCliente.DataValueField, DDLCliente.DataTextField, clientes);
            }
           
        }

        protected void DDLCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaTelefono();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdEmpleado = int.Parse(DDLEmpleado.SelectedValue);
                int IdCliente = int.Parse(DDLCliente.SelectedValue);
                int idEquipo = int.Parse(DDLEquipo.SelectedValue);
                int IdOrigen = 0;
                int IdDestino = 0;
                DateTime fSalida = DateTime.Parse(FSalida.Value);
                DateTime fLlegada = DateTime.Parse(FELlegada.Value);
                string observaciones = txtObservaciones.Text;

                if (Session["IdOrigen"] == null)
                {
                    //Origen se seleccionó de la lista
                    IdOrigen = int.Parse(txtOrigen.Text.Split('.').First());
                }
                else
                {
                    //Origen se capturó y se guardó
                    IdOrigen = int.Parse(Session["IdOrigen"].ToString());
                }

                if (Session["IdDestino"] == null)
                {
                    //Destino se seleccionó de la lista
                    IdDestino = int.Parse(txtDestino.Text.Split('.').First());
                }
                else
                {
                    //Destino se capturó y se guardó
                    IdDestino = int.Parse(Session["IdDestino"].ToString());
                }

                //Inserto el servicio y me retorna el id
                long IdServicio = BLLServicios.InsServicio(IdCliente, IdEmpleado, idEquipo, IdOrigen, IdDestino, fSalida, fLlegada, observaciones); // 3

                InsertarDetalleServicio(IdServicio);
                //Actualizamos el equipo para poner su estado de reparación a verdadero
                BLLEquipos.UpdEquipo(idEquipo, null, null, null, null, null, null, true);

                UtilControls.SweetBoxConfirm("Ok!", "Revisión guardada", "success", "Revisones.aspx", this.Page, this.GetType());

            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("Error!", ex.ToString(), "error", this.Page, this.GetType());



            }
        }

        protected void btnGuardarDir_Click(object sender, EventArgs e)
        {
            try
            {
                //Guardar datos 

                string calle = txtCalle.Text;
                string numero = txtNumero.Text;
                string colonia = txtColonia.Text;
                string ciudad = txtCiudad.Text;
                string estado = txtEstado.Text;
                string cp = txtCP.Text;

                //consumir el WS
                WSForAddresses.WebServiceSoapClient webServiceForAddresses = new WSForAddresses.WebServiceSoapClient();
                int idDireccion = webServiceForAddresses.insDireccion(calle, numero, colonia, ciudad, estado, cp);
                if (txtEsOD.Text == "1")
                {//Es Origen
                    Session["IdOrigen"] = idDireccion.ToString();
                    MPOrigen.Hide();

                }
                else
                {
                    //Es Destino
                    Session["IdDestino"] = idDireccion.ToString();
                    MPDestino.Hide();
                }

                LimpiarDireccion();


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void LimpiarDireccion()
        {
            txtEsOD.Text = string.Empty;
            txtCalle.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtColonia.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtCP.Text = string.Empty;
        }

        protected void btnAddRevision_Click(object sender, EventArgs e)
        {
            string miDetalle = "";
            DateTime fechaRevision = DateTime.Parse(FRevision.Value);
            int idTecnico = int.Parse(DDLTecnico.SelectedValue);
            string tecnico = DDLTecnico.SelectedItem.Text;
            string acciones = txtAcciones.Text;
            if (Session["DetalleServicio"] == null)
            {
                miDetalle = "nada";
                //Agregar el detalle
                DataTable dtDetalle = Filldt();
                dtDetalle.Rows.Add(idTecnico,tecnico, fechaRevision, acciones);
                GVRevisiones.DataSource = dtDetalle;
                GVRevisiones.DataBind();
                Session.Add("DetalleServicio", dtDetalle);
                FRevision.Value = string.Empty;
                txtAcciones.Text = "";
                //DDLTecnico.SelectedIndex = 1;

            }
            else
            {
                miDetalle = miDetalle + Session["DetalleServicio"].ToString();

                //Agregamos el detalle
                DataTable dtDetalle = (DataTable)Session["DetalleServicio"];
                dtDetalle.Rows.Add(idTecnico, tecnico, fechaRevision, acciones);
                GVRevisiones.DataSource = dtDetalle;
                GVRevisiones.DataBind();
                Session.Add("DetalleServicio", dtDetalle);
                FRevision.Value = string.Empty;
                txtAcciones.Text = "";
                //DDLTecnico.SelectedIndex = 1;



            }
        }

        private DataTable Filldt()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4]
                {
                    new DataColumn("Número Empleado",typeof(int)),
                    new DataColumn("Tecnico",typeof(string)),
                    new DataColumn("FechaRevision",typeof(DateTime)),
                    new DataColumn("Reparaciones",typeof(string))
                });

            return dt;
        }

        private void InsertarDetalleServicio(long idServicio)
        {
            //Instanciamos el webservice para insertar cargamento
            WSForAddresses.WebServiceSoapClient referencia = new WSForAddresses.WebServiceSoapClient();
            foreach (GridViewRow item in GVRevisiones.Rows)
            {
                int empleadoId = int.Parse(item.Cells[0].Text);
                DateTime fechaRev = DateTime.Parse(item.Cells[2].Text);
                string reparaciones = item.Cells[3].Text;
                string Resultado = referencia.InsertarDetalle(idServicio, empleadoId, fechaRev, reparaciones);


            }

        }
    }
}
