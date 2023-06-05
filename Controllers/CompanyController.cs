using OfficeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OfficeManagement.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Company company)
        {

            OMContext db = new OMContext();
            db.Companies.Add(company);
            db.SaveChanges();
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult RqstProject() 
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult RqstProject(RquestProject rquestProject)
        {
            OMContext db = new OMContext();
            db.Projects.Add(rquestProject);
            db.SaveChanges();
            return RedirectToAction("Index", "Company");

        }

        [HttpGet]
        public ActionResult ShowProject()
        {
            OMContext db = new OMContext();
            var comp = db.Projects.ToList();
            return View(comp);
        }
        //public ActionResult AddComp(Company company)
        //{

        //    OMContext db = new OMContext();
        //    db.Companies.Add(company);
        //    db.SaveChanges();
        //    return RedirectToAction("Login", "Home");
        //}
    }
}