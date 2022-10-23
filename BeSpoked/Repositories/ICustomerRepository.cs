using BeSpoked.Models;
using BeSpoked.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Repositories
{
    public interface ICustomerRepository
    {
        void Create(CustomerModel model);
        void Update(CustomerModel model);
        List<SelectListModel> GetSelectList();
        CustomerModel GetById(int Cu_Key);
        CustomerViewModel GetViewModelById(int Cu_Key);
        List<CustomerViewModel> GetAll();
    }
}
