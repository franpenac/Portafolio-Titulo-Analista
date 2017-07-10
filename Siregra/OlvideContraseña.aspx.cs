using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.SupportClasses;
using System.IO;

namespace Siregra
{
    public partial class OlvideContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ForgotPasswordUserEmail.Text = "";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LoginPage.aspx");
        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            SupportUsuario user = new Negocio.NegocioUsuario().getUserByEmail(ForgotPasswordUserEmail.Text);
            if (user!=null)
            {
                    new Negocio.NegocioUsuario().sendEmail(ForgotPasswordUserEmail.Text,GetMailBody(), user.PasswordCode);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Email enviado, por favor revise su correo.');", true);
            }else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Correo no registrado');", true);
            }
            
        }

        public string GetMailBody()
        {
            string fileName = "EmailBody.aspx";
            string path = System.Web.HttpContext.Current.Server.MapPath(@"~/");
            path += fileName;
            string message = File.ReadAllText(path);
            message = message.Replace("<%@ Page Language=\"" + "C#\" AutoEventWireup=\"true\" CodeBehind=\"EmailBody.aspx.cs\" Inherits=\"Siregra.EmailBody\" %>", "");
            return message;
        }
    }
}