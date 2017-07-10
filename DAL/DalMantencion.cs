using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalMantencion
    {
        public IEnumerable<object> CargarGrillaOriginal(string patente)
        {
            using (var context = new portafolio())
            {
                IEnumerable<object> list =
                        (from mant in context.PAQUETEMANTENCION
                         join repu in context.REPUESTOORIGINALUTILIZADO on mant.PAQUETEMANTENCIONID equals repu.PAQUETEMANTENCIONID
                         join rep in context.REPUESTOORIGINAL on repu.REPUESTOORIGINALID equals rep.REPUESTOORIGINALID
                         join prov in context.PROVEEDOR on rep.PROVEEDORID equals prov.PROVEEDORID
                         join tipo in context.TIPOPRODUCTO on rep.TIPOPRODUCTOID equals tipo.TIPOPRODUCTOID
                         join model in context.MODELO on rep.MODELOID equals model.MODELOID
                         join marca in context.MARCA on model.MARCAID equals marca.MARCAID
                         select new
                         {
                             Paquete = mant.NOMBREPAQUETEMANTENCION,
                             Modelo = repu.REPUESTOORIGINAL.MODELO.NOMBREMODELO,
                             Cantidad = repu.CANTIDAD

                         }).ToList();
                return list;
            }
        }

        public IEnumerable<object> CargarGrillaAlternativo(string patente)
        {
            using (var context = new portafolio())
            {
                IEnumerable<object> list =
                        (from mant in context.PAQUETEMANTENCION
                         join repu in context.REPUESTOALTERNATIVOUTILIZADO on mant.PAQUETEMANTENCIONID equals repu.PAQUETEMANTENCIONID
                         join rep in context.REPUESTOALTERNATIVO on repu.REPUESTOALTERNATIVOUTILIZADOID equals rep.REPUESTOALTERNATIVOID
                         join prov in context.PROVEEDOR on rep.PROVEEDORID equals prov.PROVEEDORID
                         join tipo in context.TIPOPRODUCTO on rep.TIPOPRODUCTOID equals tipo.TIPOPRODUCTOID
                         join model in context.MODELO on rep.MODELOID equals model.MODELOID
                         join marca in context.MARCA on model.MARCAID equals marca.MARCAID
                         select new
                         {
                             Paquete = mant.NOMBREPAQUETEMANTENCION,
                             Modelo = repu.REPUESTOALTERNATIVO.MODELO.NOMBREMODELO,
                             Cantidad = repu.CANTIDAD

                         }).ToList();
                return list;
            }
        }

        public bool existePatente(string patente)
        {
            using (var context = new portafolio())
            {
                return true;
            }
        }

        public bool existePaquete(string patente)
        {
            using (var context = new portafolio())
            {
                return true;
            }
        }
    }
}
