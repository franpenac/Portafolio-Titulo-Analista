//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class PAQUETEMANTENCION
    {
        public PAQUETEMANTENCION()
        {
            this.ASIGNACIONPAQMANT = new HashSet<ASIGNACIONPAQMANT>();
            this.REPUESTOORIGINALUTILIZADO = new HashSet<REPUESTOORIGINALUTILIZADO>();
            this.REPUESTOALTERNATIVOUTILIZADO = new HashSet<REPUESTOALTERNATIVOUTILIZADO>();
            this.VEHICILOMANTENCION = new HashSet<VEHICILOMANTENCION>();
        }
    
        public decimal PAQUETEMANTENCIONID { get; set; }
        public string NOMBREPAQUETEMANTENCION { get; set; }
        public decimal COSTOTOTAL { get; set; }
        public decimal DURACIONDIAS { get; set; }
        public string DESCRIPCION { get; set; }
    
        public virtual ICollection<ASIGNACIONPAQMANT> ASIGNACIONPAQMANT { get; set; }
        public virtual ICollection<REPUESTOORIGINALUTILIZADO> REPUESTOORIGINALUTILIZADO { get; set; }
        public virtual ICollection<REPUESTOALTERNATIVOUTILIZADO> REPUESTOALTERNATIVOUTILIZADO { get; set; }
        public virtual ICollection<VEHICILOMANTENCION> VEHICILOMANTENCION { get; set; }
    }
}
