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
    
    public partial class PROVEEDOR
    {
        public PROVEEDOR()
        {
            this.REPUESTOALTERNATIVO = new HashSet<REPUESTOALTERNATIVO>();
            this.REPUESTOORIGINAL = new HashSet<REPUESTOORIGINAL>();
        }
    
        public decimal PROVEEDORID { get; set; }
        public string NOMBREPROVEEDOR { get; set; }
    
        public virtual ICollection<REPUESTOALTERNATIVO> REPUESTOALTERNATIVO { get; set; }
        public virtual ICollection<REPUESTOORIGINAL> REPUESTOORIGINAL { get; set; }
    }
}
