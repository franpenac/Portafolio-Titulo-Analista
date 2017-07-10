using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO.ObjApoyo
{
    public class SupportVehiculoMantencion
    {
        public int PAQUETEMANTENCIONID { get; set; }
        public int IDVEHICULOMANTENCION { get; set; }
        public string PATENTE { get; set; }
        public DateTime FECHAENTRADA { get; set; }
        public DateTime FECHASALIDA { get; set; }
    }
}
