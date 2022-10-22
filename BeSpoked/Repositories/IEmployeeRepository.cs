using BeSpoked.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Repositories
{
    public interface IEmployeeRepository
    {
        public List<EmployeeModel> GetAll();

        public void Create(EmployeeModel model);
    }
}
