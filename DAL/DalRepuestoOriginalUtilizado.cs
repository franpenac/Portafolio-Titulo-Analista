using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalRepuestoOriginalUtilizado
    {
        public void Copy(REPUESTOORIGINALUTILIZADO objSource, ref REPUESTOORIGINALUTILIZADO objDestination)
        {
            objDestination.REPUESTOORIGINALUTILIZADOID = objSource.REPUESTOORIGINALUTILIZADOID;
            objDestination.REPUESTOORIGINALID = objSource.REPUESTOORIGINALID;
            objDestination.PAQUETEMANTENCIONID = objSource.PAQUETEMANTENCIONID;
            objDestination.CANTIDAD = objSource.CANTIDAD;
        }

        public REPUESTOORIGINALUTILIZADO Save(REPUESTOORIGINALUTILIZADO objSource)
        {
            try
            {
                using (portafolio context = new portafolio())
                {
                    REPUESTOORIGINALUTILIZADO row = context.REPUESTOORIGINALUTILIZADO.Where(r => r.PAQUETEMANTENCIONID == objSource.PAQUETEMANTENCIONID && r.REPUESTOORIGINALID == objSource.REPUESTOORIGINALID).FirstOrDefault();
                    if (row == null)
                    {
                        row = new REPUESTOORIGINALUTILIZADO();
                        Copy(objSource, ref row);
                        context.REPUESTOORIGINALUTILIZADO.Add(row);
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

        public List<REPUESTOORIGINALUTILIZADO> GetRepuestosOriginalesutilizadosPorPaqueteMantencionId(int paqueteId,out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (portafolio context = new portafolio())
                {
                    List<REPUESTOORIGINALUTILIZADO> repuestos = (from repuestoOriginalUtilizado in context.REPUESTOORIGINALUTILIZADO
                                                                 where
                                                         repuestoOriginalUtilizado.PAQUETEMANTENCIONID == paqueteId 
                                                         select repuestoOriginalUtilizado
                                                        ).ToList();
                    if (repuestos == null)
                    {
                        errorMessage = "No existen repuestos utilizados";
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
