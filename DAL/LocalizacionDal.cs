using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LocalizacionDal
    {
        public void Copiar(LOCALIZACION objEntrada, ref LOCALIZACION objDestino)
        {
            objDestino.LOCALIZACIONID = objEntrada.LOCALIZACIONID;
            objDestino.COMUNAID = objEntrada.COMUNAID;
            objDestino.NOMBRELOCALIZACION = objEntrada.NOMBRELOCALIZACION;
            
        }

        public LOCALIZACION Guardar(LOCALIZACION loc)
        {
            using (var context = new portafolio())
            {
                LOCALIZACION fila = context.LOCALIZACION.Where(c => c.LOCALIZACIONID == loc.LOCALIZACIONID).FirstOrDefault();

                if (fila==null)
                {
                    fila = new LOCALIZACION();
                    Copiar(loc,ref fila);
                    context.LOCALIZACION.Add(fila);
                }
                else
                {
                    Copiar(loc, ref fila);
                }

                context.SaveChanges();
                return fila;
            }
        }

        public List<REGION> CargarComboRegion()
        {
            using (var context = new portafolio())
            {
                List<REGION> listado = context.REGION.ToList();
                return listado;
            }
        }

        public List<COMUNA> CargarComboComuna(int regionId)
        {
            using (var context = new portafolio())
            {
                List<COMUNA> listado = context.COMUNA.Where(c=> c.REGIONID==regionId).ToList();
                return listado;
            }
        }

        public int BuscarIdLocalizacion(string direccion, int comunaID)
        {
            using (var context = new portafolio())
            {
                LOCALIZACION loc = context.LOCALIZACION.Where(c => c.COMUNAID == comunaID && c.NOMBRELOCALIZACION == direccion).FirstOrDefault();

                return int.Parse(loc.LOCALIZACIONID.ToString());
            }
        }

        public void Eliminar(int localizacionId)
        {
            using (var context = new portafolio())
            {
                LOCALIZACION loc = context.LOCALIZACION.Where(c => c.LOCALIZACIONID == localizacionId).FirstOrDefault();

                context.LOCALIZACION.Remove(loc);
                context.SaveChanges();
            }
        }

        public LOCALIZACION BuscarLocalizacion(int localizacionId)
        {
            using (var context = new portafolio())
            {
                LOCALIZACION loc = context.LOCALIZACION.Where(c => c.LOCALIZACIONID == localizacionId).FirstOrDefault();

                return loc;
            }
        }

        public COMUNA BuscarComuna(int comunaId)
        {
            using (var context = new portafolio())
            {
                COMUNA comu = context.COMUNA.Where(c => c.COMUNAID == comunaId).FirstOrDefault();

                return comu;
            }
        }

    }
}
