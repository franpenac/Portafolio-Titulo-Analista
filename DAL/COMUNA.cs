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
    
    public partial class COMUNA
    {
        public COMUNA()
        {
            this.LOCALIZACION = new HashSet<LOCALIZACION>();
        }
    
        public decimal COMUNAID { get; set; }
        public decimal REGIONID { get; set; }
        public string NOMBRECOMUNA { get; set; }
    
        public virtual REGION REGION { get; set; }
        public virtual ICollection<LOCALIZACION> LOCALIZACION { get; set; }
    }
}