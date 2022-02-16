using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterTask.Models;

namespace InterTask.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account ac)
        {
            if (ModelState.IsValid)
            {
                ServiceReference.InterTaskWebServiceSoapClient client = new ServiceReference.InterTaskWebServiceSoapClient();
                string user = client.VerifyLogin(ac.Username, ac.Password);
                if (!string.IsNullOrEmpty(user))
                {
                    Session["username"] = user;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["InvalidMeassage"] = "Your username or password invalid";
                    return View(ac);
                }
            }


            return View();
        }
    }
}