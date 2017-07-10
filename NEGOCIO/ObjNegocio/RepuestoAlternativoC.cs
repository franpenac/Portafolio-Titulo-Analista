using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace NEGOCIO.ObjNegocio
{
    public class RepuestoAlternativoC
    {
        private int intId;

        public int Id
        {
            get { return intId; }
            set { intId = value; }
        }

        private int intRepuestoOriginalId;

        public int RepuestoOriginalId
        {
            get { return intRepuestoOriginalId; }
            set { intRepuestoOriginalId = value; }
        }

        private int intProveedorId;

        public int ProveedorId
        {
            get { return intProveedorId; }
            set { intProveedorId = value; }
        }
        private int intTipoProducto;

        public int TipoProducto
        {
            get { return intTipoProducto; }
            set { intTipoProducto = value; }
        }
        private int intModeloId;

        public int ModeloId
        {
            get { return intModeloId; }
            set { intModeloId = value; }
        }

        private int intCosto;

        public int Costo
        {
            get { return intCosto; }
            set { intCosto = value; }
        }

        public bool Insertar(RepuestoAlternativoC apoyo)
        {
            REPUESTOALTERNATIVO tall = new REPUESTOALTERNATIVO();
            tall.REPUESTOALTERNATIVOID = 0;
            tall.REPUESTOORIGINALID = apoyo.RepuestoOriginalId;
            tall.TIPOPRODUCTOID = apoyo.TipoProducto;
            tall.MODELOID = apoyo.ModeloId;
            tall.PROVEEDORID = apoyo.ProveedorId;
            tall.COSTO = apoyo.Costo;

            tall = new RepuestoAlternativoDal().InsertarRepuesto(tall);
            if (tall == null)
            {
                return false;
            }
            return true;
        }

        public bool Editar(RepuestoAlternativoC apoyo)
        {
            REPUESTOALTERNATIVO tall = new REPUESTOALTERNATIVO();

            tall.REPUESTOORIGINALID = apoyo.RepuestoOriginalId;
            tall.TIPOPRODUCTOID = apoyo.TipoProducto;
            tall.MODELOID = apoyo.ModeloId;
            tall.PROVEEDORID = apoyo.ProveedorId;
            tall.COSTO = apoyo.Costo;

            tall = new RepuestoAlternativoDal().Editar(tall);
            if (tall == null)
            {
                return false;
            }
            return true;
        }

        public List<RepuestoAlternativoC> Listar()
        {
            List<REPUESTOALTERNATIVO> tall = new RepuestoAlternativoDal().ListarRepuestos();
            List<RepuestoAlternativoC> listado = new List<RepuestoAlternativoC>();
            foreach (var item in tall)
            {
                RepuestoAlternativoC rep = new RepuestoAlternativoC();
                rep.Id = int.Parse(item.REPUESTOALTERNATIVOID.ToString());
                rep.ModeloId = int.Parse(item.MODELOID.ToString());
                rep.ProveedorId = int.Parse(item.PROVEEDORID.ToString());
                rep.TipoProducto = int.Parse(item.TIPOPRODUCTOID.ToString());
                rep.RepuestoOriginalId = int.Parse(item.REPUESTOORIGINALID.ToString());
                rep.Costo = int.Parse(item.COSTO.ToString());
                listado.Add(rep);
            }
            return listado;
        }

        public void Eliminar(int id)
        {
            new RepuestoAlternativoDal().EliminarRepuesto(id);
        }

        public RepuestoAlternativoC BuscarRepuesto(int id)
        {
            RepuestoAlternativoC apoyo = new RepuestoAlternativoC();
            REPUESTOALTERNATIVO tall = new RepuestoAlternativoDal().BuscarRepuesto(id);
            apoyo.Id = int.Parse(tall.REPUESTOALTERNATIVOID.ToString());
            apoyo.RepuestoOriginalId = int.Parse(tall.REPUESTOORIGINALID.ToString());
            apoyo.TipoProducto = int.Parse(tall.TIPOPRODUCTOID.ToString());
            apoyo.ModeloId = int.Parse(tall.MODELOID.ToString());
            apoyo.ProveedorId = int.Parse(tall.PROVEEDORID.ToString());
            apoyo.Costo = int.Parse(tall.COSTO.ToString());

            if (tall == null)
            {
                return null;
            }
            return apoyo;
        }
        
    }
}
