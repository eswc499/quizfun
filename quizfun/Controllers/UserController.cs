using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quizfun.Models;
using quizfun.Repos;
using quizfun.Services;
using System.Web.Http;
using System.Web.Security;

namespace quizfun.Controllers
{
    public class UserController : Controller
    {
        private IUserService userservice;
        private string id;

        public List<Cuenta> ListUsers { get; private set; }

        public UserController()
        {
            this.userservice = new UserService();
        }



        // GET: Speaker
        public ActionResult Index()
        {
            return View(userservice.ReaderUser());
        }

        // GET: Speaker/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: Speaker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Speaker/Create
        [System.Web.Mvc.HttpPost]
        public ActionResult Create(Cuenta user)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {

                    if (userservice.CreateUser(user))
                    {
                        ViewBag.Message = "Usuario correctamente agregado";
                        ModelState.Clear();
                    }
                }
                
                return View();
            }
            catch
            {
                return View();
            }
        }



        // POST: Speaker/Edit/5
        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(Cuenta user)
        {
            try
            {
                //speakerservice.UpdateSpeaker(speaker);
                //return RedirectToAction("Index");
                if (ModelState.IsValid)
                {

                    if (userservice.UpdateUser(user))
                    {
                        ViewBag.Message = "Speaker Update Successfully";
                        //ModelState.Clear();
                    }
                }
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }
    

        // GET: Speaker/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                if (userservice.DeleteUser(id))
                {
                    ViewBag.AlertMsg = "Speaker Deleted Successfully";
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
