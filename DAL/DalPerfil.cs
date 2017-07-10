using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalPerfil
    {
        public string GetProfileNameById(int perfilId)
        {
            try
            {
                using (var context = new portafolio())
                {
                    string nombrePerfil = (from perfil in context.PERFIL where perfil.PERFILID == perfilId select perfil.NOMBREPERFIL).FirstOrDefault();
                    if (nombrePerfil!=null)
                    {
                        return nombrePerfil;
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

        public List<PERFIL> GetProfileList()
        {
            try
            {
                using (var context = new portafolio())
                {
                    List<PERFIL> list = (from perfiles in context.PERFIL select perfiles).ToList();
                    if (list != null && list.Count>0)
                    {
                        return list;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
