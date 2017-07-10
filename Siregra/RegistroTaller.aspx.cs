using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO.ObjApoyo;
using NEGOCIO.ObjNegocio;

namespace Siregra
{
    public partial class RegistroTaller : System.Web.UI.Page
    {
        protected int TallerId
        {
            get
            {
                if (ViewState["TallerId"] == null)
                {
                    ViewState["TallerId"] = 0;
                }
                int id = int.Parse(ViewState["TallerId"].ToString());
                return id;
            }
            set
            {
                ViewState["TallerId"] = value;
            }
        }

        protected int LocalizacionId
        {
            get
            {
                if (ViewState["LocalizacionId"] == null)
                {
                    ViewState["LocalizacionId"] = 0;
                }
                int id = int.Parse(ViewState["LocalizacionId"].ToString());
                return id;
            }
            set
            {
                ViewState["LocalizacionId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IniciarPagina();
            }
        }

        protected void IniciarPagina()
        {
            Nuevo();
            
            ddlRegion.Items.Clear();
            ddlEliminar.Items.Clear();
            ddlModificar.Items.Clear();

            List<RegionApoyo> listado = new LocalizacionNeg().CargarComboRegion();
            ListItem defecto = new ListItem();
            defecto.Value = "0";
            defecto.Text = "Seleccione una region";
            ddlRegion.Items.Add(defecto);
            foreach (var item in listado)
            {
                ListItem nuevo = new ListItem();
                nuevo.Value = item.RegionId.ToString();
                nuevo.Text = item.RegionNombre;
                ddlRegion.Items.Add(nuevo);
            }

            List<TallerApoyo> talleres = new TallerNeg().CargarComboTaller();
            ListItem defectoTall = new ListItem();
            defectoTall.Value = "0";
            defectoTall.Text = "Seleccione un taller";
            ddlEliminar.Items.Add(defectoTall);
            ddlModificar.Items.Add(defectoTall);
            foreach (var item in talleres)
            {
                ListItem nuevo = new ListItem();
                nuevo.Value = item.TallerId.ToString();
                nuevo.Text = item.TallerNombre;
                ddlEliminar.Items.Add(nuevo);
                ddlModificar.Items.Add(nuevo);
            }

            gvMostrar.DataSource = new TallerNeg().CargarGrilla();
            gvMostrar.DataBind();
        }

        protected bool Guardar(ref string mensaje)
        {
            
            mensaje = "";

            if (!ValidarCampos(out mensaje))
            {
                return false;
            }

            if (LocalizacionId==0)
            {
                LocalizacionApoyo loc = new LocalizacionApoyo();
                loc.LocalizacionId = LocalizacionId;
                loc.Direccion = txtDireccion.Text;
                loc.ComunaId = int.Parse(ddlComuna.SelectedValue);
                LocalizacionId = new LocalizacionNeg().Guardar(loc);
            }

            if (LocalizacionId != 0)
            {
                TallerApoyo tall = new TallerApoyo();
                tall.TallerId = TallerId;
                tall.LocalizacionId = LocalizacionId;
                tall.TallerNombre = txbNombreTaller.Text;
                if (new TallerNeg().Existe(tall.TallerNombre))
                {
                    return new TallerNeg().Guardar(tall, out mensaje);
                    
                }

            }
            mensaje = "No se ha ejecutar la operacion, Favor informarle al administrador!";
            return false;  
            
        }

        protected void Nuevo()
        {
            LocalizacionId = 0;
            TallerId = 0;

            txbNombreTaller.Text = "";
            txtDireccion.Text = "";
            
            ddlComuna.Items.Clear();
        }

        protected string Eliminar()
        {
            string mensaje = "";
            int tallerId = int.Parse(ddlEliminar.SelectedValue);
            TallerApoyo tall = new TallerNeg().BuscarTaller(tallerId);
            new TallerNeg().Eliminar(tallerId, out mensaje);
            new LocalizacionNeg().Eliminar(tall.LocalizacionId);
            IniciarPagina();
            return mensaje;
        }

        protected void Modificar()
        {
            int tallId = int.Parse(ddlModificar.SelectedValue);
            TallerApoyo tall = new TallerNeg().BuscarTaller(tallId);
            LocalizacionApoyo loc = new LocalizacionNeg().BuscarLocalizacion(tall.LocalizacionId);
            ComunaApoyo comu = new LocalizacionNeg().BuscarComuna(loc.ComunaId);

            TallerId = tall.TallerId;
            LocalizacionId = loc.LocalizacionId;
            txbNombreTaller.Text = tall.TallerNombre;
            txtDireccion.Text = loc.Direccion;
            ddlRegion.SelectedValue = comu.RegionId.ToString();

            CargarCombos(comu.RegionId);
            ddlComuna.SelectedValue = comu.ComunaId.ToString();
        }

        protected void CargarCombos(int regionId)
        {
            ddlComuna.Items.Clear();
            

            if (regionId!=0)
            {
                List<ComunaApoyo> listado2 = new LocalizacionNeg().CargarComboComuna(regionId);
                ListItem defecto = new ListItem();
                defecto.Value = "0";
                defecto.Text = "Seleccione una comuna";
                ddlComuna.Items.Add(defecto);
                foreach (var item in listado2)
                {
                    ListItem nuevo = new ListItem();
                    nuevo.Value = item.ComunaId.ToString();
                    nuevo.Text = item.ComunaNombre;
                    ddlComuna.Items.Add(nuevo);
                }
            }
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
           CargarCombos(int.Parse(ddlRegion.SelectedValue));
   
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            bool val = Guardar(ref mensaje);
            if (val)
            {
                IniciarPagina();
                MostrarMensajeRecarga(mensaje);
                btnAceptarMensaje.PostBackUrl = "RegistroTaller.aspx";
            }
            else
            {
                MostrarMensajeRecarga(mensaje);
                btnAceptarMensaje.PostBackUrl = "";
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string mensaje=Eliminar();
            MostrarMensajeRecarga(mensaje);
            btnAceptarMensaje.PostBackUrl = "~/RegistroTaller.aspx";
        }

        protected void ddlModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Modificar();
        }

        protected void MostrarMensajeRecarga(string mensaje)
        {
            this.mpeMensaje.Show();
            lblMensaje.Text = mensaje;
        }

        protected void btnAceptarMensaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroTaller.aspx");
        }

        protected bool ValidarCampos(out string mensaje)
        {
            mensaje = "";
            if (!new TallerNeg().ValidarNombre(txbNombreTaller.Text, out mensaje))
            {
                return false;
            }

            if (txbNombreTaller.Text == "")
            {
                mensaje = "Debe ingresar un nombre al taller.";
                return false;
            }

            if (txtDireccion.Text == "")
            {
                mensaje = "Debe ingresar una direccion al taller.";
                return false;
            }

            if (ddlComuna.Items.Count==0)
            {
                mensaje = "Debe seleccionar una region y comuna al taller.";
                return false;
            }

            if (ddlComuna.SelectedValue=="0")
            {
                mensaje = "Debe seleccionar una comuna al taller.";
                return false;
            }

            if (txtDireccion.Text.Length>=255)
            {
                mensaje = "La cantidad de caracteres ha sido sobrepasada, por favor digite un nombre con menos caracteres.";
                return false;

            }

            if (txbNombreTaller.Text.Length >= 255)
            {
                mensaje = "La cantidad de caracteres ha sido sobrepasada, por favor digite un nombre con menos caracteres.";
                return false;
            }

            return true;
        }
    }
}