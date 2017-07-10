using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.SupportClasses
{
    public class SupportUsuario
    {
        public int PersonaId { get; set; }
        public int PerfilId { get; set; }
        public string RutPersona { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public string EmailPersona { get; set; }
        public string PasswordPersona { get; set; }
        public string PasswordCode { get; set; }
    }
}
