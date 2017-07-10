using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO.ObjApoyo
{
    public class RepuestoAlternativoApoyo
    {
            public int RepuestoAlternativoId { get; set; }
            public int RepuestoOriginalId { get; set; }
            public int ModeloId { get; set; }
            public int TipoProductoId { get; set; }
            public int ProveedorId { get; set; }
            public int Costo { get; set; }
            public string ModeloNombre { get; set; }
            public string TipoProductoNombre { get; set; }
            public string Proveedor { get; set; }
        
    }
}
