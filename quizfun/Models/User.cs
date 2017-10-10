using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quizfun.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Nombre { get; set; }

        public String Apm { get; set; }
        public String App { get; set; }

        public int Celular { get; set; }
        public int DNI { get; set; }
        public String Colegio { get; set; }
    }
}