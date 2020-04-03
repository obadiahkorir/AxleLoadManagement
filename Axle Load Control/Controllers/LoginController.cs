using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Axle_Load_Control.Models;
using System.Web.Security;



namespace Axle_Load_Control.Controllers
{
    public class LoginController : Controller
    {
        Config config = new Config();
        // GET: Login
        [HttpGet]
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Membership.ValidateUser(model.Email, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            string email = "";
                            var user = config.nav.AxleUsers;
                            foreach (var item in user)
                            {
                                string fname = item.First_Name;
                                string middlename = item.Middle_Name;
                                string lastname = item.Last_Name;
                                Session["name"] = fname + " " + middlename + " " + lastname;
                                email = item.Email;
                            }
                            Session["email"] = email;
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        TempData["error"] = "The user name or password provided is incorrect.";

                    }
                }
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;

            }
            return View(model);
        }
    }
}