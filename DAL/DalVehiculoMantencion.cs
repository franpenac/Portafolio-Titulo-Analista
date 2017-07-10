using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalVehiculoMantencion
    {
        public List<VEHICILOMANTENCION> ListaVehiculoMantencionPorDia(DateTime fecha)
        {
            try
            {
                using (var context = new portafolio())
                {
                    DateTime date = fecha.Date;
                    List<VEHICILOMANTENCION> list = (from vehiculoMantencion in context.VEHICILOMANTENCION where vehiculoMantencion.FECHAENTRADA == date select vehiculoMantencion).ToList();
                    if (list.Count > 0)
                    {
                        return list;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public VEHICILOMANTENCION GetVehiculoMantencionPorPatente(string patente)
        {
            try
            {
                using (var context = new portafolio())
                {
                    VEHICILOMANTENCION obj = (from vm in context.VEHICILOMANTENCION where vm.PATENTE == patente select vm).FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}
