using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalPaqueteMantencion
    {
        public void Copy(PAQUETEMANTENCION objSource, ref PAQUETEMANTENCION objDestination)
        {
            objDestination.PAQUETEMANTENCIONID = objSource.PAQUETEMANTENCIONID;
            objDestination.NOMBREPAQUETEMANTENCION = objSource.NOMBREPAQUETEMANTENCION;
            objDestination.COSTOTOTAL = objSource.COSTOTOTAL;
            objDestination.DURACIONDIAS = objSource.DURACIONDIAS;
            objDestination.DESCRIPCION = objSource.DESCRIPCION;
        }

        public PAQUETEMANTENCION Save(PAQUETEMANTENCION objSource)
        {
            try
            {
                using (portafolio context = new portafolio())
                {
                    PAQUETEMANTENCION row = context.PAQUETEMANTENCION.Where(r => r.PAQUETEMANTENCIONID == objSource.PAQUETEMANTENCIONID).FirstOrDefault();
                    if (row == null)
                    {
                        row = new PAQUETEMANTENCION();
                        Copy(objSource, ref row);
                        context.PAQUETEMANTENCION.Add(row);
                    }
                    else
                    {
                        Copy(objSource, ref row);
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

        public List<PAQUETEMANTENCION> GetPaquetesMantencion()
        {
            try
            {
                using (portafolio context = new portafolio())
                {
                    List<PAQUETEMANTENCION> listPaquetes = (from paqueteMantencion in context.PAQUETEMANTENCION select paqueteMantencion).ToList();
                    if (listPaquetes == null)
                    {
                        return null;
                    }
                    else
                        return listPaquetes;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PAQUETEMANTENCION GetPaquetesMantencionPorNombre(string paqueteNombre,out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (portafolio context = new portafolio())
                {
                    PAQUETEMANTENCION paquete = (from paqueteMantencion in context.PAQUETEMANTENCION where paqueteMantencion.NOMBREPAQUETEMANTENCION == paqueteNombre select paqueteMantencion).FirstOrDefault();
                    if (paquete == null)
                    {
                        errorMessage = "No existe paquete";
                        return null;
                    }
                    else
                        return paquete;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return null;
            }
        }

        public void AgregarCostoTotalPaqueteMantencion(int costoPorAgregar, int idObjeto, out string errorMessage)
        {
            try
            {
                using (portafolio context = new portafolio())
                {
                    PAQUETEMANTENCION paqueteAModificar = context.PAQUETEMANTENCION.Where(r => r.PAQUETEMANTENCIONID == idObjeto).FirstOrDefault();
                    if (paqueteAModificar != null)
                    {
                        paqueteAModificar.COSTOTOTAL = costoPorAgregar;
                        context.SaveChanges();
                        errorMessage = "Cambio Realizado";
                    }else
                    {
                        errorMessage = "No existe paquete";
                    }
                }
            }
            catch (Exception ex)
            {
                 errorMessage = ex.Message;
            }
        }

        public PAQUETEMANTENCION GetPaquetesMantencionPorId(int paqueteId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (portafolio context = new portafolio())
                {
                    PAQUETEMANTENCION paquete = (from paqueteMantencion in context.PAQUETEMANTENCION where paqueteMantencion.PAQUETEMANTENCIONID == paqueteId select paqueteMantencion).FirstOrDefault();
                    if (paquete == null)
                    {
                        errorMessage = "No existe paquete";
                        return null;
                    }
                    else
                        return paquete;
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
