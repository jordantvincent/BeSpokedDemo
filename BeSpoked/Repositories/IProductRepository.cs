using BeSpoked.Models;
using BeSpoked.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Repositories
{
    public interface IProductRepository
    {
        List<ProductViewModel> GetAll();
        ProductModel GetById(int Pr_Key);
        ProductViewModel GetViewModelById(int Pr_Key);
        void Create(ProductModel model);
        void Update(ProductModel model);
        List<ManufacturerModel> GetManufacturers();
        List<StyleModel> GetStyles();
    }
}
