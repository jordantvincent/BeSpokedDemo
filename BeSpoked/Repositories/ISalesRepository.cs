using BeSpoked.Models;
using BeSpoked.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Repositories
{
    public interface ISalesRepository
    {
        void CreateSale(SalesModel model);
        List<int> GetSalesYears();
        List<SalesViewModel> GetAll();
        SalesViewModel GetViewModelById(int Sa_Key);
        List<SalespersonSummaryViewModel> GetQuarterlyReport(int year, int quarter);
    }
}
