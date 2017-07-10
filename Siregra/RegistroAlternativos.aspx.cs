using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO.ObjNegocio;
using Negocio;

namespace Siregra
{
    public partial class RegistroAlternativos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IniciarPagina();
            }
        }

        protected void Guardar()
        {
            if (txbCosto.Text != "")
            {
                RepuestoAlternativoC tall = new RepuestoAlternativoC();
                tall.Id = 0;
                tall.ModeloId = int.Parse(ddlModelo.SelectedValue);
                tall.ProveedorId = int.Parse(ddlProveedor.SelectedValue);
                tall.TipoProducto = int.Parse(ddlTipoProducto.SelectedValue);
                tall.RepuestoOriginalId = int.Parse(ddlTipoRecapado.SelectedValue);
                tall.Costo = int.Parse(txbCosto.ToString());
                new RepuestoAlternativoC().Insertar(tall);
                IniciarPagina();

            }

        }

        protected void Nuevo()
        {
        }
        protected void IniciarPagina()
        {
            Nuevo();

            ddlMarca.Items.Clear();
            ddlTipoRecapado.Items.Clear();
            ddlProveedor.Items.Clear();
            ddlTipoProducto.Items.Clear();

            List<MarcaC> listado = new MarcaC().ListarMarcas();
            foreach (var item in listado)
            {
                ListItem nuevo = new ListItem();
                nuevo.Value = item.Id.ToString();
                nuevo.Text = item.Nombre;
                ddlMarca.Items.Add(nuevo);
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

            List<RepuestoOriginalC> originales = new RepuestoOriginalC().Listar();
            foreach (var item in originales)
            {
                ListItem nuevo = new ListItem();
                nuevo.Value = item.Id.ToString();
                ddlTipoRecapado.Items.Add(nuevo);
            }
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
            int repuestoId = int.Parse(ddlModificar.SelectedValue);
            RepuestoAlternativoC tall = new RepuestoAlternativoC().BuscarRepuesto(repuestoId);

            repuestoId = tall.Id;
            ddlModelo.SelectedValue = tall.ModeloId.ToString();
            ddlTipoProducto.SelectedValue = tall.TipoProducto.ToString();
            ddlProveedor.SelectedValue = tall.ProveedorId.ToString();
            ddlTipoRecapado.SelectedValue = tall.RepuestoOriginalId.ToString();
            txbCosto.Text = tall.Costo.ToString();
        }

        protected string Eliminar()
        {
            string mensaje = "";
            int repuestoId = int.Parse(ddlEliminar.SelectedValue);
            RepuestoAlternativoC tall = new RepuestoAlternativoC().BuscarRepuesto(repuestoId);
            new RepuestoAlternativoC().Eliminar(repuestoId);
            IniciarPagina();
            return mensaje;
        }
    }
}