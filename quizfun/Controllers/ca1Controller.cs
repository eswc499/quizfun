using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quizfun.Controllers
{
    public class ca1Controller : Controller
       
    {
        QuizContext db = new QuizContext();
        // GET: ca1C:\Users\USUARIO\Source\Repos\quizfun3\quizfun\Content\
        public ActionResult ca1(int cuentaId)
        {
            ViewBag.CuentaId = cuentaId;
            var tema = db.Tema
                .Where(x=>x.Curso.Nombre=="Matematica");
            var curso = db.Curso.Find(1);
            ViewBag.nomcurso = curso.Nombre;
            ViewBag.desccurso = curso.Descripcion;
            return View(tema.ToList());
        }
    }
}