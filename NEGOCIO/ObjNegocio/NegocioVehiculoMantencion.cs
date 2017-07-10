using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEGOCIO.ObjApoyo;
using Negocio.SupportClasses;
using DAL;
using NEGOCIO.Modelos;
using Negocio;

namespace NEGOCIO.ObjNegocio
{
    public class NegocioVehiculoMantencion
    {
        public List<SupportVehiculoMantencion> ListaVehiculoMantencionPorDia(DateTime fecha)
        {
            List<VEHICILOMANTENCION> list1 = new DAL.DalVehiculoMantencion().ListaVehiculoMantencionPorDia(fecha);
            List<SupportVehiculoMantencion> list2 = new List<SupportVehiculoMantencion>();
            if (list1 != null)
            {
                foreach (VEHICILOMANTENCION item in list1)
                {
                    SupportVehiculoMantencion vehiculoMantencion = new SupportVehiculoMantencion();
                    vehiculoMantencion.IDVEHICULOMANTENCION = int.Parse(item.IDVEHICILOMANTENCION.ToString());
                    vehiculoMantencion.PAQUETEMANTENCIONID = int.Parse(item.PAQUETEMANTENCIONID.ToString());
                    vehiculoMantencion.PATENTE = item.PATENTE;
                    vehiculoMantencion.FECHAENTRADA = item.FECHAENTRADA;
                    vehiculoMantencion.FECHASALIDA = item.FECHASALIDA.Value;
                    list2.Add(vehiculoMantencion);
                }
                return list2;
            }else
            {
                return null;
            }

        }

        public List<ModeloRepuestoUtilizado> listaRepuestosPorDia(DateTime fecha)
        {
            string errorMessage = "";
            List<ModeloRepuestoUtilizado> listaRepuestos = new List<ModeloRepuestoUtilizado>();
            List<SupportVehiculoMantencion> listaVehiculoMantencion = ListaVehiculoMantencionPorDia(fecha);
            if (listaRepuestos != null)
            {
                if (listaVehiculoMantencion != null)
                {
                    foreach (SupportVehiculoMantencion item in listaVehiculoMantencion)
                    {
                        List<SupportRepuestoOriginalUtilizado> listaRepuestosOriginales = new Negocio.NegocioRepuestoOriginalUtilizado().GetProductosUtilizadosPorPaqueteMantencionId(item.PAQUETEMANTENCIONID, out errorMessage);
                        foreach (SupportRepuestoOriginalUtilizado item2 in listaRepuestosOriginales)
                        {
                            ModeloRepuestoUtilizado modeloRepuesto = new ModeloRepuestoUtilizado();
                            ModeloApoyo modelo = new ModeloC().GetModeloById(item2.RepuestoOriginalId);
                            MarcaApoyo marca = new MarcaC().GetMarcaById(modelo.MarcaId);
                            modeloRepuesto.marcaRepuesto = marca.MarcaNombre;
                            modeloRepuesto.modeloRepuesto = modelo.ModeloNombre;
                            modeloRepuesto.cantidadUtilizados = item2.Cantidad;
                            listaRepuestos.Add(modeloRepuesto);
                        }
                    }
                }
                else
                    return null;

            }
            else return null;
            if (listaVehiculoMantencion != null)
            {
                foreach (SupportVehiculoMantencion item in listaVehiculoMantencion)
                {
                    List<SupportRepuestoAlternativoUtilizado> listaRepuestosAlternativos = new Negocio.NegocioRepuestoAlternativoUtilizado().GetProductosUtilizadosPorPaqueteMantencionId(item.PAQUETEMANTENCIONID, out errorMessage);
                    foreach (SupportRepuestoAlternativoUtilizado item2 in listaRepuestosAlternativos)
                    {
                        ModeloRepuestoUtilizado modeloRepuesto = new ModeloRepuestoUtilizado();
                        ModeloApoyo modelo = new ModeloC().GetModeloById(item2.RepuestoAlternativoId);
                        MarcaApoyo marca = new MarcaC().GetMarcaById(modelo.MarcaId);
                        modeloRepuesto.marcaRepuesto = marca.MarcaNombre;
                        modeloRepuesto.modeloRepuesto = modelo.ModeloNombre;
                        modeloRepuesto.cantidadUtilizados = item2.Cantidad;
                        listaRepuestos.Add(modeloRepuesto);
                    }
                }
            }
            else
                return null;

            if (listaRepuestos.Count != 0)
            {
                return listaRepuestos;
            }else
            {
                return null;
            }

        }

