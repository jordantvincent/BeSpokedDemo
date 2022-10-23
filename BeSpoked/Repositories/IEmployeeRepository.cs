using BeSpoked.Models;
using BeSpoked.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Repositories
{
    public interface IEmployeeRepository
    {
        public List<EmployeeViewModel> GetAll();
        List<ManagerModel> GetManagers();
        public void Create(EmployeeModel model); 
        void Update(EmployeeModel model);
        EmployeeViewModel GetViewModelById(int Em_Key);
        EmployeeModel GetEmployeeById(int Em_Key);
    }
}
