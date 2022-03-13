using ServicioTecnico.BLL;
using ServicioTecnico.Utilerias;
using ServicioTecnico.VO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioTecnico.Catalogos.Equipos
{
    public partial class EdicionEquipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    Response.Redirect("ListaEquipos.aspx");
                }
                int IdEquipo = int.Parse(Request.QueryString["Id"]);
                Id.Text = IdEquipo.ToString();

                EquiposVO equipo = BLL.BLLEquipos.GetById(IdEquipo);

                if (equipo.Id == 0)
                {
                    UtilControls.SweetBoxConfirm("Error", "El equipo no se encuentra en la base de datos", "warning", "ListaEquipos.aspx", this.Page, this.GetType());
                }

                UtilControls.EnumToListBox(typeof(Marca), DDLMarca, false);
                DDLMarca.SelectedValue = equipo.Marca;
                txtColor.Text = equipo.Color;
                txtDesc.Text = equipo.Descripcion;
                txtEspec.Text = equipo.Especificaciones;
                imgFotoEquipo.ImageUrl = equipo.Foto;
                urlFoto.InnerText = equipo.Foto;
                txtSerie.Text = equipo.Serie;
            }
        }

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {
            if (subeImagen.Value != "")
            {
                //asignar a una variable el nombre del aqrchofvo seleciconado
                string FileName = Path.GetFileName(subeImagen.PostedFile.FileName);
                //validar que el archivo sea .jpg o .png
                string FileExt = Path.GetExtension(FileName).ToLower();
                if ((FileExt != ".jpg") && (FileExt != ".png"))
                {
                    UtilControls.SweetBox("Error!", "Seleccione un archivo válido de imágen", "error", this.Page, this.GetType());
                }
                else
                {
                    //Verificar que le directorio donde va,os a guarddar exista
                    string pathDir = Server.MapPath("~/Imagenes/Equipos/");
                    if (!Directory.Exists(pathDir))
                    {
                        //crea el arbol completo
                        Directory.CreateDirectory(pathDir);
                    }
                    //guardamos la imagen en el directiorio correspondienre 
                    subeImagen.PostedFile.SaveAs(pathDir + FileName);
                    string urlfoto = "/Imagenes/Equipos/" + FileName;
                    urlFoto.InnerText = urlfoto;
                    imgFotoEquipo.ImageUrl = urlfoto;
                    btnGuardar.Visible = true;
                }
            }
            else
            {
                UtilControls.SweetBox("Error!", "Debes subir un archivo", "error", this.Page, this.GetType());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdEquipo = int.Parse(Request.QueryString["Id"]);

                string marca = DDLMarca.SelectedValue.ToString();
                string color = txtColor.Text;
                string espec = txtEspec.Text;
                string desc = txtDesc.Text;
                string serie = txtSerie.Text;
                string Foto = urlFoto.InnerText;

                string result = BLLEquipos.UpdEquipo(IdEquipo, marca, color, desc, espec, serie, Foto, null);

                if (result == "Duplicado")
                {
                    UtilControls.SweetBox("Error", result + txtSerie, "error", this.Page, this.GetType());
                }
                else
                {
                    UtilControls.SweetBoxConfirm("Registro guardado", result, "success", "ListaEquipos.aspx", this.Page, this.GetType());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
