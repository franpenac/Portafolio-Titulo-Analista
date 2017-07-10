using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Negocio.SupportClasses;

namespace Negocio
{
    public class NegocioRepuestoAlternativoUtilizado
    {
        public void Save(SupportRepuestoAlternativoUtilizado objSource)
        {
            REPUESTOALTERNATIVOUTILIZADO newProductoU = new REPUESTOALTERNATIVOUTILIZADO();
            newProductoU.REPUESTOALTERNATIVOUTILIZADOID = objSource.RepuestoAlternativoUtilizadoId;
            newProductoU.REPUESTOALTERNATIVOID = objSource.RepuestoAlternativoId;
            newProductoU.PAQUETEMANTENCIONID = objSource.PaqueteMantencionId;
            newProductoU.CANTIDAD = objSource.Cantidad;
            new DalRepuestoAlternativoUtilizado().Save(newProductoU);
        }
        public List<SupportRepuestoAlternativoUtilizado> GetProductosUtilizadosPorPaqueteMantencionId(int paqueteId, out string errorMessage)
        {

            List<SupportRepuestoAlternativoUtilizado> list = new List<SupportRepuestoAlternativoUtilizado>();
            List<REPUESTOALTERNATIVOUTILIZADO> list2 = new DalRepuestoAlternativoUtilizado().GetRepuestosAlternativosUtilizadosPorPaqueteMantencionId(paqueteId, out errorMessage);
            foreach (REPUESTOALTERNATIVOUTILIZADO item in list2)
            {
                SupportRepuestoAlternativoUtilizado prodU = new SupportRepuestoAlternativoUtilizado();
                prodU.RepuestoAlternativoUtilizadoId = int.Parse(item.REPUESTOALTERNATIVOUTILIZADOID.ToString());
                prodU.RepuestoAlternativoId = int.Parse(item.REPUESTOALTERNATIVOID.ToString());
                prodU.PaqueteMantencionId = int.Parse(item.PAQUETEMANTENCIONID.ToString());
                prodU.Cantidad = int.Parse(item.CANTIDAD.ToString());
                list.Add(prodU);
            }
            return list;
        }
    }
}
