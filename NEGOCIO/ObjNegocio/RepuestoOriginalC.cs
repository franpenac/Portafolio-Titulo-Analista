using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace NEGOCIO.ObjNegocio
{
    public class RepuestoOriginalC
    {

        private int intId;

        public int Id
        {
            get { return intId; }
            set { intId = value; }
        }

        private int intModeloId;

        public int ModeloId
        {
            get { return intModeloId; }
            set { intModeloId = value; }
        }

        private int intProveedorId;

        public int ProveedorId
        {
            get { return intProveedorId; }
            set { intProveedorId = value; }
        }

        private int intTipoProductoId;

        public int TipoProductoId
        {
            get { return intTipoProductoId; }
            set { intTipoProductoId = value; }
        }

        private decimal decCosto;

        public decimal Costo
        {
            get { return decCosto; }
            set { decCosto = value; }
        }


        public bool Insertar(RepuestoOriginalC apoyo)
        {
            REPUESTOORIGINAL tall = new REPUESTOORIGINAL();
            tall.REPUESTOORIGINALID = 0;
            tall.TIPOPRODUCTOID = apoyo.TipoProductoId;
            tall.COSTO = apoyo.Costo;
            tall.MODELOID = apoyo.ModeloId;
            tall.PROVEEDORID = apoyo.ProveedorId;
            

            tall = new RepuestoOriginalDal().InsertarRepuesto(tall);
            if (tall == null)
            {
                return false;
            }
            return true;
        }

        public bool Editar(RepuestoOriginalC apoyo)
        {
            REPUESTOORIGINAL tall = new REPUESTOORIGINAL();
            
            tall.TIPOPRODUCTOID = apoyo.TipoProductoId;
            tall.COSTO = apoyo.Costo;
            tall.MODELOID = apoyo.ModeloId;
            tall.PROVEEDORID = apoyo.ProveedorId;


            tall = new RepuestoOriginalDal().Editar(tall);
            if (tall == null)
            {
                return false;
            }
            return true;
        }

        public List<RepuestoOriginalC> Listar()
        {
            List<REPUESTOORIGINAL> tall = new RepuestoOriginalDal().ListarRepuestos();
            List<RepuestoOriginalC> listado = new List<RepuestoOriginalC>();
            foreach (var item in tall)
            {
                RepuestoOriginalC rep = new RepuestoOriginalC();
                rep.Id = int.Parse(item.REPUESTOORIGINALID.ToString());
                rep.ModeloId = int.Parse(item.MODELOID.ToString());
                rep.ProveedorId = int.Parse(item.PROVEEDORID.ToString());
                rep.TipoProductoId = int.Parse(item.TIPOPRODUCTOID.ToString());
                rep.Costo = item.COSTO;

                listado.Add(rep);
            }
            return listado;
        }

        public void Eliminar(int id)
        {
            new RepuestoOriginalDal().EliminarRepuesto(id);
        }

    }
}
