using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.SupportClasses;
using NEGOCIO.ObjNegocio;
using NEGOCIO.Modelos;
using System.IO;

namespace Siregra
{
    public partial class RegistroUsuarioPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitialControls();
            }else
            {
                chargeUsersGrid();
            }
        }

        protected void InitialControls()
        {
            if (!IsPostBack)
            {
                ddlPerfil.DataSource = new NegocioPerfil().GetProfileList();
                ddlPerfil.DataValueField = "PERFILID";
                ddlPerfil.DataTextField = "NOMBREPERFIL";
                ddlPerfil.DataBind();
                ddlPerfil.SelectedValue = "0";
                txtRutPersona.Text = "";
                txtNombrePersona.Text = "";
                txtApellidoPersona.Text = "";
                txtEmailPersona.Text = "";
                chargeUsersGrid();
            }
        }

        protected void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {

            SupportUsuario persona = new SupportUsuario();
            persona.PersonaId = (userId.Text == "" || userId.Text == null) ? int.Parse("0") : int.Parse(userId.Text);
            persona.PerfilId = int.Parse(ddlPerfil.SelectedItem.Value);
            persona.RutPersona = txtRutPersona.Text;
            persona.NombrePersona = txtNombrePersona.Text;
            persona.ApellidoPersona = txtApellidoPersona.Text;
            persona.EmailPersona = txtEmailPersona.Text;
            persona.PasswordPersona = "";
            persona.PasswordCode = new Negocio.NegocioUsuario().generatePasswordCode();
            if (new Negocio.NegocioUsuario().ValidarRut(txtRutPersona.Text))
            {
                if (txtNombrePersona.Text.Trim() != "" || txtApellidoPersona.Text.Trim() != "")
                {
                    if (new Negocio.NegocioUsuario().getUserByEmail(txtEmailPersona.Text) == null)
                    {
                        bool correcto = new Negocio.NegocioUsuario().Save(persona);
                        if (correcto)
                        {
                            new Negocio.NegocioUsuario().sendEmail(txtEmailPersona.Text, GetMailBody(), persona.PasswordCode);
                            lblMensaje.Text = "Usuario registrado";
                            mpeMensaje.Show();
                        }
                        else
                        {
                            lblMensaje.Text = "Error al crear al usuario";
                            mpeMensaje.Show();
                        }
                        chargeUsersGrid();
                    }
                    else
                    {
                        lblMensaje.Text = "Email ya se encuentra registrado, intente con otro email.";
                        mpeMensaje.Show();
                    }
                }else
                {
                    lblMensaje.Text = "Debe ingresar 'Nombre' y 'Apellido'.";
                    mpeMensaje.Show();
                }
            }else
            {
                lblMensaje.Text = "Rut ya se encuentra registrado.";
                mpeMensaje.Show();
            }
            cleanControls();
        }

        public void chargeUsersGrid()
        {
            List<ModelUsuario> listUsuarios = new Negocio.NegocioUsuario().GetUserList();
            if (listUsuarios != null && listUsuarios.Count != 0)
            {
                gridUsuariosRegistrados.DataSource = listUsuarios;
                gridUsuariosRegistrados.DataBind();
            }
            else
            {
                gridUsuariosRegistrados.DataSource = listUsuarios;
                gridUsuariosRegistrados.DataBind();
            }
        }

        public void cleanControls()
        {
            txtRutPersona.Text = "";
            txtNombrePersona.Text = "";
            txtApellidoPersona.Text = "";
            txtEmailPersona.Text = "";
            ddlPerfil.SelectedValue = "0";
        }

        protected void gridUsuariosRegistrados_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridUsuariosRegistrados.SelectedRow;
            userId.Text = row.Cells[1].Text;
            ddlPerfil.SelectedValue = row.Cells[7].Text;
            txtRutPersona.Text = row.Cells[2].Text;
            txtRutPersona.Enabled = false;
            txtNombrePersona.Text = row.Cells[3].Text;
            txtApellidoPersona.Text = row.Cells[4].Text;
            txtEmailPersona.Text = row.Cells[5].Text;
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

        protected void btnAceptarMensaje_Click(object sender, EventArgs e)
        {
            mpeMensaje.Hide();
        }
    }
}