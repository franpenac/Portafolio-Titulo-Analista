using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Negocio.SupportClasses;

namespace Negocio
{
    public class NegocioRepuestoOriginalUtilizado
    {
        public void Save(SupportRepuestoOriginalUtilizado objSource)
        {
            REPUESTOORIGINALUTILIZADO newProductoU = new REPUESTOORIGINALUTILIZADO();
            newProductoU.REPUESTOORIGINALUTILIZADOID = objSource.RepuestoOriginalUtilizadoId;
            newProductoU.REPUESTOORIGINALID = objSource.RepuestoOriginalId;
            newProductoU.PAQUETEMANTENCIONID = objSource.PaqueteMantencionId;
            newProductoU.CANTIDAD = objSource.Cantidad;
            new DalRepuestoOriginalUtilizado().Save(newProductoU);
        }
        public List<SupportRepuestoOriginalUtilizado> GetProductosUtilizadosPorPaqueteMantencionId(int paqueteId, out string errorMessage)
        {
            
            List<SupportRepuestoOriginalUtilizado> list = new List<SupportRepuestoOriginalUtilizado>();
            List<REPUESTOORIGINALUTILIZADO> list2 = new DalRepuestoOriginalUtilizado().GetRepuestosOriginalesutilizadosPorPaqueteMantencionId(paqueteId, out errorMessage);
            foreach (REPUESTOORIGINALUTILIZADO item in list2)
            {
                SupportRepuestoOriginalUtilizado prodU = new SupportRepuestoOriginalUtilizado();
                prodU.RepuestoOriginalUtilizadoId = int.Parse(item.REPUESTOORIGINALUTILIZADOID.ToString());
                prodU.RepuestoOriginalId = int.Parse(item.REPUESTOORIGINALID.ToString());
                prodU.PaqueteMantencionId = int.Parse(item.PAQUETEMANTENCIONID.ToString());
                prodU.Cantidad = int.Parse(item.CANTIDAD.ToString());
                list.Add(prodU);
            }
            return list;
        }
    }
}
