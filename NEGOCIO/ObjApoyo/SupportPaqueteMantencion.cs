using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Negocio.SupportClasses
{
    public class SupportPaqueteMantencion
    {
        public int PaqueteMantencionId { get; set; }
        public string NombrePaqueteMantencion { get; set; }
        public int  CostoTotal { get; set; }
        public int DuracionDias { get; set; }
        public string Descripcion { get; set; }
    }
}
