using BeSpoked.Models;
using BeSpoked.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employee;

        public EmployeeController(IEmployeeRepository employee)
        {
            _employee = employee;
        }


        public IActionResult ViewAll()
        {
            var employeeList = _employee.GetAll();
            ViewData["EmployeeList"] = employeeList;

            return View();
        }
        public IActionResult Create()
        {
            EmployeeModel model = new();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                _employee.Create(model);
                return RedirectToAction("ViewAll");
            }

            return View(model);
        }
    }
}
