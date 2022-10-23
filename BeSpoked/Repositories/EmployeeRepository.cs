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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _config;
        public EmployeeRepository(IConfiguration config)
        {
            _config = config;
        }

        public void Create(EmployeeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                DynamicParameters p = new();
                p.Add("@Em_Name_First", model.Em_Name_First);
                p.Add("@Em_Name_Last", model.Em_Name_Last);
                p.Add("@Em_Addr_1", model.Em_Addr_1);
                p.Add("@Em_Addr_2", model.Em_Addr_2);
                p.Add("@Em_Phone", model.Em_Phone);
                p.Add("@Em_Date_Start", model.Em_Date_Start);
                p.Add("@Em_Mg_Key", model.Em_Mg_Key);
                p.Add("@Em_Key", 0, DbType.Int32,  ParameterDirection.Output);

                connection.Execute("Employee_Insert", p, commandType: CommandType.StoredProcedure);

                model.Em_Key = p.Get<int>("@Em_Key");
            }
        }

        public void Update(EmployeeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                DynamicParameters p = new();
                p.Add("@Em_Key", model.Em_Key);
                p.Add("@Em_Name_First", model.Em_Name_First);
                p.Add("@Em_Name_Last", model.Em_Name_Last);
                p.Add("@Em_Addr_1", model.Em_Addr_1);
                p.Add("@Em_Addr_2", model.Em_Addr_2);
                p.Add("@Em_Phone", model.Em_Phone);
                p.Add("@Em_Date_Start", model.Em_Date_Start);
                p.Add("@Em_Mg_Key", model.Em_Mg_Key);

                connection.Execute("Employee_Update", p, commandType: CommandType.StoredProcedure);

            }
        }

        public List<EmployeeViewModel> GetAll()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                return connection.Query<EmployeeViewModel>("Employees_GetAll", commandType: CommandType.StoredProcedure).ToList(); ;

            }
        }

        public List<ManagerModel> GetManagers()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                return connection.Query<ManagerModel>("Managers_GetAll", commandType: CommandType.StoredProcedure).ToList(); ;
            }
        }

        public EmployeeViewModel GetViewModelById(int Em_Key)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                DynamicParameters p = new();
                p.Add("@Em_Key", Em_Key);

                return connection.Query<EmployeeViewModel>("Employee_Get_VM_ById", p, commandType: CommandType.StoredProcedure).FirstOrDefault(); ;
            }
        }

        public EmployeeModel GetEmployeeById(int Em_Key)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                DynamicParameters p = new();
                p.Add("@Em_Key", Em_Key);

                return connection.Query<EmployeeModel>("Employee_GetById", p, commandType: CommandType.StoredProcedure).FirstOrDefault(); ;
            }
        }
    }
}
