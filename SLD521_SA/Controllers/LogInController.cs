using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using SLD521_SA.Models;

namespace SLD521_SA.Controllers
{
    public class LogInController : Controller
    {
        SACLAEntities entity = new SACLAEntities();
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(LogInViewModel credentials)
        {
            bool userExist = entity.LogIns.Any(x => x.Username == credentials.Username && x.Password == credentials.Password);
            LogIn u = entity.LogIns.FirstOrDefault(x => x.Username == credentials.Username && x.Password == credentials.Password);

            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(u.Username,false);
                return RedirectToAction("Index","Home");
            }
            ModelState.AddModelError("", "Username or password is incorrect");

            return View();
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}