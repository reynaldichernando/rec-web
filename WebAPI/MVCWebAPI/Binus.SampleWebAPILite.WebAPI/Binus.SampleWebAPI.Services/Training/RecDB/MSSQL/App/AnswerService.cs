using Binus.SampleWebAPI.Data.Repositories.Training.RecDB.MSSQL.App;
using Binus.SampleWebAPI.Model.Training.RecDB.MSSQL.App;
using Binus.WebAPI.Model.MSSQL;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Services.Training.RecDB.MSSQL.App
{
    public interface IAnswerService
    {
        Task<List<AnswerModel>> GetAllAnswer(int AssignmentID);
        Task<AnswerModel> GetAnswer(int AssignmentID, int UserID);
        Task<ExecuteResult> InsertAnswer(AnswerModel Model);
        Task<ExecuteResult> DeleteAnswer(AnswerModel Model);
        Task<ExecuteResult> UpdateAnswer(AnswerModel Model);

    }

    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _AnswerRepository;

        public AnswerService(IAnswerRepository _AnswerRepository)
        {
            this._AnswerRepository = _AnswerRepository;
        }

        public async Task<List<AnswerModel>> GetAllAnswer(int AssignmentID)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@AssignmentID", AssignmentID)
            };

            List<AnswerModel> ListAnswer = (await _AnswerRepository.ExecSPToListAsync("bn_RecDB_GetAllAnswer @AssignmentID", Param)).ToList();

            return ListAnswer;
        }

        public async Task<ExecuteResult> DeleteAnswer(AnswerModel Model)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@AnswerID", Model.AnswerID)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_AnswerDB_DeleteAnswer @AnswerID",
                SQLParam = Param
            }); ; ;

            ExecuteResult Result = (await _AnswerRepository.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }

        public async Task<ExecuteResult> InsertAnswer(AnswerModel Model)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@UserID", Model.UserID),
                new SqlParameter("@AssignmentID", Model.AssignmentID),
                new SqlParameter("@AnswerFilePath", Model.AnswerFilepath)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_RecDB_InsertAnswer @UserID, @AssignmentID, @AnswerFilePath",
                SQLParam = Param
            });

            ExecuteResult Result = (await _AnswerRepository.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }

        public async Task<ExecuteResult> UpdateAnswer(AnswerModel Model)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@AnswerID", Model.AnswerID),
                new SqlParameter("@UserID", Model.UserID),
                new SqlParameter("@AssignmentID", Model.AssignmentID),
                new SqlParameter("@AnswerFilePath", Model.AnswerFilepath),
                new SqlParameter("@DateUploaded", Model.DateUploaded)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_BookDB_UpdateAnswer @AnsweID, @UserID, @AssignmentID, @AnswerFilePath, @DateUploaded",
                SQLParam = Param
            });

            ExecuteResult Result = (await _AnswerRepository.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }

        public async Task<AnswerModel> GetAnswer(int AssignmentID, int UserID)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@AssignmentID", AssignmentID),
                new SqlParameter("@UserID", UserID)
            };

            AnswerModel answer = await _AnswerRepository.ExecSPToSingleAsync("bn_RecDB_GetAnswer @AssignmentID, @UserID", Param);

            return answer;
        }
    }
}