using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.DataAccessLayer.Entities;
using Product.DataAccessLayer.Utils;

namespace Product.DataAccessLayer.Repository
{
    public interface IProductRepository : IBaseRepository<int, ProductEntity, ProductDetailEntity>
    {
        Task<List<ProductDetailEntity>> ReadAll(ProductFilterEntity filter);
    }
    public class ProductRepository : IProductRepository
    {
        private readonly IDataAccess _dataAccess;
        public ProductRepository(IDataAccess dataAccess)
        {
            this._dataAccess = dataAccess;
        }

        public Task<int> Create(ProductEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDetailEntity> Read(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDetailEntity>> ReadAll(ProductFilterEntity filter)
        {
            var sql = "dbo.DEF_Product_ReadAll";
            var sqlParams = new DynamicParameters();
            sqlParams.Add("ProductName", filter.ProductName);
            try
            {
                using (var con = _dataAccess.CreateConnection())
                {
                    var result = await con.QueryAsync<ProductDetailEntity>
                    (
                        sql: sql,
                        param: sqlParams,
                        commandType: CommandType.StoredProcedure
                    );

                    return result.AsList();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task Update(ProductEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
