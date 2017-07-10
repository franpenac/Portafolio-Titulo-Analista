using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProveedorDal
    {
        public List<PROVEEDOR> ListarProveedores()
        {
            using (var context = new portafolio())
            {
                List<PROVEEDOR> listado = context.PROVEEDOR.ToList();
                return listado;
            }
        }

    }
}
