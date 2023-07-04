using Practical_15_FormAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Practical_15_FormAuthentication.Controllers
{
    public class AccountController : Controller
    {
        FormAuthenticationEntities db = new FormAuthenticationEntities();
        public ActionResult Login()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Login(User user)
        {

            var test = db.Users.FirstOrDefault(x => x.UserName == user.UserName);

            if (test == null)
            {
                TempData["Message"] = "User id and password is invalid!";
                return RedirectToAction("Login");
            }

            if (test.Password == user.Password)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Please Enter the valid Id And Password");
            return View();
        }

        public ActionResult Logout()
        {
            ViewBag.User = User.Identity.Name;
            FormsAuthentication.SignOut();
            return View();
        }

        public ActionResult Signin()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Signin(User user)
        {
            var test = db.Users.Where(x => x.UserName.ToLower() == user.UserName.ToLower()).FirstOrDefault();
            if (test != null)
            {
                TempData["Message"] = "User Already Registered try different or Signup";
                return View(user);
            }
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}