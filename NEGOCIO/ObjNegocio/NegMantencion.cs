using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO.ObjNegocio
{
    public class NegMantencion
    {
        public IEnumerable<object> CargarGrillaOriginal(string patente)
        {
            return new DalMantencion().CargarGrillaOriginal(patente);
        }

        public IEnumerable<object> CargarGrillaAlternativa(string patente)
        {
            return new DalMantencion().CargarGrillaAlternativo(patente);
        }

        public bool ExistePatente(string patente)
        {
            return new DalMantencion().existePatente(patente);
        }

        public bool ExistePaquete(string patente)
        {
            return new DalMantencion().existePaquete(patente);
        }
    }
}
