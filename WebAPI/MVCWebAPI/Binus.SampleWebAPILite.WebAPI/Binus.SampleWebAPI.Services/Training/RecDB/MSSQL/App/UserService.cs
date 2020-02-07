using Binus.SampleWebAPI.Data.Repositories.Training.RecDB.MSSQL.App;
using Binus.SampleWebAPI.Model.Training.RecDB.MSSQL.Helper;
using Binus.SampleWebAPI.Model.Training.RecDB.MSSQL.User;
using Binus.WebAPI.Model.MSSQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Services.Training.RecDB.MSSQL.App
{
    public interface IUserService
    {
        Task<UserModel> GetUserLogin(UserModel Data);
        Task<ExecuteResult> ChangePassword(UserModel User);
        Task<ExecuteResult> RegisterUser(UserModel User);
        Task<List<UserModel>> GetUnapprovedUser();
        Task<ExecuteResult> VerifyUser(UserModel user);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepo;

        public UserService(IUserRepository _UserRepo)
        {
            this._UserRepo = _UserRepo;
        }

        public async Task<List<UserModel>> GetUnapprovedUser()
        {
            List<UserModel> ListUser = (await _UserRepo.ExecSPToListAsync("bn_RecDB_GetUnapprovedUser")).ToList();

            return ListUser;
        }

        public async Task<UserModel> GetUserLogin(UserModel User)
        {
            SHA sha = new SHA();
            UserModel UserData = await 
                _UserRepo.ExecSPToSingleAsync("bn_RecDB_GetUserLogin @Email, @Password", 
                new SqlParameter[]
                {
                    new SqlParameter("@Email", User.Email),
                    new SqlParameter("@Password",sha.GenerateSHA512String(User.Email+User.Password+User.Salt)),
                });

            return UserData;
        }

        public async Task<ExecuteResult> RegisterUser(UserModel User)
        {
            SHA sha = new SHA();
            var Param = new SqlParameter[]
            {
                new SqlParameter("@Email", User.Email),
                new SqlParameter("@Password", sha.GenerateSHA512String(User.Email+User.Password+User.Salt)),
                new SqlParameter("@Name", User.Name)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_RecDB_RegisterUser @Name, @Email, @Password",
                SQLParam = Param
            });

            ExecuteResult Result = (await _UserRepo.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }
        public async Task<ExecuteResult> ChangePassword(UserModel User)
        {
            SHA sha = new SHA();
            var Param = new SqlParameter[]
            {
                new SqlParameter("@Email", User.Email),
                new SqlParameter("@Password",sha.GenerateSHA512String(User.Email+User.Password+User.Salt))
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure {
                SPName = "bn_RecDB_UpdatePassword @Email, @Password",
                SQLParam = Param
            });

            ExecuteResult Result = (await _UserRepo.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }

        public async Task<ExecuteResult> VerifyUser(UserModel User)
        {
            var Param = new SqlParameter[]
        {
                new SqlParameter("@Email", User.Email)
        };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure {
                SPName = "bn_RecDB_VerifyUser @Email",
                SQLParam = Param
            });

            ExecuteResult Result = (await _UserRepo.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }
    }
}
