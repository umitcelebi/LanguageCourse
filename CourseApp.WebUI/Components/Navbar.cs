using CourseApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.WebUI.Components
{
    public class Navbar:ViewComponent
    {
        private IBranchRepository branchRepo;
        private ICourseRepository courseRepo;
        public Navbar(IBranchRepository _branchRepo, ICourseRepository _courseRepo)
        {
            branchRepo = _branchRepo;
            courseRepo = _courseRepo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Branchs = branchRepo.GetAll();
            ViewBag.Courses = courseRepo.GetAll();
            return View();
        }
    }
}
