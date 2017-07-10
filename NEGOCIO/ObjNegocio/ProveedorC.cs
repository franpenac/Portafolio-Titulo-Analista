using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace NEGOCIO.ObjNegocio
{
    public class ProveedorC
    {
        private int intId;

        public int Id
        {
            get { return intId; }
            set { intId = value; }
        }

        private string strNombre;

        public string Nombre
        {
            get { return strNombre; }
            set { strNombre = value; }
        }

        public List<ProveedorC> ListarProveedores()
        {
            List<PROVEEDOR> tall = new ProveedorDal().ListarProveedores();
            List<ProveedorC> listado = new List<ProveedorC>();
            foreach (var item in tall)
            {
                ProveedorC proveedor = new ProveedorC();
                proveedor.Id = int.Parse(item.PROVEEDORID.ToString());
                proveedor.Nombre = item.NOMBREPROVEEDOR;

                listado.Add(proveedor);
            }
            return listado;
        }

    }
}
