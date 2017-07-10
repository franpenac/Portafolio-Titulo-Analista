using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.SupportClasses
{
    public class SupportRepuestoAlternativoUtilizado
    {
        public int RepuestoAlternativoUtilizadoId { get; set; }
        public int RepuestoAlternativoId { get; set; }
        public int PaqueteMantencionId { get; set; }
        public int Cantidad { get; set; }
    }
}
