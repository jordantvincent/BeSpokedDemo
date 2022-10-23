using BeSpoked.Models;
using BeSpoked.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Repositories
{
    public interface ISalespersonRepository
    {
        public List<SalespersonViewModel> GetAll();
        SalespersonModel GetById(int Sp_Key);
        public void Create(SalespersonModel model);
        void Terminate(SalespersonTerminateModel model);
        void Update(SalespersonModel model);
        List<SelectListModel> GetManagerSelectList();
        List<SelectListModel> GetSelectList();
        SalespersonViewModel GetViewModelById(int Em_Key);
    }
}
