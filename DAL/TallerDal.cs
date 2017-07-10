using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TallerDal
    {
        public void Copiar(TALLER objEntrada, ref TALLER objDestino)
        {
            objDestino.LOCATIONID = objEntrada.LOCATIONID;
            objDestino.TALLERID = objEntrada.TALLERID;
            objDestino.NOMBRETALLER = objEntrada.NOMBRETALLER;

        }

        public TALLER Guardar(TALLER loc)
        {
            using (var context = new portafolio())
            {
                TALLER fila = context.TALLER.Where(c => c.TALLERID == loc.TALLERID).FirstOrDefault();

                if (fila == null)
                {
                    fila = new TALLER();
                    Copiar(loc, ref fila);
                    context.TALLER.Add(fila);
                }
                else
                {
                    Copiar(loc, ref fila);
                }

                context.SaveChanges();
                return fila;
            }
        }

        public bool Existe(string nombre)
        {
            using (var context = new portafolio())
            {
                TALLER tall = context.TALLER.Where(c => c.NOMBRETALLER == nombre).FirstOrDefault();

                if (tall==null)
                {
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<Object> CargarGrilla()
        {
                using (var context = new portafolio())
                {
                    IEnumerable<object> list =
                        (from taller in context.TALLER
                         join localizacion in context.LOCALIZACION on taller.LOCATIONID equals localizacion.LOCALIZACIONID
                         join comuna in context.COMUNA on localizacion.COMUNAID equals comuna.COMUNAID
                         join region in context.REGION on comuna.REGIONID equals region.REGIONID
                         select new
                         {
                             Taller = taller.NOMBRETALLER,
                             Region = taller.LOCALIZACION.COMUNA.REGION.NOMBREREGION,
                             Comuna = taller.LOCALIZACION.COMUNA.NOMBRECOMUNA,
                             Direccion = taller.LOCALIZACION.NOMBRELOCALIZACION
                         }).ToList();
                    return list;
                }
        }

        public void Eliminar(int tallerId)
        {
            using (var context = new portafolio())
            {
                TALLER tall = context.TALLER.Where(c => c.TALLERID == tallerId).FirstOrDefault();

                context.TALLER.Remove(tall);
                context.SaveChanges();
            }
        }

        public List<TALLER> CargarComboTaller()
        {
            using (var context = new portafolio())
            {
                List<TALLER> listado = context.TALLER.ToList();
                return listado;
            }
        }

        public TALLER BuscarTaller(int tallerId)
        {
            using (var context = new portafolio())
            {
                TALLER tall = context.TALLER.Where(c => c.TALLERID == tallerId).FirstOrDefault();

                return tall;
            }
        }

        public bool ValidarNombre(string nombre)
        {
            using (var context = new portafolio())
            {
                TALLER tall = (from t in context.TALLER where t.NOMBRETALLER == nombre select t).FirstOrDefault();
                if (tall!=null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}