        public SupportVehiculoMantencion GetVehiculoMantencionPorPatente(string patente)
        {
            VEHICILOMANTENCION vh = new DalVehiculoMantencion().GetVehiculoMantencionPorPatente(patente);
            if (vh != null)
            {
                SupportVehiculoMantencion vm = new SupportVehiculoMantencion();
                vm.PAQUETEMANTENCIONID = int.Parse(vh.PAQUETEMANTENCIONID.ToString());
                vm.IDVEHICULOMANTENCION = int.Parse(vh.IDVEHICILOMANTENCION.ToString());
                vm.PATENTE = vh.PATENTE;
                vm.FECHAENTRADA = vh.FECHAENTRADA;
                vm.FECHASALIDA = vh.FECHASALIDA.Value;
                return vm;
            }
            else
                return null;
        }

        public List<ModeloMantencionesPorVehiculo> OriginalOrAlternativo(string rut, string patente, int paqueteId)
        {
            string errorMessage = "";
            List<REPUESTOORIGINALUTILIZADO> Ori = new DalRepuestoOriginalUtilizado().GetRepuestosOriginalesutilizadosPorPaqueteMantencionId(paqueteId, out errorMessage);
            List<REPUESTOALTERNATIVOUTILIZADO> alt = new DalRepuestoAlternativoUtilizado().GetRepuestosAlternativosUtilizadosPorPaqueteMantencionId(paqueteId, out errorMessage);
            if (Ori != null)
            {
                return GetMantencionInfoOriginal(rut, patente);
            }
            else if (alt != null)
            {
                return GetMantencionInfoAlternativo(rut, patente);
            }else
            {
                return null;
            }
        }

        public List<ModeloMantencionesPorVehiculo> GetMantencionInfoOriginal(string rut, string patente)
        {
            string errorMessage = "";
            SupportVehiculo vehiculo = new NegocioVehiculo().GetVehiculoPorRutPatente(rut, patente);
            SupportVehiculoMantencion vehiculoMantencion = new NegocioVehiculoMantencion().GetVehiculoMantencionPorPatente(vehiculo.PATENTE);
            SupportPaqueteMantencion paqueteMantencion = new NegocioPaqueteMantencion().GetPaqueteMantencionPorId(vehiculoMantencion.PAQUETEMANTENCIONID, out errorMessage);
            List<SupportRepuestoOriginalUtilizado> ListaSupportOriginal = new NegocioRepuestoOriginalUtilizado().GetProductosUtilizadosPorPaqueteMantencionId(paqueteMantencion.PaqueteMantencionId, out errorMessage);
            List<ModeloMantencionesPorVehiculo> list = new List<ModeloMantencionesPorVehiculo>();
            foreach (SupportRepuestoOriginalUtilizado item in ListaSupportOriginal)
            {
                ModeloMantencionesPorVehiculo mantencionInfo = new ModeloMantencionesPorVehiculo();
                SupportRepuestoOriginal original = new NegocioRepuestoOriginal().GetRepuestoOriginalPorId(item.RepuestoOriginalId, out errorMessage);
                mantencionInfo.nombreRepuesto = original.ProductoNombre;
                mantencionInfo.precioRepuesto = original.Costo;
                mantencionInfo.cantidad = item.Cantidad;
                list.Add(mantencionInfo);
            }
            return list;
        }

        public List<ModeloMantencionesPorVehiculo> GetMantencionInfoAlternativo(string rut, string patente)
        {
            string errorMessage = "";
            SupportVehiculo vehiculo = new NegocioVehiculo().GetVehiculoPorRutPatente(rut, patente);
            SupportVehiculoMantencion vehiculoMantencion = new NegocioVehiculoMantencion().GetVehiculoMantencionPorPatente(vehiculo.PATENTE);
            SupportPaqueteMantencion paqueteMantencion = new NegocioPaqueteMantencion().GetPaqueteMantencionPorId(vehiculoMantencion.PAQUETEMANTENCIONID, out errorMessage);
            List<SupportRepuestoAlternativoUtilizado> ListaSupportAlternativo = new NegocioRepuestoAlternativoUtilizado().GetProductosUtilizadosPorPaqueteMantencionId(paqueteMantencion.PaqueteMantencionId, out errorMessage);
            List<ModeloMantencionesPorVehiculo> list = new List<ModeloMantencionesPorVehiculo>();
            foreach (SupportRepuestoAlternativoUtilizado item in ListaSupportAlternativo)
            {
                ModeloMantencionesPorVehiculo mantencionInfo = new ModeloMantencionesPorVehiculo();
                SupportRepuestoOriginal original = new NegocioRepuestoOriginal().GetRepuestoOriginalPorId(item.RepuestoAlternativoId, out errorMessage);
                mantencionInfo.nombreRepuesto = original.ProductoNombre;
                mantencionInfo.precioRepuesto = original.Costo;
                mantencionInfo.cantidad = item.Cantidad;
                list.Add(mantencionInfo);
            }
            return list;
        }
    }
}
