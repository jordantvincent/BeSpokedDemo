using BeSpoked.Models;
using BeSpoked.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _product;

        public ProductController(IProductRepository product)
        {
            _product = product;
        }


        public IActionResult List()
        {
            var products = _product.GetAll();
            ViewData["ProductList"] = products;

            return View();
        }

        public IActionResult View(int Pr_Key)
        {
            var product = _product.GetViewModelById(Pr_Key);
            ViewData["Product"] = product;

            return View();
        }

        public IActionResult Add()
        {
            ProductModel model = new();

            ViewData["Manufacturers"] = _product.GetManufacturers();
            ViewData["Styles"] = _product.GetStyles();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                _product.Create(model);
                
                return RedirectToAction("View", new { Pr_Key = model.Pr_Key });
            }

            ViewData["Manufacturers"] = _product.GetManufacturers();
            ViewData["Styles"] = _product.GetStyles();

            return View(model);
        }

        public IActionResult Edit(int Pr_Key)
        {
            var product = _product.GetById(Pr_Key);

            ViewData["Manufacturers"] = _product.GetManufacturers();
            ViewData["Styles"] = _product.GetStyles();

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                _product.Update(model);

                return RedirectToAction("View", new { Pr_Key = model.Pr_Key });
            }

            ViewData["Manufacturers"] = _product.GetManufacturers();
            ViewData["Styles"] = _product.GetStyles();

            return View(model);
        }
    }
}
