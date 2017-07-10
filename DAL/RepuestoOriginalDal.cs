using DAL.SupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepuestoOriginalDal
    {
        //Entities1 es el nombre del modelo de entidades del ORM
        portafolio contexto;
        public List<REPUESTOORIGINAL> CargarComboRepuesto()
        {
            using (var context = new portafolio())
            {
                List<REPUESTOORIGINAL> listado = context.REPUESTOORIGINAL.ToList();
                return listado;
            }
        }

        public void Eliminar(int localizacionId)
        {
            using (var context = new portafolio())
            {
                REPUESTOORIGINAL loc = context.REPUESTOORIGINAL.Where(c => c.REPUESTOORIGINALID == localizacionId).FirstOrDefault();

                context.REPUESTOORIGINAL.Remove(loc);
                context.SaveChanges();
            }
        }

        public int BuscarModelo(int tallerId)
        {
            using (var context = new portafolio())
            {
                MODELO tall = context.MODELO.Where(c => c.MODELOID == tallerId).FirstOrDefault();

                return int.Parse(tall.MARCAID.ToString());
            }
        }

        public REPUESTOORIGINAL BuscarTaller(int tallerId)
        {
            using (var context = new portafolio())
            {
                REPUESTOORIGINAL tall = context.REPUESTOORIGINAL.Where(c => c.REPUESTOORIGINALID == tallerId).FirstOrDefault();

                return tall;
            }
        }

        public string ModeloPorIdRepuesto(int id)
        {
            using (var context = new portafolio())
            {
                MODELO model = context.MODELO.Where(m=> m.MODELOID==id).FirstOrDefault();
                return model.NOMBREMODELO;
            }
        }

        public IEnumerable<Object> CargarGrilla()
        {
            using (var context = new portafolio())
            {
                IEnumerable<object> list =
                    (from repuesto in context.REPUESTOORIGINAL
                     join prov in context.PROVEEDOR on repuesto.PROVEEDORID equals prov.PROVEEDORID
                     join tipo in context.TIPOPRODUCTO on repuesto.TIPOPRODUCTOID equals tipo.TIPOPRODUCTOID
                     join model in context.MODELO on repuesto.MODELOID equals model.MODELOID
                     join marca in context.MARCA on model.MARCAID equals marca.MARCAID
                     select new
                     {
                         Proveedor = repuesto.PROVEEDOR.NOMBREPROVEEDOR,
                         Tipo = repuesto.TIPOPRODUCTO.NOMBRETIPO,
                         Marca = repuesto.MODELO.MARCA.NOMBREMARCA,
                         Modelo = repuesto.MODELO.NOMBREMODELO,
                         Costo = repuesto.COSTO
                     }).ToList();
                return list;
            }
        }

        public REPUESTOORIGINAL InsertarRepuesto(REPUESTOORIGINAL repuesto)
        {
            contexto = new portafolio();
            try
            {
                if (repuesto != null)
                {
                    repuesto.REPUESTOORIGINALID = 0;
                    contexto.REPUESTOORIGINAL.Add(repuesto);
                    contexto.SaveChanges();
                }
                return repuesto;  
            } 
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public REPUESTOORIGINAL Editar(REPUESTOORIGINAL repuesto)
        {
            using (var context = new portafolio())
            {
                REPUESTOORIGINAL fila = context.REPUESTOORIGINAL.Where(c => c.REPUESTOORIGINALID == repuesto.REPUESTOORIGINALID).FirstOrDefault();

                if (fila != null)
                {
                    Copiar(repuesto, ref fila);
                }

                context.SaveChanges();
                return fila;
            }
        }

        public void Copiar(REPUESTOORIGINAL objEntrada, ref REPUESTOORIGINAL objDestino)
        {
            objDestino.REPUESTOORIGINALID = objEntrada.REPUESTOORIGINALID;
            objDestino.PROVEEDORID = objEntrada.PROVEEDORID;
            objDestino.TIPOPRODUCTOID = objEntrada.TIPOPRODUCTOID;
            objDestino.MODELOID = objEntrada.MODELOID;
            objDestino.COSTO = objEntrada.COSTO;

        }

        public List<REPUESTOORIGINAL> ListarRepuestos()
        {
            List<REPUESTOORIGINAL> lista = new List<REPUESTOORIGINAL>();

            using (contexto = new portafolio())
            {
                var listaRepuestos = from repuesto in contexto.REPUESTOORIGINAL
                                     select repuesto;

                if (listaRepuestos.Count() > 0)
                {
                    foreach (REPUESTOORIGINAL rep in listaRepuestos)
                    {
                        lista.Add(rep);
                    }
                    return lista;
                }
            }
            return null;
        }


        public REPUESTOORIGINAL BuscarRepuesto(int id)
        {
            try
            {
                using (var context = new portafolio())
                {
                    REPUESTOORIGINAL rep = context.REPUESTOORIGINAL.Where(c => c.REPUESTOORIGINALID == id).FirstOrDefault();

                    return rep;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EliminarRepuesto(int id)
        {

            try
            {
                using (var context = new portafolio())
                {
                    REPUESTOORIGINAL rep = context.REPUESTOORIGINAL.Where(c => c.REPUESTOORIGINALID == id).FirstOrDefault();

                    context.REPUESTOORIGINAL.Remove(rep);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<RepuestoOriginalToDdl> GetRepuestosOriginales(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (portafolio context = new portafolio())
                {

                    List<RepuestoOriginalToDdl> listRepuestosOriginales = (from modelo in context.MODELO
                                                                           join marcaProducto in context.MARCA on modelo.MARCAID equals marcaProducto.MARCAID
                                                                           join repuestoOriginal in context.REPUESTOORIGINAL on modelo.MODELOID equals repuestoOriginal.MODELOID
                                                                           select new RepuestoOriginalToDdl
                                                                           {

                                                                               ModeloId = modelo.MODELOID,
                                                                               NombreModelo = marcaProducto.NOMBREMARCA + " " + modelo.NOMBREMODELO,
                                                                               RepuestoOriginalId = repuestoOriginal.REPUESTOORIGINALID

                                                                           }).ToList();
                    if (listRepuestosOriginales == null)
                    {
                        errorMessage = "No existe repuesto";
                        return null;
                    }
                    else
                        return listRepuestosOriginales;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return null;
            }
        }

        public REPUESTOORIGINAL GetRepuestoOriginalPorId(int repuestoId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (portafolio context = new portafolio())
                {
                    REPUESTOORIGINAL repuesto = (from repuestoOriginal in context.REPUESTOORIGINAL
                                                 where repuestoOriginal.REPUESTOORIGINALID == repuestoId
                                                 select repuestoOriginal).FirstOrDefault();
                    if (repuesto == null)
                    {
                        errorMessage = "No existe repuesto";
                        return null;
                    }
                    else
                        return repuesto;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return null;
            }
        }

        public string GerRepuestoOriginalNombre(int modeloId)
        {
            try
            {
                using (portafolio context = new portafolio())
                {
                    string nombreRepuesto = "";
                    List<string> nombres = (from model in context.MODELO
                                            where model.MODELOID == modeloId
                                            join marca in context.MARCA on model.MARCAID equals marca.MARCAID
                                            select marca.NOMBREMARCA + " " + model.NOMBREMODELO
                                     ).ToList();
                    foreach (string item in nombres)
                    {
                        nombreRepuesto = item;
                    }
                    return nombreRepuesto;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
            