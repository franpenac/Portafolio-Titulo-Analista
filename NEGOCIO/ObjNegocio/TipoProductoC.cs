using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace NEGOCIO.ObjNegocio
{
    public class TipoProductoC
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

        public List<TipoProductoC> ListarTipoProductos()
        {
            List<TIPOPRODUCTO> tall = new TipoProductoDal().ListarTipoProductos();
            List<TipoProductoC> listado = new List<TipoProductoC>();
            foreach (var item in tall)
            {
                TipoProductoC tipo = new TipoProductoC();
                tipo.Id = int.Parse(item.TIPOPRODUCTOID.ToString());
                tipo.Nombre = item.NOMBRETIPO;

                listado.Add(tipo);
            }
            return listado;
        }

    }
}
