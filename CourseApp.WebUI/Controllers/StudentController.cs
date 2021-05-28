using CourseApp.Data.Abstract;
using CourseApp.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.WebUI.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository studentRepository;
        public StudentController(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }

        public IActionResult List() => View(studentRepository.GetAll());

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.Add(student);
                return RedirectToAction("List");
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(int id) => View(studentRepository.GetById(id));

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.Update(student);
                return RedirectToAction("List");
            }

            return View(student);
        }

        public IActionResult Delete(int id)
        {
            studentRepository.Delete(id);
            return RedirectToAction("List");
        }
    }
}
