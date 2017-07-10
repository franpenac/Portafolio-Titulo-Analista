using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DAL;
using Negocio.SupportClasses;
using DAL.SupportClasses;
using NEGOCIO.ObjApoyo;

namespace Negocio
{
   public class NegocioRepuestoOriginal
    {
        public RepuestoOriginalApoyo BuscarTaller(int tallerId)
        {
            REPUESTOORIGINAL tall = new RepuestoOriginalDal().BuscarTaller(tallerId);
            RepuestoOriginalApoyo nuevoTaller = new RepuestoOriginalApoyo();

            nuevoTaller.RepuestoOriginalId = int.Parse(tall.REPUESTOORIGINALID.ToString());
            nuevoTaller.ModeloId = int.Parse(tall.MODELOID.ToString());
            nuevoTaller.TipoProductoId = int.Parse(tall.TIPOPRODUCTOID.ToString());
            nuevoTaller.ProveedorId = int.Parse(tall.TIPOPRODUCTOID.ToString());
            int id = new RepuestoOriginalDal().BuscarModelo(int.Parse(tall.MODELOID.ToString()));
            nuevoTaller.Marca = id.ToString();
            return nuevoTaller;
        }

        public void Eliminar(int localizacionId)
        {
            new RepuestoOriginalDal().Eliminar(localizacionId);

        }
        public IEnumerable<object> CargarGrilla()
        {
            return new RepuestoOriginalDal().CargarGrilla();
        }

        public string ModeloPorIdRepuesto(int id)
        {
           string model= new RepuestoOriginalDal().ModeloPorIdRepuesto(id);
            return model;
        }

        public List<RepuestoOriginalApoyo> CargarComboRepuesto()
        {
            List<REPUESTOORIGINAL> tall = new RepuestoOriginalDal().CargarComboRepuesto();
            List<RepuestoOriginalApoyo> listado = new List<RepuestoOriginalApoyo>();
            foreach (var item in tall)
            {
                RepuestoOriginalApoyo r = new RepuestoOriginalApoyo();
                r.Costo = int.Parse(item.COSTO.ToString());
                r.ModeloId = int.Parse(item.MODELOID.ToString());
                r.ProveedorId = int.Parse(item.PROVEEDORID.ToString());
                r.TipoProductoId = int.Parse(item.TIPOPRODUCTOID.ToString());
                r.RepuestoOriginalId = int.Parse(item.REPUESTOORIGINALID.ToString());

                listado.Add(r);
            }
            return listado;
        }

        public List<SupportRepuestoOriginal> GetRepuestosOriginales(out string errorMessage)
        {
            errorMessage = "";
            List<RepuestoOriginalToDdl> list1 = new RepuestoOriginalDal().GetRepuestosOriginales(out errorMessage);
            List<SupportRepuestoOriginal> list2 = new List<SupportRepuestoOriginal>();
            foreach (var item in list1)
            {
                SupportRepuestoOriginal repuestoOriginal = new SupportRepuestoOriginal();
                repuestoOriginal.ProductoNombre = item.NombreModelo;
                repuestoOriginal.RepuestoOriginalId = int.Parse(item.RepuestoOriginalId.ToString());
                list2.Add(repuestoOriginal);
            }
            SupportRepuestoOriginal addIndex0 = new SupportRepuestoOriginal();
            addIndex0.ProductoNombre = "Seleccione";
            addIndex0.RepuestoOriginalId = 1000;
            list2.Insert(0,addIndex0);
            return list2;
        }

        public SupportRepuestoOriginal GetRepuestoOriginalPorId(int repuestoId, out string errorMessage)
        {
            REPUESTOORIGINAL rep = new RepuestoOriginalDal().GetRepuestoOriginalPorId(repuestoId, out errorMessage);
            SupportRepuestoOriginal newRep = new SupportRepuestoOriginal();
            newRep.RepuestoOriginalId = int.Parse(rep.REPUESTOORIGINALID.ToString());
            newRep.ModeloId = int.Parse(rep.MODELOID.ToString());
            newRep.ProveedorId = int.Parse(rep.PROVEEDORID.ToString());
            newRep.TipoProductoId = int.Parse(rep.TIPOPRODUCTOID.ToString());
            newRep.Costo = int.Parse(rep.COSTO.ToString());
            newRep.ProductoNombre = new RepuestoOriginalDal().GerRepuestoOriginalNombre(int.Parse(rep.MODELOID.ToString()));
            return newRep;
        }
    }
}
