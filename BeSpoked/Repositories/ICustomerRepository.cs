using BeSpoked.Models;
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
        CustomerModel GetById(int Cu_Key);
        List<CustomerModel> GetAll();
    }
}
