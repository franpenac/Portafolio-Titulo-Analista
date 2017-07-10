using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Negocio.SupportClasses;
using DAL.SupportClasses;
using NEGOCIO.ObjApoyo;

namespace NEGOCIO.ObjNegocio
{
    public class NegocioVehiculo
    {
        public SupportVehiculo GetVehiculoPorRutPatente(string rut, string patente)
        {
            VEHICULO v = new DAL.DalVehiculo().GetVehiculoPorPatenteRut(rut, patente);
            if (v != null)
            {          
                SupportVehiculo vehiculo = new SupportVehiculo();
                vehiculo.RUTCLIENTE = v.RUTCLIENTE;
                vehiculo.NOMBRECLIENTE = v.NOMBRECLIENTE;
                vehiculo.MARCAVEHICULO = v.MARCAVEHICULO;
                vehiculo.MODELOVEHICULO = v.MODELOVEHICULO;
                vehiculo.PATENTE = v.PATENTE;
                return vehiculo;
            }else
            {
                return null;
            }
        }
    }
}
