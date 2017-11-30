using quizfun;
using quizfun.Models;
using quizfun.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class quizController : Controller
    {
        QuizContext db = new QuizContext();
        IQuizService qser;
        IUserService tmsr;

        public quizController()
        {
            qser = new QuizService();
            tmsr = new UserService();
        }
        // GET: quiz
        [HttpGet]
        public async Task<ActionResult> quiz(int cuentaId)
        {
            ViewBag.cuentaId = cuentaId;
            ViewBag.score = 0;
            var qz=await db.Pregunta.FindAsync(1);
            return View(qz);
        }

        public ActionResult IndexQuiz()
        {
            return View(db.Pregunta.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> quiz(int value, int? id,int? score, int cuentaId)
        {
            if (id == null)
            {
                id = 2;
            }
            
            ViewBag.cuentaId = cuentaId;
            var finp = await Task.Run(()=>db.Pregunta.FindAsync(id-1));
            var nota = await Task.Run(()=>qser.scoreSum((int)score, value, finp));
            var qz = await Task.Run(()=>db.Pregunta.FindAsync(id));
            if (id == 11)
            {
                Cuenta cuenta = await Task.Run(()=>db.Cuenta.FindAsync(cuentaId));
                tmsr.scoreup(cuenta.Nick, nota);
                await db.SaveChangesAsync();
            }
            ViewBag.id = id + 1;
            ViewBag.score = nota;
            return View(qz);
        }

        [HttpGet]
        public ActionResult CreatePregunta()
        {
            lista();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreatePregunta(Pregunta preg)
        {
            lista();
            if (ModelState.IsValid)
            {
                db.Pregunta.Add(preg);
                await db.SaveChangesAsync();
                ModelState.Clear();
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> DeletePregunta(int id)
        {
            var preg = await db.Pregunta.FindAsync(id);
            return View(preg);
        }

        [HttpPost]
        public async Task<ActionResult> DeletePregunta(int id, Pregunta pre)
        {
            pre = await db.Pregunta.FindAsync(id);
            if (pre != null)
            {
                db.Pregunta.Remove(pre);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("quiz", "IndexQuiz");
        }

        [HttpGet]
        public async Task<ActionResult> EditPregunta(int id)
        {
            lista();
            var preg = await db.Pregunta.FindAsync(id);
            return View(preg);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPregunta([Bind(Include = "PreguntaId,Problema,Tiempo,alt1,alt2,alt3,alt4,respuesta,TemaId")] Pregunta pregunta)
        {
            lista();
            if (ModelState.IsValid)
            {
                db.Entry(pregunta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TemaId = new SelectList(db.Tema, "TemaId", "Nombre", pregunta.TemaId);
            return View(pregunta);
        }

        public void lista()
        {
            List<Tema> lista = db.Tema.ToList();
            SelectList ls = new SelectList(lista, "TemaId", "Nombre");
            ViewBag.lista = ls;
        }
    }
}