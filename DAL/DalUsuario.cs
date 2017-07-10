using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalUsuario
    {
        public void Copy(USUARIO objSource, ref USUARIO objDestination)
        {

            objDestination.PERSONAID = objSource.PERSONAID;
            objDestination.PERFILID = objSource.PERFILID;
            objDestination.RUTPERSONA = objSource.RUTPERSONA;
            objDestination.NOMBREPERSONA = objSource.NOMBREPERSONA;
            objDestination.APELLIDOPERSONA = objSource.APELLIDOPERSONA;
            objDestination.EMAILPERSONA = objSource.EMAILPERSONA;
            objDestination.PASSWORDPERSONA = objSource.PASSWORDPERSONA;
            objDestination.PASSWORDCODE = objSource.PASSWORDCODE;
        }

        public USUARIO Save(USUARIO objSource)
        {
            try
            {
                using (portafolio context = new portafolio())
                {
                    USUARIO row = context.USUARIO.Where(r => r.PERSONAID == objSource.PERSONAID).FirstOrDefault();
                    if (row == null)
                    {
                        row = new USUARIO();
                        Copy(objSource, ref row);
                        context.USUARIO.Add(row);
                    }
                    else
                    {
                        Copy(objSource, ref row);
                    }
                    context.SaveChanges();
                    return row;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public USUARIO GetUserById(int id)
        {
            try
            {
                using (var context = new portafolio())
                {
                    USUARIO usuario = (from user in context.USUARIO where user.PERSONAID == id select user).FirstOrDefault();
                    if (usuario != null)
                    {
                        return usuario;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<USUARIO> GetUserList()
        {
            try
            {
                using (var context = new portafolio())
                {
                    List<USUARIO> list = (from usuario in context.USUARIO select usuario).ToList();

                    if (list != null && list.Count>0)
                    {
                        return list;
                    }
                    else
                        return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public USUARIO verifyUser(string userEmail, string password)
        {
            try
            {
                using (var context = new portafolio())
                {
                    USUARIO foundUser = (from user in context.USUARIO
                                    where user.EMAILPERSONA == userEmail &&
                                    user.PASSWORDPERSONA == password select user).FirstOrDefault();
                    if (foundUser != null)
                    {
                        return foundUser;
                    }else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public USUARIO getUserByPasswordCode(string passwordCode)
        {
            try
            {
                using (var context = new portafolio())
                {
                    USUARIO usuario = (from user in context.USUARIO where user.PASSWORDCODE == passwordCode select user).FirstOrDefault();
                    if (usuario != null)
                    {
                        return usuario;
                    }else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void changePassword(string passwordCode,string newPassword)
        {
            try
            {
                using (var context = new portafolio())
                {
                    USUARIO user = (from usuario in context.USUARIO where usuario.PASSWORDCODE == passwordCode select usuario).FirstOrDefault();
                    user.PASSWORDPERSONA = newPassword;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ChangeUserPassword(int id, string newPassword)
        {
            try
            {
                using (var context = new portafolio())
                {
                    USUARIO user = (from usuario in context.USUARIO where usuario.PERSONAID == id select usuario).FirstOrDefault();
                    user.PASSWORDPERSONA = newPassword;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void changePasswordCode(string OldPasswordCode, string NewPasswordCode)
        {
            try
            {
                using (var context = new portafolio())
                {
                    USUARIO user = (from usuario in context.USUARIO where usuario.PASSWORDCODE == OldPasswordCode select usuario).FirstOrDefault();
                    user.PASSWORDCODE = NewPasswordCode;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public USUARIO getUserByEmail(string email)
        {
            try
            {
                using (var context = new portafolio())
                {
                    USUARIO usuario = (from user in context.USUARIO where user.EMAILPERSONA == email select user).FirstOrDefault();
                    if (usuario != null)
                    {
                        return usuario;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ValidateRut(string rut)
        {
            try
            {
                using (var context = new portafolio())
                {
                    USUARIO usuario = (from user in context.USUARIO where user.RUTPERSONA == rut select user).FirstOrDefault();
                    if (usuario != null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
