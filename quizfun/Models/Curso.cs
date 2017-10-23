using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace quizfun.Models
{
    public class Curso
    {
        [Required(ErrorMessage = "El Nombre del curso es necesario")]
        public String Nombre { get; set; }
        [Required(ErrorMessage = "La descripción es necesaria")]
        public String Descripcion { get; set; }
    }
}