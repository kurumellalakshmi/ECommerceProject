using ECommerceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceProject.Controllers
{
    public class RegistrationsController : Controller
    {
        private ApplicationDbContext dbContext = null;

        public RegistrationsController()
        {
            dbContext = new ApplicationDbContext();
        }

        // GET: Registrations
        public ActionResult Index()
        {
            return View(dbContext.logins.ToList());
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                dbContext.logins.Add(login);
                dbContext.SaveChanges();
            }
            ViewBag.Message = login.FirstName + " " + login.LastName + " is successfully registered";
            return RedirectToAction("Index", "Registrations");
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Login register)
        {
            var usr = dbContext.logins.SingleOrDefault(u => u.UserId == register.UserId && u.Password == register.Password);
            if (usr != null)
            {
                Session["UserId"] = usr.UserId.ToString();
                return RedirectToAction("Index", "Categories");
            }
            else
            {
                ModelState.AddModelError("", "Invalid userid and password");
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            Login login = new Login();
            if (Session["UserId"] != null)
            {
                ViewBag.Message = "Welcome" + login.FirstName;
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}