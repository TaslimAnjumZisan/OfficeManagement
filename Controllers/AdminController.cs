using Microsoft.Ajax.Utilities;
using OfficeManagement.Author;
using OfficeManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace OfficeManagement.Controllers
{
    public class AdminController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            OMContext db = new OMContext();
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("ShowEmployee", "Admin");
        }
        [HttpGet]
        public ActionResult ShowEmployee()
        {
            OMContext db = new OMContext();
            var employees = db.Employees.ToList();
            return View(employees);
        }
        [HttpGet]
        public ActionResult UpDelEmployee(int id)
        {
            OMContext db = new OMContext();
            var emp = (from user in db.Employees
            where user.Id.Equals(id)
            select user).SingleOrDefault();
            return View(emp);
        }
        [HttpPost]
        public ActionResult UpDelEmployee(Employee emp)
        {
            OMContext db = new OMContext();
            var exemp = db.Employees.Find(emp.Id);
            if (exemp != null)
            {
                db.Entry(exemp).CurrentValues.SetValues(emp);
                db.SaveChanges();
            }
            return RedirectToAction("ShowEmployee", "Admin");
        }

        //public ActionResult UpdateEmployee(Employee emp)
        //{
        //    OMContext db = new OMContext();
        //    var exemp = db.Employees.Find(emp.Id);
        //    if (exemp != null)
        //    {
        //        db.Entry(exemp).CurrentValues.SetValues(emp);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("ShowEmployee", "Admin");
        //}
        public ActionResult DeleteEmployee(int id)
        {
            OMContext db = new OMContext();
            var emp = (from user in db.Employees
                       where user.Id.Equals(id)
                       select user).SingleOrDefault();
            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("ShowEmployee", "Admin");
        }
    }
}