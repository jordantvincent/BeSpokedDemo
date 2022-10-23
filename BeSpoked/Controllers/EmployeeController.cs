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


        public IActionResult List()
        {
            var employeeList = _employee.GetAll();
            ViewData["EmployeeList"] = employeeList;

            return View();
        }

        public IActionResult View(int Em_Key)
        {
            ViewData["Employee"] = _employee.GetViewModelById(Em_Key);

            return View();
        }
        public IActionResult Create()
        {
            EmployeeModel model = new();

            ViewData["Managers"] = _employee.GetManagers();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                _employee.Create(model);

                return RedirectToAction("View", new { Em_Key = model.Em_Key });
            }

            ViewData["Managers"] = _employee.GetManagers();

            return View(model);
        }

        public IActionResult Edit(int Em_Key)
        {
            EmployeeModel employee = _employee.GetEmployeeById(Em_Key);

            ViewData["Managers"] = _employee.GetManagers();

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                _employee.Update(model);

                return RedirectToAction("View", new { Em_Key = model.Em_Key });
            }

            ViewData["Managers"] = _employee.GetManagers();

            return View(model);
        }
    }
}
