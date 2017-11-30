using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace quizfun.Models
{
    public class Tema
    {
        public int TemaId { get; set; }
        [Required(ErrorMessage ="El Nombre es necesario")]
        public string Nombre { get; set; }
        public string Puntos { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

    }
}