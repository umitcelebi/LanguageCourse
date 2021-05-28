using CourseApp.Data.Abstract;
using CourseApp.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.WebUI.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository courseRepository;
        public CourseController(ICourseRepository _courseRepository)
        {
            courseRepository = _courseRepository;
        }

        public IActionResult List() => View(courseRepository.GetAll());

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                courseRepository.Add(course);
                return RedirectToAction("List");
            }

            return View(course);
        }

        [HttpGet]
        public IActionResult Edit(int id) => View(courseRepository.GetById(id));

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                courseRepository.Update(course);
                return RedirectToAction("List");
            }

            return View(course);
        }

        public IActionResult Delete(int id)
        {
            courseRepository.Delete(id);
            return RedirectToAction("List");
        }
    }
}
