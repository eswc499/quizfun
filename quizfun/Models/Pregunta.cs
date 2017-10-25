using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace quizfun.Models
{
    public class Pregunta
    {
        public String Problema { get; set; }
        public int Tiempo { get; set; }
        public String alt1 { get; set; }
        public String alt2 { get; set; }
        public String alt3 { get; set; }
        public String respuesta { get; set; }
    }
}