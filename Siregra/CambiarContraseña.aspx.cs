using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.SupportClasses;

namespace Siregra
{
    public partial class CambiarContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PasswordCode.Text = "";
                divPassword.Visible = false;
            }
 
        }

        protected void btnCheckCode_Click(object sender, EventArgs e)
        {
            SupportUsuario user = new Negocio.NegocioUsuario().GetUserByPasswordCode(PasswordCode.Text);
            if (user != null)
            {
                divPassword.Visible = true;
                PasswordCode.Enabled = false;
                btnCheckCode.Enabled = false;
            }else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Código inválido.');", true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LoginPage.aspx");
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            if (newPassword.Text.Trim() == repeatPassword.Text.Trim())
            {
                new Negocio.NegocioUsuario().changePassword(PasswordCode.Text, newPassword.Text);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Contraseña modificada.');", true);
                string newCode = new Negocio.NegocioUsuario().generatePasswordCode();
                new Negocio.NegocioUsuario().changePasswordCode(PasswordCode.Text, newCode);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Contraseñas no coinciden');", true);
            }         
        }
    }
}