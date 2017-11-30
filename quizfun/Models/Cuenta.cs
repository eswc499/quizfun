using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace quizfun.Models
{
    public class Cuenta
    {
        public int CuentaId { get; set; }
        [Required(ErrorMessage = "El nombre es necesario")]
        public String Nombre { get; set; }
        [Required(ErrorMessage = "El Apellido Paterno es necesario")]
        public String Apellido_Paterno { get; set; }
        [Required(ErrorMessage ="El Apellido Materno es necesario")]
        public String Apellido_Materno { get; set; }
        [Required(ErrorMessage = "El Nombre de usuario es necesario")]
        public String Nick { get; set; }
        [Required(ErrorMessage = "La contraseña es necesario")]
        public String Password { get; set; }
        [Required(ErrorMessage ="La ciudad es necesaria")]
        public String Ciudad { get; set; }
        [Required(ErrorMessage = "El colegio es necesario")]
        public String Colegio { get; set; }
        [Required(ErrorMessage = "El Celular es necesario")]
        public Int32 Celular { get; set; }

        
    }
}