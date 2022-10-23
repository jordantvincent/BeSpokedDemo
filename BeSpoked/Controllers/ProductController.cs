using BeSpoked.Models;
using BeSpoked.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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


        public IActionResult List(string sortOrder)
        {
            var products = _product.GetAll();

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["ManufacturerSortParm"] = sortOrder == "Manufacturer" ? "manufacturer_desc" : "Manufacturer";
            ViewData["StyleSortParm"] = sortOrder == "Style" ? "style_desc" : "Style";
            ViewData["PurchaseSortParm"] = sortOrder == "Purchase" ? "purchase_desc" : "Purchase";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["QtySortParm"] = sortOrder == "Qty" ? "qty_desc" : "Qty";
            ViewData["CommissionSortParm"] = sortOrder == "Commission" ? "commission_desc" : "Commission";

            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(x => x.Pr_Name).ToList();
                    break;
                case "Manufacturer":
                    products = products.OrderBy(x => x.Pr_Manufacturer).ToList();
                    break;
                case "manufacturer_desc":
                    products = products.OrderByDescending(x => x.Pr_Manufacturer).ToList();
                    break;
                case "Style":
                    products = products.OrderBy(x => x.Pr_Style).ToList();
                    break;
                case "style_desc":
                    products = products.OrderByDescending(x => x.Pr_Style).ToList();
                    break;
                case "Purchase":
                    products = products.OrderBy(x => x.Pr_Amt_Purchase).ToList();
                    break;
                case "purchase_desc":
                    products = products.OrderByDescending(x => x.Pr_Amt_Purchase).ToList();
                    break;
                case "Price":
                    products = products.OrderBy(x => x.Pr_Amt_Sale).ToList();
                    break;
                case "price_desc":
                    products = products.OrderByDescending(x => x.Pr_Amt_Sale).ToList();
                    break;
                case "Qty":
                    products = products.OrderBy(x => x.Pr_Qty).ToList();
                    break;
                case "qty_desc":
                    products = products.OrderByDescending(x => x.Pr_Qty).ToList();
                    break;
                case "Commission":
                    products = products.OrderBy(x => x.Pr_Commission).ToList();
                    break;
                case "commission_desc":
                    products = products.OrderByDescending(x => x.Pr_Commission).ToList();
                    break;
                default:
                    products = products.OrderBy(x => x.Pr_Name).ToList();
                    break;
            }

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
                try
                {
                    _product.Create(model);

                    return RedirectToAction("View", new { Pr_Key = model.Pr_Key });
                }
                catch (SqlException e)
                {
                    if (e.Number == 2627)
                    {
                        ModelState.AddModelError("Pr_Name", "Product already exists.");
                    }
                }
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
                try
                {
                    _product.Update(model);
                    return RedirectToAction("View", new { Pr_Key = model.Pr_Key });

                }
                catch (SqlException e)
                {
                    if (e.Number == 2627)
                    {
                        ModelState.AddModelError("Pr_Name", "Product already exists.");
                    }
                }
            }

            ViewData["Manufacturers"] = _product.GetManufacturers();
            ViewData["Styles"] = _product.GetStyles();

            return View(model);
        }

        public IActionResult AddDiscount(int Pr_Key)
        {
            DiscountModel model = new();
            model.Dc_Pr_Key = Pr_Key;

            ViewData["Product"] = _product.GetViewModelById(Pr_Key);

            return View(model);
        }

        [HttpPost]
        public IActionResult AddDiscount(DiscountModel model)
        {
            if (ModelState.IsValid)
            {
                _product.AddDiscount(model);
                return RedirectToAction("View", new { Pr_Key = model.Dc_Pr_Key });
            }

            ViewData["Product"] = _product.GetViewModelById(model.Dc_Pr_Key);

            return View(model);
        }
    }
}
