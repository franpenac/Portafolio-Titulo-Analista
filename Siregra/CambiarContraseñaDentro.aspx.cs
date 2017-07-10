using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.SupportClasses;

namespace Siregra
{
    public partial class CambiarContraseñaDentro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CleanControls();
            }
        }

        protected void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            SupportUsuario user = new Negocio.NegocioUsuario().getUserById((int)Session["UserId"]);
            if (txtActualContraseña.Text == user.PasswordPersona)
            {
                if (txtNuevaContraseña.Text == txtRepetirContraseña.Text)
                {
                    new Negocio.NegocioUsuario().ChangeUserPassword(user.PersonaId, txtNuevaContraseña.Text);
                    lblMensaje.Text = "Contraseña modificada con éxito.";
                    mpeMensaje.Show();
                    CleanControls();
                }
                else
                {
                    lblMensaje.Text = "Las contraseñas no coinciden.";
                    mpeMensaje.Show();
                    CleanControls();
                }
            }else
            {
                lblMensaje.Text = "Contraseña actual inválida.";
                mpeMensaje.Show();
                CleanControls();
            }
        }

        protected void btnAceptarMensaje_Click(object sender, EventArgs e)
        {
            mpeMensaje.Hide();
        }

        public void CleanControls()
        {
            txtActualContraseña.Text = "";
            txtNuevaContraseña.Text = "";
            txtRepetirContraseña.Text = "";
        }
    }
}