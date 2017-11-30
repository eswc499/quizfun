using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quizfun.Repos;
using quizfun.Services;
using quizfun.Models;

namespace quizfun.Controllers
{
    public class CursoController : Controller
    {
        private ICurso cursservice;
        private string namcr;
        private List<Curso> ListCurso { get; set; }
        // GET: Curso
        public CursoController()
        {
            this.cursservice = new CursoService();
        }
        public ActionResult Index(String nmcr)
        {
            var listcurso = cursservice.ReadAllCr();

            if (nmcr != "")
            {
                ListCurso = cursservice.ReadCurso(nmcr);
            }

            return View(ListCurso);

        }

        // GET: Curso/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Curso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Curso/Create
        [HttpPost]
        public ActionResult Create(Curso cr)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    if (cursservice.createCurso(cr))
                    {
                        ViewBag.Message = "Curse Agregado Correctament";
                        ModelState.Clear();
                    }
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        [System.Web.Http.HttpPost]
        // GET: Curso/Edit/5
        public ActionResult Edit(String nmcr, Curso cr)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (cursservice.updateCr(cr))
                    {
                        ViewBag.Message = "Curso Update Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }

       
        // POST: Curso/Delete/5
        [HttpPost]
        public ActionResult Delete(string nmcr)
        {
            try
            {
                if (cursservice.DeleteCr(nmcr))
                {
                    ViewBag.AlertMsg = "Curso Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
