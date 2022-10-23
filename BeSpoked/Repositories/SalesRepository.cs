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
    public class SalesRepository : ISalesRepository
    {
        private readonly IConfiguration _config;

        public SalesRepository(IConfiguration config)
        {
            _config = config;
        }

        public void CreateSale(SalesModel model)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                DynamicParameters p = new();
                p.Add("@Sa_Pr_Key", model.Sa_Pr_Key);
                p.Add("@Sa_Cu_Key", model.Sa_Cu_Key);
                p.Add("@Sa_Sp_Key", model.Sa_Sp_Key);
                p.Add("@Sa_Date_Trans", model.Sa_Date_Trans);
                p.Add("@Sa_Qty", model.Sa_Qty);
                p.Add("@Sa_Key", 0, DbType.Int32, ParameterDirection.Output);

                connection.Execute("Sale_Insert", p, commandType: CommandType.StoredProcedure);

                model.Sa_Key = p.Get<int>("@Sa_Key");
            }

        }

        public List<SalesViewModel> GetAll()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                return connection.Query<SalesViewModel>("Sales_GetAll", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public SalesViewModel GetViewModelById(int Sa_Key)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                DynamicParameters p = new();
                p.Add("@Sa_Key", Sa_Key);

                return connection.Query<SalesViewModel>("Sale_Get_VM_ById", p, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }
        }

        public List<SalespersonSummaryViewModel> GetQuarterlyReport(int year, int quarter)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                DynamicParameters p = new();
                p.Add("@Year", year);
                p.Add("@Quarter", quarter);

                return connection.Query<SalespersonSummaryViewModel>("Sales_GetQuarterlyReport", p, commandType: CommandType.StoredProcedure).ToList();

            }
        }

        public List<int> GetSalesYears()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                return connection.Query<int>("Sales_GetYears", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}