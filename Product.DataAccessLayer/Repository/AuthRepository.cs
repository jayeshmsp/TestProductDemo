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
    public interface IAuthRepository : IBaseRepository<int, AuthEntity, AuthDetailEntity>
    {
        Task<AuthDetailEntity> Authenticate(string userName, string password);
        Task<AuthDetailEntity> VerifyOTP(long UserId, string OTP);
        Task<int> CreateOTP(long UserId, string OTP);
    }

    public class AuthRepository : IAuthRepository
    {
        private readonly IDataAccess _dataAccess;
        public AuthRepository(IDataAccess dataAccess)
        {
            this._dataAccess = dataAccess;
        }

        public async Task<AuthDetailEntity> Authenticate(string userName, string password)
        {
            var sql = "dbo.USPA_Authentication";
            var sqlParams = new DynamicParameters();
            sqlParams.Add("userName", userName);
            sqlParams.Add("password", password);
            try
            {
                using (var con = _dataAccess.CreateConnection())
                {
                    var result = await con.QueryAsync<AuthDetailEntity>
                    (
                        sql: sql,
                        param: sqlParams,
                        commandType: CommandType.StoredProcedure
                    );

                    return result.SingleOrDefault();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> CreateOTP(long UserId, string OTP)
        {
            var sql = "dbo.USPA_OTP_Update";
            var sqlParams = new DynamicParameters();
            sqlParams.Add("UserId", UserId);
            sqlParams.Add("OTP", OTP);
            try
            {
                using (var con = _dataAccess.CreateConnection())
                {
                    await con.ExecuteAsync(
                        sql: sql,
                        param: sqlParams,
                        commandType: CommandType.StoredProcedure
                    );
                    return 1;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<AuthDetailEntity> VerifyOTP(long UserId, string OTP)
        {
            var sql = "dbo.USPA_Verify_OTP";
            var sqlParams = new DynamicParameters();
            sqlParams.Add("UserId", UserId);
            sqlParams.Add("OTP", OTP);
            try
            {
                using (var con = _dataAccess.CreateConnection())
                {
                    var result = await con.QueryAsync<AuthDetailEntity>
                    (
                        sql: sql,
                        param: sqlParams,
                        commandType: CommandType.StoredProcedure
                    );

                    return result.SingleOrDefault();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task<int> Create(AuthEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthDetailEntity> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(AuthEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
