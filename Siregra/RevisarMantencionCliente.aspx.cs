using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.SupportClasses;
using NEGOCIO.ObjApoyo;
using NEGOCIO.ObjNegocio;
using Negocio;
using NEGOCIO.Modelos;

namespace Siregra
{
    public partial class RevisarMantencionCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtClienteRut.Text = "";
                txtPatente.Text = "";
                txtNombrePaquete.Text = "";
                txtDescripcionPaquete.Text = "";
            }
        }

        protected void btnBuscarMantencion_Click(object sender, EventArgs e)
        {
            txtClienteRut.Enabled = false;
            txtPatente.Enabled = false;
            string errorMessage = "";
            SupportVehiculo vehiculo = new NegocioVehiculo().GetVehiculoPorRutPatente(txtClienteRut.Text, txtPatente.Text);
            if (vehiculo != null)
            {
                SupportVehiculoMantencion vehiculoMantencion = new NegocioVehiculoMantencion().GetVehiculoMantencionPorPatente(vehiculo.PATENTE);
                if (vehiculoMantencion != null)
                {
                    SupportPaqueteMantencion paqueteMantencion = new NegocioPaqueteMantencion().GetPaqueteMantencionPorId(vehiculoMantencion.PAQUETEMANTENCIONID, out errorMessage);
                    txtNombrePaquete.Text = paqueteMantencion.NombrePaqueteMantencion;
                    txtDescripcionPaquete.Text = paqueteMantencion.Descripcion;
                    gridListaRepuestosUtilizados.DataSource = new NegocioVehiculoMantencion().OriginalOrAlternativo(txtClienteRut.Text, txtPatente.Text, paqueteMantencion.PaqueteMantencionId);
                    gridListaRepuestosUtilizados.DataBind();
                    List<ModeloMantencionesPorVehiculo> lista = new NegocioVehiculoMantencion().OriginalOrAlternativo(txtClienteRut.Text, txtPatente.Text, paqueteMantencion.PaqueteMantencionId);
                    int nextPay = 0;
                    foreach (ModeloMantencionesPorVehiculo item in lista)
                    {
                        nextPay = nextPay + item.precioRepuesto;
                    }
                    lblNextPay.Text = (nextPay * 1.1).ToString();
                }else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                    "err_msg",
                    "alert('Los datos ingresados no arrojaron resultados.');",
                    true);
                    txtClienteRut.Text = "";
                    txtPatente.Text = "";
                }
            }else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
          "err_msg",
          "alert('Los datos ingresados no arrojaron resultados.');",
          true);
                txtClienteRut.Text = "";
                txtPatente.Text = "";
            }
        }
    }
}