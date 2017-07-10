using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.SupportClasses;

namespace Siregra
{
    public partial class RegistroPaqueteMantencionPage : System.Web.UI.Page
    {
        List<SupportRepuestoOriginal> ListaRepuestosOriginales = new List<SupportRepuestoOriginal>();
        List<SupportRepuestoAlternativo> ListaRepuestosAlternativos = new List<SupportRepuestoAlternativo>();
        public void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if ((List<SupportRepuestoOriginal>)ViewState["ListaRepuestosOriginalesGuardados"] == null)
                {
                    ListaRepuestosOriginales = new List<SupportRepuestoOriginal>();
                }
                else
                {
                    ListaRepuestosOriginales = (List<SupportRepuestoOriginal>)ViewState["ListaRepuestosOriginalesGuardados"];
                }
                if ((List<SupportRepuestoAlternativo>)ViewState["ListaRepuestosAlternativosGuardados"] == null)
                {
                    ListaRepuestosAlternativos = new List<SupportRepuestoAlternativo>();
                } else
                {
                    ListaRepuestosAlternativos = (List<SupportRepuestoAlternativo>)ViewState["ListaRepuestosAlternativosGuardados"];
                }

                if (rbOriginales.Checked)
                {
                    ddlProductosOriginales.Enabled = true;
                    ddlProductosAlternativos.Enabled = false;
                    btnAgregarProductoAlternativo.Visible = false;
                    txtCantidadAlternativos.Enabled = false;
                }
                else if (rbAlternativos.Checked)
                {
                    ddlProductosAlternativos.Enabled = true;
                    ddlProductosOriginales.Enabled = false;
                    btnAgregarProductoOriginal.Visible = false;
                    txtCantidadOriginales.Enabled = false;
                }

            }
            InitialControls();
        }

        protected void InitialControls()
        {
            if (!IsPostBack)
            {
                ddlProductosOriginales.Enabled = false;
                ddlProductosAlternativos.Enabled = false;
                btnAgregarProductoOriginal.Visible = false;
                btnAgregarProductoAlternativo.Visible = false;
                txtCantidadOriginales.Visible = false;
                txtCantidadAlternativos.Visible = false;
                lblCantidadAlternativos.Visible = false;
                lblCantidadOriginal.Visible = false;
            }
            chargePaquetesGrid();
        }

        protected void btnCrearPaquete_Click(object sender, EventArgs e)
        {
            if (txtNombrePaquete.Text.Trim() != "")
            {
                if (txtDescripcion.InnerText.Trim() != "")
                {

                    if (ddlDuracionDias.SelectedValue != "0")
                    {
                        if (gridRepuestosAgregados.Rows.Count > 0)
                        {

                            string errorMessage = "";
                            SupportPaqueteMantencion paqueteCrear = new Negocio.NegocioPaqueteMantencion().GetPaqueteMantencionPorNombre(txtNombrePaquete.Text, out errorMessage);
                            if (paqueteCrear == null)
                            {
                                SupportPaqueteMantencion newPaquete = new SupportPaqueteMantencion();
                                newPaquete.PaqueteMantencionId = 0;
                                newPaquete.NombrePaqueteMantencion = txtNombrePaquete.Text;
                                newPaquete.CostoTotal = int.Parse(txtCostoTotal.Text);
                                newPaquete.DuracionDias = int.Parse(ddlDuracionDias.SelectedValue);
                                newPaquete.Descripcion = txtDescripcion.InnerText;
                                new Negocio.NegocioPaqueteMantencion().Save(newPaquete);
                            }
                            else
                            {
                                lblMensaje.Text = "Paquete con este nombre ya existe en los registros.";
                                mpeMensaje.Show();
                            }
                            SupportPaqueteMantencion paqueteCreado = new Negocio.NegocioPaqueteMantencion().GetPaqueteMantencionPorNombre(txtNombrePaquete.Text, out errorMessage);
                            foreach (SupportRepuestoOriginal item in ListaRepuestosOriginales)
                            {
                                SupportRepuestoOriginalUtilizado prodU = new SupportRepuestoOriginalUtilizado();
                                prodU.RepuestoOriginalUtilizadoId = 0;
                                prodU.RepuestoOriginalId = item.RepuestoOriginalId;
                                prodU.PaqueteMantencionId = paqueteCreado.PaqueteMantencionId;
                                prodU.Cantidad = item.Cantidad;
                                new Negocio.NegocioRepuestoOriginalUtilizado().Save(prodU);
                            }

                            foreach (SupportRepuestoAlternativo item in ListaRepuestosAlternativos)
                            {
                                SupportRepuestoAlternativoUtilizado prodU = new SupportRepuestoAlternativoUtilizado();
                                prodU.RepuestoAlternativoUtilizadoId = 0;
                                prodU.RepuestoAlternativoId = item.RepuestoAlternativoId;
                                prodU.PaqueteMantencionId = paqueteCreado.PaqueteMantencionId;
                                prodU.Cantidad = item.Cantidad;
                                new Negocio.NegocioRepuestoAlternativoUtilizado().Save(prodU);
                            }
                            lblMensaje.Text = "Se ha creado el paquete de mantención.";
                            mpeMensaje.Show();
                            LimpiarControles();
                            gridRepuestosAgregados.Visible = false;
                            gridRepuestosAgregados.DataSource = null;
                            gridRepuestosAgregados.DataBind();
                            chargePaquetesGrid();
                        }
                        else
                        {
                            lblMensaje.Text = "Debe agregar a lo menos 1 producto para el paquete de mantención.";
                            mpeMensaje.Show();
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "Debe seleccionar la duración en dias.";
                        mpeMensaje.Show();
                    }
                }
                else
                {
                    lblMensaje.Text = "Debe agregar una descripción del paquete de mantención.";
                    mpeMensaje.Show();
                }
            }
            else
            {
                lblMensaje.Text = "Debe agregar nombre al paquete de mantención.";
                mpeMensaje.Show();
            }
        }

        public void btnAgregarProductoOriginal_Click(object sender, EventArgs e)
        {
            if (txtCantidadOriginales.Text.Trim() != "" && ddlProductosOriginales.SelectedValue != "0")
            {
                string errorMessage = "";
                SupportRepuestoOriginal repuestoAgregar = new SupportRepuestoOriginal();
                int repId = int.Parse(ddlProductosOriginales.SelectedValue);
                SupportRepuestoOriginal rep = new Negocio.NegocioRepuestoOriginal().GetRepuestoOriginalPorId(repId, out errorMessage);
                repuestoAgregar.RepuestoOriginalId = repId;
                repuestoAgregar.ModeloId = rep.ModeloId;
                repuestoAgregar.ProveedorId = rep.ProveedorId;
                repuestoAgregar.TipoProductoId = rep.TipoProductoId;
                repuestoAgregar.Cantidad = int.Parse(txtCantidadOriginales.Text);
                repuestoAgregar.Costo = rep.Costo;
                repuestoAgregar.ProductoNombre = rep.ProductoNombre;
                bool existe = false;
                foreach (SupportRepuestoOriginal item in ListaRepuestosOriginales)
                {
                    if (repId == item.RepuestoOriginalId)
                    {
                        existe = true;
                    }
                }
                if (existe)
                {
                    lblMensaje.Text = "El producto ya se ha agregado anteriormente.";
                    mpeMensaje.Show();
                }
                else
                {
                    ListaRepuestosOriginales.Add(repuestoAgregar);
                    ViewState["ListaRepuestosOriginalesGuardados"] = ListaRepuestosOriginales;
                    int costotoTotal = 0;
                    foreach (SupportRepuestoOriginal item in ListaRepuestosOriginales)
                    {
                        costotoTotal = costotoTotal + item.Costo * item.Cantidad;
                    }
                    txtCostoTotal.Text = costotoTotal.ToString();
                }
                ddlProductosOriginales.ClearSelection();
                txtCantidadOriginales.Text = "";
                cargarGridProductosOriginales(ListaRepuestosOriginales);
            }
            else
            {
                lblMensaje.Text = "Debe agregar Producto/Cantidad.";
                mpeMensaje.Show();
            }
        }

        protected void btnAgregarProductoAlternativo_Click(object sender, EventArgs e)
        {
            if (txtCantidadAlternativos.Text.Trim() != "" && ddlProductosAlternativos.SelectedValue != "0")
            {
                string errorMessage = "";
                SupportRepuestoAlternativo repuestoAgregar = new SupportRepuestoAlternativo();
                int repId = int.Parse(ddlProductosAlternativos.SelectedValue);
                SupportRepuestoAlternativo rep = new Negocio.NegocioRepuestoAlternativo().GetRepuestoAlternativoPorId(repId, out errorMessage);
                repuestoAgregar.RepuestoAlternativoId = repId;
                repuestoAgregar.ModeloId = rep.ModeloId;
                repuestoAgregar.ProveedorId = rep.ProveedorId;
                repuestoAgregar.TipoProductoId = rep.TipoProductoId;
                repuestoAgregar.Cantidad = int.Parse(txtCantidadAlternativos.Text);
                repuestoAgregar.Costo = rep.Costo;
                repuestoAgregar.ProductoNombre = rep.ProductoNombre;
                bool existe = false;
                foreach (SupportRepuestoAlternativo item in ListaRepuestosAlternativos)
                {
                    if (repId == item.RepuestoAlternativoId)
                    {
                        existe = true;
                    }
                }
                if (existe)
                {
                    lblMensaje.Text = "El producto ya ha sido agregado anteriormente.";
                    mpeMensaje.Show();
                }
                else
                {
                    ListaRepuestosAlternativos.Add(repuestoAgregar);
                    ViewState["ListaRepuestosAlternativosGuardados"] = ListaRepuestosAlternativos;
                    int costotoTotal = 0;
                    foreach (SupportRepuestoAlternativo item in ListaRepuestosAlternativos)
                    {
                        costotoTotal = costotoTotal + item.Costo * item.Cantidad;
                    }
                    txtCostoTotal.Text = costotoTotal.ToString();
                }
                ddlProductosAlternativos.ClearSelection();
                txtCantidadAlternativos.Text = "";
                cargarGridProductosAlternativos(ListaRepuestosAlternativos);

            }
            else
            {
                lblMensaje.Text = "Debe agregar Producto/Cantidad.";
                mpeMensaje.Show();
            }
        }

        protected void rbOriginales_CheckedChanged(object sender, EventArgs e)
        {
            string errorMessage = "";
            ddlProductosOriginales.DataSource = new Negocio.NegocioRepuestoOriginal().GetRepuestosOriginales(out errorMessage);
            ddlProductosOriginales.DataTextField = "ProductoNombre";
            ddlProductosOriginales.DataValueField = "RepuestoOriginalId";
            ddlProductosOriginales.DataBind();
            ddlProductosOriginales.Enabled = true;
            btnAgregarProductoOriginal.Visible = true;
            ddlProductosAlternativos.Enabled = false;
            rbAlternativos.Enabled = false;
            btnAgregarProductoAlternativo.Visible = false;
            txtCantidadOriginales.Visible = true ;
            txtCantidadOriginales.Enabled = true;
            lblCantidadOriginal.Visible = true;
            txtCantidadAlternativos.Enabled = false;
            txtCantidadAlternativos.Text = "";
        }

        protected void rbAlternativos_CheckedChanged(object sender, EventArgs e)
        {
            string errorMessage = "";
            ddlProductosAlternativos.DataSource = new Negocio.NegocioRepuestoAlternativo().GetRepuestosAlternativos(out errorMessage);
            ddlProductosAlternativos.DataTextField = "ProductoNombre";
            ddlProductosAlternativos.DataValueField = "RepuestoAlternativoId";
            ddlProductosAlternativos.DataBind();
            ddlProductosAlternativos.Enabled = true;
            btnAgregarProductoAlternativo.Visible = true;
            ddlProductosOriginales.Enabled = false;
            btnAgregarProductoOriginal.Visible = false;
            rbOriginales.Enabled = false;
            txtCantidadAlternativos.Visible = true;
            txtCantidadAlternativos.Enabled = true;
            lblCantidadAlternativos.Visible = true;
            txtCantidadOriginales.Enabled = false;
            txtCantidadOriginales.Text = "";
        }

        protected void LimpiarControles()
        {
            txtNombrePaquete.Text = "";
            txtDescripcion.InnerText = "";
            ddlDuracionDias.ClearSelection();
            txtCostoTotal.Text = "";
            rbOriginales.Checked = false;
            rbAlternativos.Checked = false;
            ddlProductosOriginales.ClearSelection();
            ddlProductosAlternativos.ClearSelection();
            ddlProductosOriginales.Enabled = false;
            ddlProductosAlternativos.Enabled = false;
        }

        public void cargarGridProductosOriginales(List<SupportRepuestoOriginal> lista)
        {
            gridRepuestosAgregados.DataSource = lista;
            gridRepuestosAgregados.DataBind();
        }

        public void cargarGridProductosAlternativos(List<SupportRepuestoAlternativo> lista)
        {
            gridRepuestosAgregados.DataSource = lista;
            gridRepuestosAgregados.DataBind();
        }

        public void chargePaquetesGrid()
        {
            List<SupportPaqueteMantencion> listPaquetes = new Negocio.NegocioPaqueteMantencion().GetPaquetesMantencion();
            if (listPaquetes != null && listPaquetes.Count != 0)
            {
                gridPaquetesRegistrados.DataSource = listPaquetes;
                gridPaquetesRegistrados.DataBind();
            }
            else
            {
                gridPaquetesRegistrados.DataSource = listPaquetes;
                gridPaquetesRegistrados.DataBind();
            }
        }

        protected void btnAceptarMensaje_Click(object sender, EventArgs e)
        {
            mpeMensaje.Hide();
        }
    }
}