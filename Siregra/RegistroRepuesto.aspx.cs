using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO.ObjNegocio;
using Negocio;
using NEGOCIO.ObjApoyo;

namespace Siregra
{
    public partial class RegistroRepuesto : System.Web.UI.Page
    {
        protected int RepuestoId
        {
            get
            {
                if (ViewState["RepuestoId"] == null)
                {
                    ViewState["RepuestoId"] = 0;
                }
                int id = int.Parse(ViewState["RepuestoId"].ToString());
                return id;
            }
            set
            {
                ViewState["RepuestoId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IniciarPagina();
            }
        }

        protected void Nuevo()
        {

            txbNombreRepuesto.Text = "";
            

            
        }

        protected void IniciarPagina()
        {
            Nuevo();

            ddlMarca.Items.Clear();
            ddlModelo.Items.Clear();
            ddlProveedor.Items.Clear();
            ddlTipoProducto.Items.Clear();
            ddlEliminar.Items.Clear();
            ddlModificar.Items.Clear();

            List<MarcaC> listado = new MarcaC().ListarMarcas();
            foreach (var item in listado)
            {
                ListItem nuevo = new ListItem();
                nuevo.Value = item.Id.ToString();
                nuevo.Text = item.Nombre;
                ddlMarca.Items.Add(nuevo);
            }
            
            List<ModeloC> modelos = new ModeloC().ListarModelos();
            foreach (var item in modelos)
            {
                ListItem nuevo = new ListItem();
                nuevo.Value = item.Id.ToString();
                nuevo.Text = item.MarcaId.ToString();
                nuevo.Text = item.Nombre;
                ddlModelo.Items.Add(nuevo);
            }

            List<ProveedorC> proveedores = new ProveedorC().ListarProveedores();
            foreach (var item in proveedores)
            {
                ListItem nuevo = new ListItem();
                nuevo.Value = item.Id.ToString();
                nuevo.Text = item.Nombre;
                ddlProveedor.Items.Add(nuevo);
            }

            List<TipoProductoC> tipos = new TipoProductoC().ListarTipoProductos();
            foreach (var item in tipos)
            {
                ListItem nuevo = new ListItem();
                nuevo.Value = item.Id.ToString();
                nuevo.Text = item.Nombre;
                ddlTipoProducto.Items.Add(nuevo);
            }

            List<RepuestoOriginalApoyo> repuestos = new NegocioRepuestoOriginal().CargarComboRepuesto();
            ListItem defectoTall = new ListItem();
            defectoTall.Value = "0";
            defectoTall.Text = "Seleccione un Repuesto";
            ddlEliminar.Items.Add(defectoTall);
            ddlModificar.Items.Add(defectoTall);
            foreach (var item in repuestos)
            {
                ListItem nuevo = new ListItem();
                nuevo.Value = item.RepuestoOriginalId.ToString();
                nuevo.Text = new NegocioRepuestoOriginal().ModeloPorIdRepuesto(item.ModeloId);
                ddlEliminar.Items.Add(nuevo);
                ddlModificar.Items.Add(nuevo);
            }

            gvMostrar.DataSource = new NegocioRepuestoOriginal().CargarGrilla();
            gvMostrar.DataBind();
        }

        protected void Guardar()
        {
            if (txbNombreRepuesto.Text != "")
            {
                RepuestoOriginalC tall = new RepuestoOriginalC();
                tall.Id = 0;
                tall.ModeloId = int.Parse(ddlModelo.SelectedValue);
                tall.ProveedorId = int.Parse(ddlProveedor.SelectedValue);
                tall.TipoProductoId = int.Parse(ddlTipoProducto.SelectedValue);
                tall.Costo = decimal.Parse(txbNombreRepuesto.Text.Trim());

                new RepuestoOriginalC().Insertar(tall);
                IniciarPagina();

            }

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
            Page.Response.Redirect("RegistroRepuesto.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        protected void ddlModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Modificar();
        }

        protected void Modificar()
        {
            int tallId = int.Parse(ddlModificar.SelectedValue);
            RepuestoOriginalApoyo tall = new NegocioRepuestoOriginal().BuscarTaller(tallId);

            RepuestoId = tall.RepuestoOriginalId;
            ddlMarca.SelectedValue = tall.Marca;
            ddlModelo.SelectedValue = tall.ModeloId.ToString();
            ddlTipoProducto.SelectedValue = tall.TipoProductoId.ToString();
            ddlProveedor.SelectedValue = tall.ProveedorId.ToString();
            txbNombreRepuesto.Text = tall.Costo.ToString();
        }

        protected string Eliminar()
        {
            string mensaje = "";
            int tallerId = int.Parse(ddlEliminar.SelectedValue);
            RepuestoOriginalApoyo tall = new NegocioRepuestoOriginal().BuscarTaller(tallerId);
            new NegocioRepuestoOriginal().Eliminar(tallerId);
            IniciarPagina();
            return mensaje;
        }

    }
}