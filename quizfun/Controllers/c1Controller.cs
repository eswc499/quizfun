﻿using quizfun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class c1Controller : Controller
    {
        QuizContext db = new QuizContext();
        // GET: ca1C:\Users\USUARIO\Source\Repos\quizfun3\quizfun\Content\
        public ActionResult c1()
        {
            var tema = db.Tema
                .Where(x => x.Curso.Nombre == "Comunicacion");
            var curso=db.Curso.Find(2);
            ViewBag.nomcurso = curso.Nombre;
            ViewBag.desccurso = curso.Descripcion;
            return View(tema.ToList());
        }
    }
}