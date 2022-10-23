using BeSpoked.Models;
using BeSpoked.ViewModels;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConfiguration _config;
        public CustomerRepository(IConfiguration config)
        {
            _config = config;
        }
        public void Create(CustomerModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                DynamicParameters p = new();
                p.Add("@Cu_Name_First", model.Cu_Name_First);
                p.Add("@Cu_Name_Last", model.Cu_Name_Last);
                p.Add("@Cu_Addr_1", model.Cu_Addr_1);
                p.Add("@Cu_Addr_2", model.Cu_Addr_2);
                p.Add("@Cu_Phone", model.Cu_Phone);
                p.Add("@Cu_Date_Start", model.Cu_Date_Start);
                p.Add("@Cu_Key", 0, DbType.Int32, ParameterDirection.Output);

                connection.Execute("Customer_Insert", p, commandType: CommandType.StoredProcedure);

                model.Cu_Key = p.Get<int>("@Cu_Key");
            }
        }

        public void Update(CustomerModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                DynamicParameters p = new();
                p.Add("@Cu_Key", model.Cu_Key);
                p.Add("@Cu_Name_First", model.Cu_Name_First);
                p.Add("@Cu_Name_Last", model.Cu_Name_Last);
                p.Add("@Cu_Addr_1", model.Cu_Addr_1);
                p.Add("@Cu_Addr_2", model.Cu_Addr_2);
                p.Add("@Cu_Phone", model.Cu_Phone);
                p.Add("@Cu_Date_Start", model.Cu_Date_Start);

                connection.Execute("Customer_Update", p, commandType: CommandType.StoredProcedure);

            }
        }

        public List<CustomerViewModel> GetAll()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                return connection.Query<CustomerViewModel>("Customers_GetAll", commandType: CommandType.StoredProcedure).ToList(); ;
            }
        }

        public CustomerModel GetById(int Cu_Key)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                DynamicParameters p = new();
                p.Add("@Cu_Key", Cu_Key);

                return connection.Query<CustomerModel>("Customer_GetById", p, commandType: CommandType.StoredProcedure).FirstOrDefault(); ;
            }
        }

        public CustomerViewModel GetViewModelById(int Cu_Key)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                DynamicParameters p = new();
                p.Add("@Cu_Key", Cu_Key);

                return connection.Query<CustomerViewModel>("Customer_Get_VM_ById", p, commandType: CommandType.StoredProcedure).FirstOrDefault(); ;
            }
        }

        public List<SelectListModel> GetSelectList()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                return connection.Query<SelectListModel>("Customer_GetSelectList", commandType: CommandType.StoredProcedure).ToList(); ;
            }
        }
    }
}
