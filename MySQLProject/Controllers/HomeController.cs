using MySQLProject.Models;
using MySQLProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySQLProject.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext db = new MyDbContext();
        public ActionResult Index()
        {
            List<Student> s = db.Students.ToList();
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
    }
}