using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO.ObjNegocio;
using NEGOCIO.Modelos;

namespace Siregra
{
    public partial class ListaRepuestosUtilizados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            
        }

        protected void btnGenerarListaRepuestosUtilizados_Click(object sender, EventArgs e)
        {
            List<ModeloRepuestoUtilizado> list = new NEGOCIO.ObjNegocio.NegocioVehiculoMantencion().listaRepuestosPorDia(DateTime.Now);
            if (list != null)
            {
                gridListaRepuestosUtilizados.DataSource = list;
                gridListaRepuestosUtilizados.DataBind();
            }else
            {
                lblMensaje.Text = "No se han registrado ventas este día.";
                mpeMensaje.Show();
            }         
        }

        protected void btnAceptarMensaje_Click(object sender, EventArgs e)
        {
            mpeMensaje.Hide();
        }
    }
}