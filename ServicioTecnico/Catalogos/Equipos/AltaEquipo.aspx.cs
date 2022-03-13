using ServicioTecnico.BLL;
using ServicioTecnico.Utilerias;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioTecnico.Catalogos.Equipos
{
    public partial class AltaEquipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UtilControls.EnumToListBox(typeof(Marca), DDLMarca, false);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string marca = DDLMarca.SelectedValue.ToString();
                string color = txtColor.Text;
                string espec = txtEspec.Text;
                string desc = txtDesc.Text;
                string serie = txtSerie.Text;
                string Foto = urlFoto.InnerText;

                string result = BLLEquipos.InsertarEquipo(marca, color, desc, espec, serie, Foto);

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

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {
            //validar que el usuario haya seleccionadop una imaden
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
    }
}