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
    public class SalespersonRepository : ISalespersonRepository
    {
        private readonly IConfiguration _config;
        public SalespersonRepository(IConfiguration config)
        {
            _config = config;
        }

        public void Create(SalespersonModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                DynamicParameters p = new();
                p.Add("@Sp_Name_First", model.Sp_Name_First);
                p.Add("@Sp_Name_Last", model.Sp_Name_Last);
                p.Add("@Sp_Addr_1", model.Sp_Addr_1);
                p.Add("@Sp_Addr_2", model.Sp_Addr_2);
                p.Add("@Sp_Phone", model.Sp_Phone);
                p.Add("@Sp_Date_Start", model.Sp_Date_Start);
                p.Add("@Sp_Mg_Key", model.Sp_Mg_Key);
                p.Add("@Sp_Key", 0, DbType.Int32,  ParameterDirection.Output);

                connection.Execute("SalesPerson_Insert", p, commandType: CommandType.StoredProcedure);

                model.Sp_Key = p.Get<int>("@Sp_Key");
            }
        }

        public void Update(SalespersonModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                DynamicParameters p = new();
                p.Add("@Sp_Key", model.Sp_Key);
                p.Add("@Sp_Name_First", model.Sp_Name_First);
                p.Add("@Sp_Name_Last", model.Sp_Name_Last);
                p.Add("@Sp_Addr_1", model.Sp_Addr_1);
                p.Add("@Sp_Addr_2", model.Sp_Addr_2);
                p.Add("@Sp_Phone", model.Sp_Phone);
                p.Add("@Sp_Date_Start", model.Sp_Date_Start);
                p.Add("@Sp_Mg_Key", model.Sp_Mg_Key);

                connection.Execute("Salesperson_Update", p, commandType: CommandType.StoredProcedure);

            }
        }

        public List<SalespersonViewModel> GetAll()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                return connection.Query<SalespersonViewModel>("Salesperson_GetAll", commandType: CommandType.StoredProcedure).ToList(); ;

            }
        }

        public List<SelectListModel> GetManagerSelectList()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                return connection.Query<SelectListModel>("Managers_GetSelectList", commandType: CommandType.StoredProcedure).ToList(); ;
            }
        }

        public SalespersonViewModel GetViewModelById(int Sp_Key)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                DynamicParameters p = new();
                p.Add("@Sp_Key", Sp_Key);

                return connection.Query<SalespersonViewModel>("Salesperson_Get_VM_ById", p, commandType: CommandType.StoredProcedure).FirstOrDefault(); ;
            }
        }

        public SalespersonModel GetById(int Sp_Key)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                DynamicParameters p = new();
                p.Add("@Sp_Key", Sp_Key);

                return connection.Query<SalespersonModel>("Salesperson_GetById", p, commandType: CommandType.StoredProcedure).FirstOrDefault(); ;
            }
        }

        public List<SelectListModel> GetSelectList()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                return connection.Query<SelectListModel>("Salesperson_GetSelectList", commandType: CommandType.StoredProcedure).ToList(); ;
            }
        }
    }
}
