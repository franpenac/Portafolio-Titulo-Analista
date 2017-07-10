using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalRepuestoAlternativoUtilizado
    {
        public void Copy(REPUESTOALTERNATIVOUTILIZADO objSource, ref REPUESTOALTERNATIVOUTILIZADO objDestination)
        {
            objDestination.REPUESTOALTERNATIVOUTILIZADOID = objSource.REPUESTOALTERNATIVOUTILIZADOID;
            objDestination.REPUESTOALTERNATIVOID = objSource.REPUESTOALTERNATIVOID;
            objDestination.PAQUETEMANTENCIONID = objSource.PAQUETEMANTENCIONID;
            objDestination.CANTIDAD = objSource.CANTIDAD;
        }

        public REPUESTOALTERNATIVOUTILIZADO Save(REPUESTOALTERNATIVOUTILIZADO objSource)
        {
            try
            {
                using (portafolio context = new portafolio())
                {
                    REPUESTOALTERNATIVOUTILIZADO row = context.REPUESTOALTERNATIVOUTILIZADO.Where(r => r.PAQUETEMANTENCIONID == objSource.PAQUETEMANTENCIONID && r.REPUESTOALTERNATIVOID == objSource.REPUESTOALTERNATIVOID).FirstOrDefault();
                    if (row == null)
                    {
                        row = new REPUESTOALTERNATIVOUTILIZADO();
                        Copy(objSource, ref row);
                        context.REPUESTOALTERNATIVOUTILIZADO.Add(row);
                    }
                    else
                    {
                        return null;
                    }
                    context.SaveChanges();
                    return row;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public List<REPUESTOALTERNATIVOUTILIZADO> GetRepuestosAlternativosUtilizadosPorPaqueteMantencionId(int paqueteId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (portafolio context = new portafolio())
                {
                    List<REPUESTOALTERNATIVOUTILIZADO> repuestos = (from repuestoAlternativoUtilizado in context.REPUESTOALTERNATIVOUTILIZADO
                                                                    where
                                                         repuestoAlternativoUtilizado.PAQUETEMANTENCIONID == paqueteId
                                                                 select repuestoAlternativoUtilizado
                                                        ).ToList();
                    if (repuestos == null)
                    {
                        return null;
                    }
                    else
                        return repuestos;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return null;
            }
        }
    }
}
