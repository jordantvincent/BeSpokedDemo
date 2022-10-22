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
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _config;
        public ProductRepository(IConfiguration config)
        {
            _config = config;
        }

        public void Create(ProductModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                DynamicParameters p = new();
                p.Add("@Pr_Name", model.Pr_Name);
                p.Add("@Pr_Manufacturer", model.Pr_Manufacturer);
                p.Add("@Pr_Style", model.Pr_Style);
                p.Add("@Pr_Amt_Purchase", model.Pr_Amt_Purchase);
                p.Add("@Pr_Amt_Sale", model.Pr_Amt_Sale);
                p.Add("@Pr_Qty", model.Pr_Qty);
                p.Add("@Pr_Commission", model.Pr_Commission);
                p.Add("@Pr_Key", 0, DbType.Int32, ParameterDirection.Output);

                connection.Execute("Product_Insert", p, commandType: CommandType.StoredProcedure);

                model.Pr_Key = p.Get<int>("@Pr_Key");
            }
        }

        public void Update(ProductModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                DynamicParameters p = new();
                p.Add("@Pr_Key", model.Pr_Key);
                p.Add("@Pr_Name", model.Pr_Name);
                p.Add("@Pr_Manufacturer", model.Pr_Manufacturer);
                p.Add("@Pr_Style", model.Pr_Style);
                p.Add("@Pr_Amt_Purchase", model.Pr_Amt_Purchase);
                p.Add("@Pr_Amt_Sale", model.Pr_Amt_Sale);
                p.Add("@Pr_Qty", model.Pr_Qty);
                p.Add("@Pr_Commission", model.Pr_Commission);

                connection.Execute("Product_Update", p, commandType: CommandType.StoredProcedure);
            }
        }

        public List<ProductViewModel> GetAll()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                return connection.Query<ProductViewModel>("Product_GetAll", commandType: CommandType.StoredProcedure).ToList(); ;
            }
        }

        public ProductModel GetById(int Pr_Key)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                DynamicParameters p = new();
                p.Add("@Pr_Key", Pr_Key);

                return connection.Query<ProductModel>("Product_GetById", p, commandType: CommandType.StoredProcedure).FirstOrDefault(); ;
            }
        }

        public ProductViewModel GetViewModelById(int Pr_Key)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                DynamicParameters p = new();
                p.Add("@Pr_Key", Pr_Key);

                return connection.Query<ProductViewModel>("Product_Get_VM_ById", p, commandType: CommandType.StoredProcedure).FirstOrDefault(); ;
            }
        }

        public List<ManufacturerModel> GetManufacturers()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                return connection.Query<ManufacturerModel>("Manufacturers_GetAll", commandType: CommandType.StoredProcedure).ToList(); ;
            }
        }

        public List<StyleModel> GetStyles()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("BeSpoked")))
            {
                return connection.Query<StyleModel>("Styles_GetAll", commandType: CommandType.StoredProcedure).ToList(); ;
            }
        }
    }
}
