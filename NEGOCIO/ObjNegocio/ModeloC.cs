using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using NEGOCIO.ObjApoyo;

namespace NEGOCIO.ObjNegocio
{
     public class ModeloC
    {
        private int intId;

        public int Id
        {
            get { return intId; }
            set { intId = value; }
        }
        private int intMarcaId;

        public int MarcaId
        {
            get { return intMarcaId; }
            set { intMarcaId = value; }
        }
        private string strNombre;

        public string Nombre
        {
            get { return strNombre; }
            set { strNombre = value; }
        }

        public List<ModeloC> ListarModelos()
        {
            List<MODELO> tall = new ModeloDal().ListarModelos();
            List<ModeloC> listado = new List<ModeloC>();
            foreach (var item in tall)
            {
                ModeloC mod = new ModeloC();
                mod.Id = int.Parse(item.MODELOID.ToString());
                mod.MarcaId = int.Parse(item.MARCAID.ToString());
                mod.Nombre = item.NOMBREMODELO;

                listado.Add(mod);
            }
            return listado;
        }

        public ModeloApoyo GetModeloById(int modeloId)
        {
            MODELO obj = new ModeloDal().GetModeloById(modeloId);
            ModeloApoyo modeloAp = new ModeloApoyo();
            modeloAp.ModeloId = int.Parse(obj.MODELOID.ToString());
            modeloAp.MarcaId = int.Parse(obj.MARCAID.ToString());
            modeloAp.ModeloNombre = obj.NOMBREMODELO;
            return modeloAp;
        }
    }
}
