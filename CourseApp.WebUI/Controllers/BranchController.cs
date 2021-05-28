using CourseApp.Data.Abstract;
using CourseApp.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.WebUI.Controllers
{
    public class BranchController : Controller
    {
        private IBranchRepository branchRepository;
        public BranchController(IBranchRepository _branchRepository)
        {
            branchRepository = _branchRepository;
        }

        public IActionResult List() => View(branchRepository.GetAll());

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Branch branch)
        {
            if (ModelState.IsValid)
            {
                branchRepository.Add(branch);
                return RedirectToAction("List");
            }

            return View(branch);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(branchRepository.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Branch branch)
        {
            if (ModelState.IsValid)
            {
                branchRepository.Update(branch);
                return RedirectToAction("List");
            }

            return View(branch);
        }
        public IActionResult Delete(int id)
        {
            branchRepository.Delete(id);
            return RedirectToAction("List");
        }

    }
}
