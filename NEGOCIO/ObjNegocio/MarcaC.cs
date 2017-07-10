using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using NEGOCIO.ObjApoyo;

namespace NEGOCIO.ObjNegocio
{
    public class MarcaC
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
        public List<MarcaC> ListarMarcas()
        {
            List<MARCA> tall = new MarcaDal().ListarMarcas();
            List<MarcaC> listado = new List<MarcaC>();
            foreach (var item in tall)
            {
                MarcaC marca = new MarcaC();
                marca.Id = int.Parse(item.MARCAID.ToString());
                marca.Nombre = item.NOMBREMARCA;

                listado.Add(marca);
            }
            return listado;
        }

        public MarcaApoyo GetMarcaById(int marcaId)
        {
            MARCA obj = new MarcaDal().GetMarcaById(marcaId);
            MarcaApoyo marcaAp = new MarcaApoyo();
            marcaAp.MarcaId = int.Parse(obj.MARCAID.ToString());
            marcaAp.MarcaNombre = obj.NOMBREMARCA;
            return marcaAp;
        }


    }
}
