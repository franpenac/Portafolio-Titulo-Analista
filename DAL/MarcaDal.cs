using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MarcaDal
    {
        public List<MARCA> ListarMarcas()
        {
            using (var context = new portafolio())
            {
                List<MARCA> listado = context.MARCA.ToList();
                return listado;
            }
        }

        public MARCA GetMarcaById(int marcaId)
        {
            try
            {
                using (var context = new portafolio())
                {
                    MARCA marca = (from Marca in context.MARCA where Marca.MARCAID == marcaId select Marca).FirstOrDefault();
                    return marca;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
