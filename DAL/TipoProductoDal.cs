using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TipoProductoDal
    {
        public List<TIPOPRODUCTO> ListarTipoProductos()
        {
            using (var context = new portafolio())
            {
                List<TIPOPRODUCTO> listado = context.TIPOPRODUCTO.ToList();
                return listado;
            }
        }
    }
}
