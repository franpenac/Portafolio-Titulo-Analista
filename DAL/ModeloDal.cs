using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ModeloDal
    {
        public List<MODELO> ListarModelos()
        {
            using (var context = new portafolio())
            {
                List<MODELO> listado = context.MODELO.ToList();
                return listado;
            }
        }

        public MODELO GetModeloById(int modeloId)
        {
            try
            {
                using (var context = new portafolio())
                {
                    MODELO model = (from modelo in context.MODELO where modelo.MODELOID == modeloId select modelo).FirstOrDefault();
                    return model;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
