using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEGOCIO.ObjApoyo;
using DAL;

namespace NEGOCIO.ObjNegocio
{
    public class LocalizacionNeg
    {
        public int Guardar(LocalizacionApoyo apoyo)
        {
            LOCALIZACION loc = new LOCALIZACION();
            loc.LOCALIZACIONID = apoyo.LocalizacionId;
            loc.COMUNAID = apoyo.ComunaId;
            loc.NOMBRELOCALIZACION = apoyo.Direccion;

            loc = new LocalizacionDal().Guardar(loc);
            if (loc == null)
            {
                return 0;
            }
            return BuscarIdLocalizacion(loc.NOMBRELOCALIZACION, int.Parse(loc.COMUNAID.ToString()));
        }

        public List<RegionApoyo> CargarComboRegion()
        {
            List<REGION> objDal = new LocalizacionDal().CargarComboRegion();
            List<RegionApoyo> listado = new List<RegionApoyo>();

            foreach (var item in objDal)
            {
                RegionApoyo reg = new RegionApoyo();

                reg.RegionId = int.Parse(item.REGIONID.ToString());
                reg.RegionNombre = item.NOMBREREGION;

                listado.Add(reg);
            }

            return listado;
        }

        public List<ComunaApoyo> CargarComboComuna(int regionId)
        {
            List<COMUNA> objDal = new LocalizacionDal().CargarComboComuna(regionId);
            List<ComunaApoyo> listado = new List<ComunaApoyo>();

            foreach (var item in objDal)
            {
                ComunaApoyo comu = new ComunaApoyo();

                comu.ComunaId = int.Parse(item.COMUNAID.ToString());
                comu.ComunaNombre = item.NOMBRECOMUNA;

                listado.Add(comu);
            }

            return listado;
        }

        public int BuscarIdLocalizacion(string direccion, int comunaID)
        {
            return new LocalizacionDal().BuscarIdLocalizacion(direccion, comunaID);
        }

        public void Eliminar(int localizacionId)
        {
            new LocalizacionDal().Eliminar(localizacionId);
        }

        public LocalizacionApoyo BuscarLocalizacion(int localizacionId)
        {
            LOCALIZACION loc = new LocalizacionDal().BuscarLocalizacion(localizacionId);
            LocalizacionApoyo nuevaLocalizacion = new LocalizacionApoyo();

            nuevaLocalizacion.LocalizacionId = int.Parse(loc.LOCALIZACIONID.ToString());
            nuevaLocalizacion.ComunaId = int.Parse(loc.COMUNAID.ToString());
            nuevaLocalizacion.Direccion = loc.NOMBRELOCALIZACION;

            return nuevaLocalizacion;

        }

        public ComunaApoyo BuscarComuna(int comunaId)
        {
            COMUNA comu = new LocalizacionDal().BuscarComuna(comunaId);
            ComunaApoyo nuevaComuna = new ComunaApoyo();

            nuevaComuna.RegionId = int.Parse(comu.REGIONID.ToString());
            nuevaComuna.ComunaId = int.Parse(comu.COMUNAID.ToString());
            nuevaComuna.ComunaNombre = comu.NOMBRECOMUNA;

            return nuevaComuna;

        }
    }
}
