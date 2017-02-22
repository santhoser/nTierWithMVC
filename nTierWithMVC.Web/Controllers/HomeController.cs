using nTierWithMVC.Business;
using nTierWithMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nTierWithMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private IStudentLogic studentLogic;
        public HomeController(IStudentLogic studentLogic)
        {
            this.studentLogic = studentLogic;
        }
        public ActionResult Index()
        {

            List<StudentModel> students =  studentLogic.GetData();
            return View();

        }

        public ActionResult About()
        {
            StudentModel student = new StudentModel() { StudentId = 100004, Name = "Student Four" };

            this.studentLogic.SaveData(student);
            this.studentLogic.Dispose();

            ViewBag.Message = "Saving new Student.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}