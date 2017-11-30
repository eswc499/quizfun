using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class IndeController : Controller
    {
        // GET: Inde
        public ActionResult Inde(string nombre)
        {
            ViewBag.nombre = nombre;
            ViewBag.Title = "Cursos";
            return View();
        }
    }
}