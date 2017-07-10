using DAL.SupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepuestoAlternativoDal
    {
        portafolio contexto;

        public REPUESTOALTERNATIVO InsertarRepuesto(REPUESTOALTERNATIVO repuesto)
        {
            contexto = new portafolio();
            try
            {
                if (repuesto != null)
                {
                    repuesto.REPUESTOALTERNATIVOID = 0;
                    contexto.REPUESTOALTERNATIVO.Add(repuesto);
                    contexto.SaveChanges();
                }
                return repuesto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public REPUESTOALTERNATIVO Editar(REPUESTOALTERNATIVO repuesto)
        {
            using (var context = new portafolio())
            {
                REPUESTOALTERNATIVO fila = context.REPUESTOALTERNATIVO.Where(c => c.REPUESTOALTERNATIVOID == repuesto.REPUESTOALTERNATIVOID).FirstOrDefault();

                if (fila != null)
                {
                    Copiar(repuesto, ref fila);
                }

                context.SaveChanges();
                return fila;
            }
        }

        public void Copiar(REPUESTOALTERNATIVO objEntrada, ref REPUESTOALTERNATIVO objDestino)
        {
            objDestino.REPUESTOALTERNATIVOID = objEntrada.REPUESTOALTERNATIVOID;
            objDestino.MODELOID = objEntrada.MODELOID;
            objDestino.TIPOPRODUCTOID = objEntrada.TIPOPRODUCTOID;
            objDestino.REPUESTOORIGINALID = objEntrada.REPUESTOORIGINALID;
            objDestino.PROVEEDORID = objEntrada.PROVEEDORID;

        }

        public List<REPUESTOALTERNATIVO> ListarRepuestos()
        {
            List<REPUESTOALTERNATIVO> lista = new List<REPUESTOALTERNATIVO>();

            using (contexto = new portafolio())
            {
                var listaRepuestos = from repuesto in contexto.REPUESTOALTERNATIVO
                                     select repuesto;

                if (listaRepuestos.Count() > 0)
                {
                    foreach (REPUESTOALTERNATIVO rep in listaRepuestos)
                    {
                        lista.Add(rep);
                    }
                    return lista;
                }
            }
            return null;
        }

        public REPUESTOALTERNATIVO BuscarRepuesto(int id)
        {
            try
            {
                using (var context = new portafolio())
                {
                    REPUESTOALTERNATIVO rep = context.REPUESTOALTERNATIVO.Where(c => c.REPUESTOALTERNATIVOID == id).FirstOrDefault();

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
                    REPUESTOALTERNATIVO rep = context.REPUESTOALTERNATIVO.Where(c => c.REPUESTOALTERNATIVOID == id).FirstOrDefault();

                    context.REPUESTOALTERNATIVO.Remove(rep);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<RepuestoAlternativoToDdl> GetRepuestosAlternativos(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (portafolio context = new portafolio())
                {

                    List<RepuestoAlternativoToDdl> listRepuestosAlternativos = (from modelo in context.MODELO
                                                                                join marcaProducto in context.MARCA on modelo.MARCAID equals marcaProducto.MARCAID
                                                                                join repuestoAlternativo in context.REPUESTOALTERNATIVO on modelo.MODELOID equals repuestoAlternativo.MODELOID
                                                                                select new RepuestoAlternativoToDdl
                                                                                {

                                                                                    ModeloId = modelo.MODELOID,
                                                                                    NombreModelo = marcaProducto.NOMBREMARCA + " " + modelo.NOMBREMODELO,
                                                                                    RepuestoAlternativoId = repuestoAlternativo.REPUESTOALTERNATIVOID

                                                                                }).ToList();

                    if (listRepuestosAlternativos == null)
                    {
                        return null;
                    }
                    else
                        return listRepuestosAlternativos;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return null;
            }
        }

        public REPUESTOALTERNATIVO GetRepuestoAlternativoPorId(int repuestoId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (portafolio context = new portafolio())
                {
                    REPUESTOALTERNATIVO repuesto = (from repuestoAlternativo in context.REPUESTOALTERNATIVO
                                                    where repuestoAlternativo.REPUESTOALTERNATIVOID == repuestoId
                                                    select repuestoAlternativo).FirstOrDefault();
                    if (repuesto == null)
                    {
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

        public string GerRepuestoAlternativoNombre(int modeloId)
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
