using quizfun;
using quizfun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class IndeController : Controller
    {
        QuizContext db = new QuizContext();
        // GET: Inde
        public ActionResult Inde(int cuentaId)
        {
            ViewBag.CuentaId = cuentaId;
            ViewBag.Title = "Cursos";
            return View();
        }
    }
}