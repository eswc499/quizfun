using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace quizfun.Models
{
    public class Tema
    {
        [Required(ErrorMessage ="El Nombre es necesario")]
        public String Nombre { get; set; }
        public Curso Curso { get; set; }

    }
}