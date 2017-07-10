using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.SupportClasses
{
    public class SupportRepuestoOriginalUtilizado
    {
        public int RepuestoOriginalUtilizadoId { get; set; }
        public int RepuestoOriginalId { get; set; }
        public int PaqueteMantencionId { get; set; }
        public int Cantidad { get; set; }
    }
}
