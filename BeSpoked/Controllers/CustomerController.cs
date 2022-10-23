using BeSpoked.Models;
using BeSpoked.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customer;

        public CustomerController(ICustomerRepository customer)
        {
            _customer = customer;
        }


        public IActionResult List(string sortOrder)
        {
            var customers = _customer.GetAll();

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["StartSortParm"] = sortOrder == "Started" ? "started_desc" : "Started";

            switch (sortOrder)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(x => x.Cu_Name).ToList();
                    break;
                case "Started":
                    customers = customers.OrderBy(x => x.Cu_Date_Start).ToList();
                    break;
                case "started_desc":
                    customers = customers.OrderByDescending(x => x.Cu_Date_Start).ToList();
                    break;
                default:
                    customers = customers.OrderBy(x => x.Cu_Name).ToList();
                    break;
            }
            ViewData["CustomerList"] = customers;

            return View();
        }

        public IActionResult View(int Cu_Key)
        {
            var customer = _customer.GetById(Cu_Key);
            ViewData["Customer"] = customer;

            return View();
        }

        public IActionResult Add()
        {
            CustomerModel model = new();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                _customer.Create(model);
                
                return RedirectToAction("View", new { Cu_Key = model.Cu_Key });
            }

            return View(model);
        }

        public IActionResult Edit(int Cu_Key)
        {
            var customer = _customer.GetById(Cu_Key);

            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                _customer.Update(model);

                return RedirectToAction("View", new { Cu_Key = model.Cu_Key });
            }

            return View(model);
        }
    }
}
