using OfficeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OfficeManagement.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                OMContext db = new OMContext();
              
                var admin = (from u in db.Admins
                             where u.Name.Equals(login.Name)
                             && u.Password.Equals(login.Password)
                             select u).SingleOrDefault();


                
                
                if (admin != null)
                {
                    Session["admin"] = admin;
                    var retUrl = Request["ReturnUrl"];
                    if (retUrl != null)
                    {
                        return Redirect(retUrl);
                    }
                    return RedirectToAction("Index", "Admin");
                }
            }
            TempData["Msg"] = "Username Password invalid";
            return View(login);

            
        }

        
        public ActionResult Index()
        {
            return View();
        }
    }
}