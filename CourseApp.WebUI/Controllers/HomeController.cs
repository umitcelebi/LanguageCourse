using CourseApp.Data.Abstract;
using CourseApp.Entity;
using CourseApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ICourseProgramRepository courseProgramRepository;

        public HomeController(ICourseProgramRepository _courseProgramRepo)
        {
            courseProgramRepository = _courseProgramRepo;
        }
        public IActionResult Index()
        {
            var result = courseProgramRepository.GetAll().ToList();
            return View(result);
        }
    }
}
