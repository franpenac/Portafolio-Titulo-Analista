using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Web;
using Negocio.SupportClasses;
using NEGOCIO.Modelos;
using System.Net.Mail;

namespace Negocio
{
    public class NegocioUsuario
    {
        public void Copy(USUARIO objSource, ref USUARIO objDestination)
        {
            new DalUsuario().Copy(objSource, ref objDestination);
        }

        public bool Save(SupportUsuario objSource)
        {
            USUARIO newPersona = new USUARIO();
            newPersona.PERSONAID = objSource.PersonaId;
            newPersona.PERFILID = objSource.PerfilId;
            newPersona.RUTPERSONA = objSource.RutPersona;
            newPersona.NOMBREPERSONA = objSource.NombrePersona;
            newPersona.APELLIDOPERSONA = objSource.ApellidoPersona;
            newPersona.EMAILPERSONA = objSource.EmailPersona;
            newPersona.PASSWORDPERSONA = objSource.PasswordPersona;
            newPersona.PASSWORDCODE = objSource.PasswordCode;
            USUARIO user = new DalUsuario().Save(newPersona);
            if (user != null)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public List<ModelUsuario> GetUserList()
        {
            List<ModelUsuario> list = new List<ModelUsuario>();
            List<USUARIO> list2  = new DalUsuario().GetUserList();
            if (list2 != null)
            {
                foreach (USUARIO item in list2)
                {
                    ModelUsuario usuario = new ModelUsuario();
                    usuario.idUsuario = item.PERSONAID;
                    usuario.rutUsuario = item.RUTPERSONA;
                    usuario.nombreUsuario = item.NOMBREPERSONA;
                    usuario.apellidoUsuario = item.APELLIDOPERSONA;
                    usuario.emailUsuario = item.EMAILPERSONA;
                    usuario.perfilUsuario = new DalPerfil().GetProfileNameById(int.Parse(item.PERFILID.ToString()));
                    usuario.PerfilUsuarioId = int.Parse(item.PERFILID.ToString());
                    list.Add(usuario);
                }
                return list;
            }
            else
                return null;
        }

        public SupportUsuario verifyUser(string userEmail, string password)
        {
            SupportUsuario user = new SupportUsuario();
            USUARIO gotUser = new DalUsuario().verifyUser(userEmail, password);
            if (gotUser != null)
            {
                user.RutPersona = gotUser.RUTPERSONA;
                user.NombrePersona = gotUser.NOMBREPERSONA;
                user.ApellidoPersona = gotUser.APELLIDOPERSONA;
                user.EmailPersona = gotUser.EMAILPERSONA;
                user.PerfilId = int.Parse(gotUser.PERFILID.ToString());
                user.PersonaId = int.Parse(gotUser.PERSONAID.ToString());
                user.PasswordPersona = gotUser.PASSWORDPERSONA;
            }else
            {
                user = null;
            }
            return user;
        }

        public void sendEmail(string emailToSend, string emailBody, string changeCode)
        {
            try
            {
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                sc.Credentials = new System.Net.NetworkCredential("rodrigo.siregra@gmail.com", "188551238");
                sc.EnableSsl = true;
                string msg = emailBody;
                msg = msg.Replace("#WEB_SITE", HttpContext.Current.Request.Url.GetComponents(UriComponents.SchemeAndServer, UriFormat.UriEscaped) + @"/");
                msg = msg.Replace("#CODE",changeCode);
                MailMessage message = new MailMessage();
                message.Subject = "Cambio de password SIREGRA";
                message.Body = msg;
                message.To.Add(new MailAddress(emailToSend));
                message.From = new MailAddress("rodrigo.siregra@gmail.com", "Siregra", Encoding.UTF8);
                //string html = msg + "<img src='cid:imagen' width='300px' height='100px'/>";
                message.IsBodyHtml = true;
                sc.SendAsync(message, message);
            }
            catch (Exception ex)
            {

            }
        }

        public string generatePasswordCode()
        {
            return Guid.NewGuid().ToString();
        }

        public SupportUsuario GetUserByPasswordCode(string passwordCode)
        {
            USUARIO userFound = new DalUsuario().getUserByPasswordCode(passwordCode);
            if (userFound != null)
            {
                SupportUsuario userSend = new SupportUsuario();
                userSend.PersonaId = int.Parse(userFound.PERSONAID.ToString());
                userSend.RutPersona = userFound.RUTPERSONA;
                userSend.NombrePersona = userFound.NOMBREPERSONA;
                userSend.ApellidoPersona = userFound.APELLIDOPERSONA;
                userSend.EmailPersona = userFound.EMAILPERSONA;
                userSend.PerfilId = int.Parse(userFound.PERFILID.ToString());
                userSend.PasswordPersona = userFound.PASSWORDPERSONA;
                userSend.PasswordCode = userFound.PASSWORDCODE;
                return userSend;
            }else
            {
                return null;
            }
        }

        public void changePassword(string passwordCode, string newPassword)
        {
            new DalUsuario().changePassword(passwordCode, newPassword);
        }

        public void changePasswordCode(string OldPasswordCode, string NewPasswordCode)
        {
            new DalUsuario().changePasswordCode(OldPasswordCode,NewPasswordCode);
        }

        public SupportUsuario getUserByEmail(string email)
        {
            USUARIO userFound = new DalUsuario().getUserByEmail(email);
            if (userFound != null)
            {
                SupportUsuario userSend = new SupportUsuario();
                userSend.PersonaId = int.Parse(userFound.PERSONAID.ToString());
                userSend.RutPersona = userFound.RUTPERSONA;
                userSend.NombrePersona = userFound.NOMBREPERSONA;
                userSend.ApellidoPersona = userFound.APELLIDOPERSONA;
                userSend.EmailPersona = userFound.EMAILPERSONA;
                userSend.PerfilId = int.Parse(userFound.PERFILID.ToString());
                userSend.PasswordPersona = userFound.PASSWORDPERSONA;
                userSend.PasswordCode = userFound.PASSWORDCODE;
                return userSend;
            }
            else
            {
                return null;
            }
        }

        public SupportUsuario getUserById(int id)
        {
            USUARIO userFound = new DalUsuario().GetUserById(id);
            if (userFound != null)
            {
                SupportUsuario userSend = new SupportUsuario();
                userSend.PersonaId = int.Parse(userFound.PERSONAID.ToString());
                userSend.RutPersona = userFound.RUTPERSONA;
                userSend.NombrePersona = userFound.NOMBREPERSONA;
                userSend.ApellidoPersona = userFound.APELLIDOPERSONA;
                userSend.EmailPersona = userFound.EMAILPERSONA;
                userSend.PerfilId = int.Parse(userFound.PERFILID.ToString());
                userSend.PasswordPersona = userFound.PASSWORDPERSONA;
                userSend.PasswordCode = userFound.PASSWORDCODE;
                return userSend;
            }
            else
            {
                return null;
            }
        }

        public void ChangeUserPassword(int id, string newPassword)
        {
            new DalUsuario().ChangeUserPassword(id, newPassword);
        }

        public bool ValidarRut(string rut)
        {
            return new DalUsuario().ValidateRut(rut);
        }
    }
}
