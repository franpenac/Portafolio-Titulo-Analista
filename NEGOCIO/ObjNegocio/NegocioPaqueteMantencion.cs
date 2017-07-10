using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Negocio.SupportClasses;
using NEGOCIO.Modelos;

namespace Negocio
{
    public class NegocioPaqueteMantencion
    {
        public void Copy(PAQUETEMANTENCION objSource, ref PAQUETEMANTENCION objDestination)
        {
            new DalPaqueteMantencion().Copy(objSource, ref objDestination);
        }

        public void Save(SupportPaqueteMantencion objSource)
        {
            PAQUETEMANTENCION newPaqueteMantencion = new PAQUETEMANTENCION();
            newPaqueteMantencion.PAQUETEMANTENCIONID = objSource.PaqueteMantencionId;
            newPaqueteMantencion.NOMBREPAQUETEMANTENCION = objSource.NombrePaqueteMantencion;
            newPaqueteMantencion.COSTOTOTAL = objSource.CostoTotal;
            newPaqueteMantencion.DURACIONDIAS = objSource.DuracionDias;
            newPaqueteMantencion.DESCRIPCION = objSource.Descripcion;

            new DalPaqueteMantencion().Save(newPaqueteMantencion);
        }

        public List<SupportPaqueteMantencion> GetPaquetesMantencion()
        {
            List<PAQUETEMANTENCION> list1 = new DalPaqueteMantencion().GetPaquetesMantencion();
            List<SupportPaqueteMantencion> list2 = new List<SupportPaqueteMantencion>();
            foreach (PAQUETEMANTENCION item in list1)
            {
                SupportPaqueteMantencion supportPaquete = new SupportPaqueteMantencion();
                supportPaquete.PaqueteMantencionId = int.Parse(item.PAQUETEMANTENCIONID.ToString());
                supportPaquete.NombrePaqueteMantencion = item.NOMBREPAQUETEMANTENCION;
                supportPaquete.CostoTotal = int.Parse(item.COSTOTOTAL.ToString());
                supportPaquete.DuracionDias = int.Parse(item.DURACIONDIAS.ToString());
                supportPaquete.Descripcion = item.DESCRIPCION;
                list2.Add(supportPaquete);
            }
            if (list2 == null)
            {
                return null;
            }else
            {
                return list2;
            }
        }

        public SupportPaqueteMantencion GetPaqueteMantencionPorNombre(string nombrePaquete, out string errorMessage)
        {
            PAQUETEMANTENCION paq = new DalPaqueteMantencion().GetPaquetesMantencionPorNombre(nombrePaquete, out errorMessage);
            SupportPaqueteMantencion nPaq = new SupportPaqueteMantencion();
            if (paq != null)
            {
                nPaq.PaqueteMantencionId = int.Parse(paq.PAQUETEMANTENCIONID.ToString());
                nPaq.NombrePaqueteMantencion = paq.NOMBREPAQUETEMANTENCION.ToUpper();
                nPaq.CostoTotal = int.Parse(paq.COSTOTOTAL.ToString());
                nPaq.DuracionDias = int.Parse(paq.DURACIONDIAS.ToString());
                nPaq.Descripcion = paq.DESCRIPCION;
                return nPaq;
            }
            else
            {
                return null;
            }

        }

        public SupportPaqueteMantencion GetPaqueteMantencionPorId(int paqueteId, out string errorMessage)
        {
            PAQUETEMANTENCION paq = new DalPaqueteMantencion().GetPaquetesMantencionPorId(paqueteId, out errorMessage);
            SupportPaqueteMantencion nPaq = new SupportPaqueteMantencion();
            if (paq != null)
            {
                nPaq.PaqueteMantencionId = int.Parse(paq.PAQUETEMANTENCIONID.ToString());
                nPaq.NombrePaqueteMantencion = paq.NOMBREPAQUETEMANTENCION.ToUpper();
                nPaq.CostoTotal = int.Parse(paq.COSTOTOTAL.ToString());
                nPaq.DuracionDias = int.Parse(paq.DURACIONDIAS.ToString());
                nPaq.Descripcion = paq.DESCRIPCION;
                return nPaq;
            }
            else
            {
                return null;
            }
        }

        public void AgregarCostoTotalPaqueteMantencion(int costoPorAgregar, int idObjeto, out string errorMessage)
        {
            errorMessage = "";
            new DalPaqueteMantencion().AgregarCostoTotalPaqueteMantencion(costoPorAgregar, idObjeto,out errorMessage);
        }
    }
}
