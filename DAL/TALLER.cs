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
    
    public partial class TALLER
    {
        public TALLER()
        {
            this.ASIGNACIONPAQMANT = new HashSet<ASIGNACIONPAQMANT>();
            this.ASIGNACIONPRODUCTO = new HashSet<ASIGNACIONPRODUCTO>();
        }
    
        public decimal TALLERID { get; set; }
        public decimal LOCATIONID { get; set; }
        public string NOMBRETALLER { get; set; }
    
        public virtual ICollection<ASIGNACIONPAQMANT> ASIGNACIONPAQMANT { get; set; }
        public virtual ICollection<ASIGNACIONPRODUCTO> ASIGNACIONPRODUCTO { get; set; }
        public virtual LOCALIZACION LOCALIZACION { get; set; }
    }
}
