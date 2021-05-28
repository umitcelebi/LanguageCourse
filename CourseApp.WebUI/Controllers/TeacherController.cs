using CourseApp.Data.Abstract;
using CourseApp.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.WebUI.Controllers
{
    public class TeacherController : Controller
    {
        private ITeacherRepository teacherRepository;
        public TeacherController(ITeacherRepository _teacherRepository)
        {
            teacherRepository = _teacherRepository;
        }

        public IActionResult List() => View(teacherRepository.GetAll());

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacherRepository.Add(teacher);
                return RedirectToAction("List");
            }

            return View(teacher);
        }

        [HttpGet]
        public IActionResult Edit(int id) => View(teacherRepository.GetById(id));

        [HttpPost]
        public IActionResult Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacherRepository.Update(teacher);
                return RedirectToAction("List");
            }

            return View(teacher);
        }

        public IActionResult Delete(int id)
        {
            teacherRepository.Delete(id);
            return RedirectToAction("List");
        }
    }
}
