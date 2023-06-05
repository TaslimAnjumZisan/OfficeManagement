using OfficeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace OfficeManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Login page.";

            return View();
        }

       
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                OMContext db = new OMContext();
                var admin = (from user in db.Admins
                             where user.Email.Equals(login.Email) && user.Password.Equals(login.Password)
                             select user).SingleOrDefault();
                var emp = (from user in db.Employees
                           where user.Email.Equals(login.Email) && user.Password.Equals(login.Password)
                           select user).SingleOrDefault();
                var comp = (from user in db.Companies
                            where user.Email.Equals(login.Email) && user.Password.Equals(login.Password)
                            select user).SingleOrDefault();
                if (admin != null)
                {
                    Session["user"] = admin;
                    Session["id"] = admin.Id;
                    var retUrl = Request["ReturnUrl"];
                    if (retUrl != null)
                    {
                        return Redirect(retUrl);
                    }
                    return RedirectToAction("Index", "Admin");
                }
                else if (emp != null)
                {
                    Session["user"] = emp;
                    Session["id"] = emp.Id;
                    var retUrl = Request["ReturnUrl"];
                    if (retUrl != null)
                    {
                        return Redirect(retUrl);
                    }
                    return RedirectToAction("Index", "Employee");
                }
                else if (comp != null)
                {
                    Session["user"] = comp;
                    Session["id"] = comp.Id;
                    var retUrl = Request["ReturnUrl"];
                    if (retUrl != null)
                    {
                        return Redirect(retUrl);
                    }
                    return RedirectToAction("Index", "Company");
                }
                else
                {
                    Session["user"] = null;
                    ViewBag.Error = "Username Password invalid";
                }
            }
            //ViewBag.Message = "Username Password invalid";
            return View();
        }

    }
}