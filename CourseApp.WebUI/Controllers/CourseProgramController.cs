using CourseApp.Data.Abstract;
using CourseApp.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.WebUI.Controllers
{
    public class CourseProgramController : Controller
    {
        private ICourseProgramRepository courseProgramRepo;
        private ITeacherRepository teacherRepo;
        private IBranchRepository branchRepo;
        private ICourseRepository courseRepo;
        private IStudentRepository StudentRepo;

        public CourseProgramController(ICourseProgramRepository _courseProgramRepo, 
            ITeacherRepository _teacherRepo, 
            IBranchRepository _branchRepo,
            ICourseRepository _courseRepo,
            IStudentRepository _StudentRepo)
        {
            courseProgramRepo = _courseProgramRepo;
            teacherRepo = _teacherRepo;
            branchRepo = _branchRepo;
            courseRepo = _courseRepo;
            StudentRepo = _StudentRepo;
        }
        public IActionResult List() => View(courseProgramRepo.GetAll());

        public IActionResult SearchByBranch(int id)
        {
            return View("List", courseProgramRepo.searchByBranch(id));
        }
        public IActionResult SearchByCourse(int id)
        {
            return View("List", courseProgramRepo.searchByCourse(id));
        }
        public IActionResult SearchByTeacher(int id)
        {
            return View("List", courseProgramRepo.searchByTeacher(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Branchs = new SelectList(branchRepo.GetAll(), "BranchId", "BranchName");
            ViewBag.Courses = new SelectList(courseRepo.GetAll(), "CourseId", "CourseName");
            ViewBag.Teachers = new SelectList(teacherRepo.GetAll(), "TeacherId", "TeacherName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(CoursePrograms courseProgram)
            {
            courseProgramRepo.Add(courseProgram);
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View("Create",courseProgramRepo.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(CoursePrograms courseProgram)
        {
            courseProgramRepo.Update(courseProgram);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            courseProgramRepo.Delete(id);
            return RedirectToAction("List");
        }
        public IActionResult Details(int id)
        {
            return View(courseProgramRepo.GetById(id));
        }
    }
}
