using quizfun;
using quizfun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class quizController : Controller
    {
        QuizContext db = new QuizContext();
        // GET: quiz
        [HttpGet]
        public ActionResult quiz()
        {
            ViewBag.score = 0;
            var qz=db.Pregunta.Find(1);
            return View(qz);
        }

        [HttpPost]
        public ActionResult quiz(int value, int? id,int? score)
        {
            if (id == null)
            {
                id = 2;
            }
            var finp = db.Pregunta.Find(id-1);
            if (int.Parse(finp.respuesta) == value)
            {
                score = score +2;
            }

            var qz = db.Pregunta.Find(id);
            ViewBag.id = id + 1;
            ViewBag.value = value;
            ViewBag.score = score;
            return View(qz);
        }

        [HttpGet]
        public ActionResult CreatePregunta()
        {
            lista();
            return View();
        }

        [HttpPost]
        public ActionResult CreatePregunta(Pregunta preg)
        {
            lista();
            if (ModelState.IsValid)
            {
                db.Pregunta.Add(preg);
                db.SaveChanges();
                ModelState.Clear();
            }
            return View();
        }

        public void lista()
        {
            List<Tema> lista = db.Tema.ToList();
            SelectList ls = new SelectList(lista, "TemaId", "Nombre");
            ViewBag.lista = ls;
        }
    }
}