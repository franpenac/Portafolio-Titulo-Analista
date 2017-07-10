using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEGOCIO.ObjApoyo;
using DAL;

namespace NEGOCIO.ObjNegocio
{
    public class NegocioPerfil
    {
        public string GetProfileNameById(int perfilId)
        {
            string nombrePerfil = new DalPerfil().GetProfileNameById(perfilId);
            return nombrePerfil;
        }

        public List<SupportPerfil> GetProfileList()
        {
            List<PERFIL> list1 = new DalPerfil().GetProfileList();
            List<SupportPerfil> list2 = new List<SupportPerfil>();
            foreach (PERFIL item in list1)
            {
                SupportPerfil perfil = new SupportPerfil();
                perfil.PERFILID = int.Parse(item.PERFILID.ToString());
                perfil.NOMBREPERFIL = item.NOMBREPERFIL;
                list2.Add(perfil);
            }
            SupportPerfil pf = new SupportPerfil();
            pf.PERFILID = 0;
            pf.NOMBREPERFIL = "Seleccione";
            list2.Insert(0,pf);
            return list2;
        }
    }
}
