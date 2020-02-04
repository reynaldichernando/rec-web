using Binus.SampleWebAPI.Data.Repositories.Training.RecDB.MSSQL.App;
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
        Task<ExecuteResult> RegisterUser(UserModel User);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepo;

        public UserService(IUserRepository _UserRepo)
        {
            this._UserRepo = _UserRepo;
        }

        public async Task<UserModel> GetUserLogin(UserModel Model)
        {
            UserModel UserData = await 
                _UserRepo.ExecSPToSingleAsync("bn_RecDB_GetUserLogin @Email, @Password", 
                new SqlParameter[]
                {
                    new SqlParameter("@Email", Model.Email),
                    new SqlParameter("@Password", Model.Password),
                });

            return UserData;
        }

        public async Task<ExecuteResult> RegisterUser(UserModel User)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@Email", User.Email),
                new SqlParameter("@Password", User.Password),
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
    }
}
