using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Siregra
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void verifyUser(string userEmail, string password)
        {
            Negocio.SupportClasses.SupportUsuario user = new Negocio.NegocioUsuario().verifyUser(userEmail, password);
            if (user != null)
            {
                Session["loginUser"] = user.NombrePersona + " " + user.ApellidoPersona;
                Session["UserId"] = user.PersonaId;
                Response.Redirect("Home.aspx");               

            }else
            {
                invalidCredentials.Visible = true;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            verifyUser(UserEmail.Text, UserPassword.Text);
        }
    }
}