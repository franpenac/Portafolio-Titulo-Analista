using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Siregra.AdminFolder
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInSession.Text = (string)Session["loginUser"];
        }

        protected void lnkBtn_Click(object sender, EventArgs e)
        {
            Session["loginUser"] = null;
            Response.Redirect("~/LoginPage.aspx");
        }
    }
}