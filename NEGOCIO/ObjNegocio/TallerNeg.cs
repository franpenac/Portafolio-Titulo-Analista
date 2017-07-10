using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEGOCIO.ObjApoyo;
using DAL;

namespace NEGOCIO.ObjNegocio
{
    public class TallerNeg
    {

        public bool Guardar(TallerApoyo apoyo, out string mensaje)
        {
            TALLER tall = new TALLER();
            tall.LOCATIONID = apoyo.LocalizacionId;
            tall.TALLERID = apoyo.TallerId;
            tall.NOMBRETALLER = apoyo.TallerNombre;

            tall = new TallerDal().Guardar(tall);
            if (tall == null)
            {
                mensaje = "No se ha podido registrar el taller, por favor comuniquese con el administrador!";
                return false;
            }

            if (apoyo.TallerId==0)
            {

                mensaje = "Se ha registrado exitosamente el taller: " + tall.NOMBRETALLER;
                return true;
            }
            mensaje = "Se ha modificado exitosamente el taller: " + tall.NOMBRETALLER;
            return true;
        }

        public bool Existe(string nombre)
        {
            return new TallerDal().Existe(nombre);
        }

        public IEnumerable<object> CargarGrilla()
        {
            return new TallerDal().CargarGrilla();
        }

        public List<TallerApoyo> CargarComboTaller()
        {
            List<TALLER> tall = new TallerDal().CargarComboTaller();
            List<TallerApoyo> listado = new List<TallerApoyo>();
            foreach (var item in tall)
            {
                TallerApoyo t = new TallerApoyo();
                t.TallerId = int.Parse(item.TALLERID.ToString());
                t.TallerNombre = item.NOMBRETALLER;
                t.LocalizacionId = int.Parse(item.LOCATIONID.ToString());

                listado.Add(t);
            }
            return listado;
        }

        public void Eliminar(int tallerId, out string mensaje)
        {
            
            new TallerDal().Eliminar(tallerId);
            mensaje = "Se ha eliminado exitosamente el taller.";
        }

        public TallerApoyo BuscarTaller(int tallerId)
        {
            TALLER tall = new TallerDal().BuscarTaller(tallerId);
            TallerApoyo nuevoTaller = new TallerApoyo();

            nuevoTaller.LocalizacionId = int.Parse(tall.LOCATIONID.ToString());
            nuevoTaller.TallerId = int.Parse(tall.TALLERID.ToString());
            nuevoTaller.TallerNombre = tall.NOMBRETALLER;

            return nuevoTaller;
        }

        public bool ValidarNombre(string nombre, out string mensaje)
        {
            mensaje = "";
            if (new TallerDal().ValidarNombre(nombre))
            {
                return true;
            }
            else
            {
                mensaje = "No se puede registrar el taller, debido a que ya existe uno con el mismo nombre!";
                return false;
            }
        }
    }
}
