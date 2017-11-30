using quizfun.Models;
using quizfun.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quizfun.Controllers
{
    public class CuentaController : Controller
    {
        QuizContext db = new QuizContext();
        // GET: Cuenta
        IUserService usser;
        public CuentaController()
        {
            usser = new UserService();
        }
        public ActionResult Cuenta()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cuenta cu)
        {
            List<Cuenta> cd=null;
            if (ModelState.IsValid)
            {
                cd = usser.ReaderUserId(cu.Nick).ToList();
                    
                if (cd.Count==0)
                {
                    db.Cuenta.Add(cu);
                    db.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Inde", "Inde",new { cuentaId = cu.CuentaId});
                }
                if (cd.Count > 0)
                {
                    ViewBag.Message = "El Nick ya existe";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string nick,string psswd)
        {
            var cuenta = usser.BuscaCuenta(nick, psswd).ElementAt(0);

            if (cuenta!=null)
            {
                return RedirectToAction("Inde","Inde",new { cuentaId=cuenta.CuentaId});
            }

            return View();
        }

    }
}
