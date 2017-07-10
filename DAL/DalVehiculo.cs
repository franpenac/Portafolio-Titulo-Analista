using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalVehiculo
    {
        public VEHICULO GetVehiculoPorPatenteRut(string rut, string patente)
        {
            try
            {
                using (var context = new portafolio())
                {
                    VEHICULO v = (from vh in context.VEHICULO where vh.RUTCLIENTE == rut && vh.PATENTE == patente select vh).FirstOrDefault();
                    return v;
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
