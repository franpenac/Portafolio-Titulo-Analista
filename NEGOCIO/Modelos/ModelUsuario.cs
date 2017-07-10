using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NEGOCIO.Modelos
{
    public class ModelUsuario
    {
        public decimal idUsuario { get; set; }
        public string rutUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string apellidoUsuario { get; set; }
        public string emailUsuario { get; set; }
        public string perfilUsuario { get; set; }
        public int PerfilUsuarioId { get; set; }
    }
}