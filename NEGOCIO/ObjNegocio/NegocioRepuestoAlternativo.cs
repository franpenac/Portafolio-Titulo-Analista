using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DAL;
using Negocio.SupportClasses;
using DAL.SupportClasses;

namespace Negocio
{
    public class NegocioRepuestoAlternativo
    {
        public List<SupportRepuestoAlternativo> GetRepuestosAlternativos(out string errorMessage)
        {
            errorMessage = "";
            List<RepuestoAlternativoToDdl> list1 = new RepuestoAlternativoDal().GetRepuestosAlternativos(out errorMessage);
            List<SupportRepuestoAlternativo> list2 = new List<SupportRepuestoAlternativo>();
            foreach (var item in list1)
            {
                SupportRepuestoAlternativo repuestoAlternativo = new SupportRepuestoAlternativo();
                repuestoAlternativo.ProductoNombre = item.NombreModelo;
                repuestoAlternativo.RepuestoAlternativoId = int.Parse(item.RepuestoAlternativoId.ToString());
                list2.Add(repuestoAlternativo);
            }
            SupportRepuestoAlternativo addIndex0 = new SupportRepuestoAlternativo();
            addIndex0.ProductoNombre = "Seleccione";
            addIndex0.RepuestoAlternativoId = 0;
            list2.Insert(0, addIndex0);
            return list2;
        }

        public SupportRepuestoAlternativo GetRepuestoAlternativoPorId(int repuestoId, out string errorMessage)
        {
            REPUESTOALTERNATIVO rep = new RepuestoAlternativoDal().GetRepuestoAlternativoPorId(repuestoId, out errorMessage);
            SupportRepuestoAlternativo newRep = new SupportRepuestoAlternativo();
            newRep.RepuestoAlternativoId = int.Parse(rep.REPUESTOALTERNATIVOID.ToString());
            newRep.ModeloId = int.Parse(rep.MODELOID.ToString());
            newRep.ProveedorId = int.Parse(rep.PROVEEDORID.ToString());
            newRep.TipoProductoId = int.Parse(rep.TIPOPRODUCTOID.ToString());
            newRep.Costo = int.Parse(rep.COSTO.ToString());
            newRep.ProductoNombre = new RepuestoAlternativoDal().GerRepuestoAlternativoNombre(int.Parse(rep.MODELOID.ToString()));
            return newRep;
        }
    }
}
