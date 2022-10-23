using BeSpoked.Models;
using BeSpoked.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Controllers
{
    public class SalesPersonController : Controller
    {
        private readonly ISalespersonRepository _salesperson;

        public SalesPersonController(ISalespersonRepository salesperson)
        {
            _salesperson = salesperson;
        }

        public IActionResult List(string sortOrder)
        {
            var salespeople = _salesperson.GetAll();

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["ManagerSortParm"] = sortOrder == "Manager" ? "manager_desc" : "Manager";
            ViewData["StartedSortParm"] = sortOrder == "Started" ? "started_desc" : "Started";

            switch (sortOrder)
            {
                case "name_desc":
                    salespeople = salespeople.OrderByDescending(s => s.Sp_Name).ToList();
                    break;
                case "Manager":
                    salespeople = salespeople.OrderBy(s => s.Mg_Name).ToList();
                    break;
                case "manager_desc":
                    salespeople = salespeople.OrderByDescending(s => s.Mg_Name).ToList();
                    break;
                case "Started":
                    salespeople = salespeople.OrderBy(s => s.Sp_Date_Start).ToList();
                    break;
                case "started_desc":
                    salespeople = salespeople.OrderByDescending(s => s.Sp_Date_Start).ToList();
                    break;
                default:
                    salespeople = salespeople.OrderBy(s => s.Sp_Name).ToList();
                    break;
            }

            ViewData["Salespeople"] = salespeople;

            return View();
        }

        public IActionResult View(int Sp_Key)
        {
            var salesperson = _salesperson.GetViewModelById(Sp_Key);
            ViewData["Salesperson"] = salesperson;
            return View();
        }

        public IActionResult Add()
        {
            SalespersonModel model = new();

            ViewData["Managers"] = _salesperson.GetManagerSelectList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(SalespersonModel model)
        {
            if (ModelState.IsValid)
            {
                _salesperson.Create(model);

                return RedirectToAction("View", new { Sp_Key = model.Sp_Key });
            }

            ViewData["Managers"] = _salesperson.GetManagerSelectList();

            return View(model);
        }

        public IActionResult Edit(int Sp_Key)
        {
            var salesperson = _salesperson.GetById(Sp_Key);

            ViewData["Managers"] = _salesperson.GetManagerSelectList();

            return View(salesperson);
        }

        [HttpPost]
        public IActionResult Edit(SalespersonModel model)
        {
            if (ModelState.IsValid)
            {
                _salesperson.Update(model);
                return RedirectToAction("View", new { Sp_Key = model.Sp_Key });

            }

            ViewData["Managers"] = _salesperson.GetManagerSelectList();

            return View(model);
        }
    }
}
