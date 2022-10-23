using BeSpoked.Models;
using BeSpoked.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Controllers
{
    public class SalesController : Controller
    {
        private readonly IProductRepository _product;
        private readonly ISalespersonRepository _salesperson;
        private readonly ICustomerRepository _customer;
        private readonly ISalesRepository _sales;

        public SalesController(IProductRepository product, ISalespersonRepository salesperson, ICustomerRepository customer, ISalesRepository sales)
        {
            _product = product;
            _salesperson = salesperson;
            _customer = customer;
            _sales = sales;
        }

        public IActionResult List(string sortOrder, DateTime? minDate, DateTime? maxDate)
        {
            var sales = _sales.GetAll();
            if (minDate.HasValue)
            {
                ViewData["MinDate"] = ((DateTime)minDate).ToString("yyyy-MM-dd");
                sales = sales.Where(sale => sale.Sa_Date_Trans >= minDate).ToList();
            }
            if (maxDate.HasValue)
            {
                ViewData["MaxDate"] = ((DateTime)maxDate).ToString("yyyy-MM-dd");
                sales = sales.Where(sale => sale.Sa_Date_Trans <= maxDate).ToList();
            }

            ViewData["DateSortParm"] = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            ViewData["CustomerSortParm"] = sortOrder == "Customer" ? "customer_desc" : "Customer";
            ViewData["ProductSortParm"] = sortOrder == "Product" ? "product_desc" : "Product";
            ViewData["QtySortParm"] = sortOrder == "Qty" ? "qty_desc" : "Qty";
            ViewData["AmountSortParm"] = sortOrder == "Amount" ? "amount_desc" : "Amount";
            ViewData["SalespersonSortParm"] = sortOrder == "Salesperson" ? "salesperson_desc" : "Salesperson";
            ViewData["CommissionSortParm"] = sortOrder == "Commission" ? "commission_desc" : "Commission";

            switch (sortOrder)
            {
                case "date_desc":
                    sales = sales.OrderByDescending(x => x.Sa_Date_Trans).ToList();
                    break;
                case "Customer":
                    sales = sales.OrderBy(x => x.Cu_Name).ToList();
                    break;
                case "customer_desc":
                    sales = sales.OrderByDescending(x => x.Cu_Name).ToList();
                    break;
                case "Product":
                    sales = sales.OrderBy(x => x.Pr_Name).ToList();
                    break;
                case "product_desc":
                    sales = sales.OrderByDescending(x => x.Pr_Name).ToList();
                    break;
                case "Qty":
                    sales = sales.OrderBy(x => x.Sa_Qty).ToList();
                    break;
                case "qty_desc":
                    sales = sales.OrderByDescending(x => x.Sa_Qty).ToList();
                    break;
                case "Amount":
                    sales = sales.OrderBy(x => x.Sa_Amt).ToList();
                    break;
                case "amount_desc":
                    sales = sales.OrderByDescending(x => x.Sa_Amt).ToList();
                    break;
                case "Salesperson":
                    sales = sales.OrderBy(x => x.Sp_Name).ToList();
                    break;
                case "salesperson_desc":
                    sales = sales.OrderByDescending(x => x.Sp_Name).ToList();
                    break;
                case "Commission":
                    sales = sales.OrderBy(x => x.Sa_Commission_Amt).ToList();
                    break;
                case "commission_desc":
                    sales = sales.OrderByDescending(x => x.Sa_Commission_Amt).ToList();
                    break;
                default:
                    sales = sales.OrderBy(x => x.Sa_Date_Trans).ToList();
                    break;
            }

            ViewData["Sales"] = sales;

            return View();
        }

        public IActionResult View(int Sa_Key)
        {
            ViewData["Sale"] = _sales.GetViewModelById(Sa_Key);

            return View();
        }
        public IActionResult Add()
        {
            SalesModel model = new();
            
            ViewData["Products"] = _product.GetSelectList();
            ViewData["Salespeople"] = _salesperson.GetSelectList();
            ViewData["Customers"] = _customer.GetSelectList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(SalesModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _sales.CreateSale(model);
                    return RedirectToAction("List");

                }
                catch (SqlException e)
                {
                    if (e.Number == 50000) // SQL error number associated with column being updated below 0
                    {
                        ModelState.AddModelError("Sa_Qty", "Inventory is too low for this order.");
                    }
                }
            }

            ViewData["Products"] = _product.GetSelectList();
            ViewData["Salespeople"] = _salesperson.GetSelectList();
            ViewData["Customers"] = _customer.GetSelectList();

            return View();
        }

        public IActionResult QuarterlyReport(int? year, int? quarter)
        {

            //defaults to current year
            if (!year.HasValue)
            {
                year = DateTime.Today.Year;
                quarter = ((DateTime.Today.Month + 2) / 3);
            }
            ////defaults to current quarter if no year is provided
            //if (!quarter.HasValue)
            //{
            //    quarter = ((DateTime.Today.Month + 2) /3);
            //}
          

            ViewData["Year"] = year;
            ViewData["Quarter"] = quarter;
            ViewData["Years"] = _sales.GetSalesYears();

            ViewData["Summary"] = _sales.GetQuarterlyReport((int)year, (int)quarter);
            return View();
        }
    }
}
