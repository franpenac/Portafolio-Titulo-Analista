using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.SupportClasses
{
    [Serializable]
    public class SupportRepuestoAlternativo
    {
        public int RepuestoAlternativoId { get; set; }
        public int ModeloId { get; set; }
        public int ProveedorId { get; set; }
        public int TipoProductoId { get; set; }
        public int Costo { get; set; }
        public string ProductoNombre { get; set; }
        public int Cantidad { get; set; }
    }
}
