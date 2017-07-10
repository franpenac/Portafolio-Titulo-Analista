using NEGOCIO.ObjNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Siregra
{
    public partial class RegstroRepuestos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if(new NegMantencion().ExistePatente(txtPatente.Text))
            {
                if (new NegMantencion().ExistePaquete(txtPatente.Text))
                {
                    gvAlternativo.DataSource = new NegMantencion().CargarGrillaAlternativa(txtPatente.Text);
                gvOriginal.DataSource = new NegMantencion().CargarGrillaOriginal(txtPatente.Text);
                gvAlternativo.DataBind();
                gvOriginal.DataBind();
                }
                else
                {
                    lblMensaje.Text = "El vehiculo seleccionado no ha recibido ninguna mantención";
                    mpeMensaje.Show();
                }
            }
            else
            {
                lblMensaje.Text = "No hay registro de la patente digitada";
                mpeMensaje.Show();
            }
            
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtPatente.Text = "";
            gvAlternativo.DataSource = null;
            gvAlternativo.DataBind();
            gvOriginal.DataSource = null;
            gvOriginal.DataBind();
        }
    }
}