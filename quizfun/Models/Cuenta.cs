using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quizfun.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        public String Nick { get; set; }

        public String Password { get; set; }
    }
}