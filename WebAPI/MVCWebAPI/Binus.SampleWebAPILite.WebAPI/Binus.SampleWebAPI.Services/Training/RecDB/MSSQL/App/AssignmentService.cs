using Binus.SampleWebAPI.Data.Repositories.Training.RecDB.MSSQL.App;
using Binus.SampleWebAPI.Model.Training.RecDB.MSSQL.App;
using Binus.WebAPI.Model.MSSQL;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Services.Training.RecDB.MSSQL.App
{
    public interface IAssignmentService
    {
        Task<List<AssignmentModel>> GetAllAssignment();
        Task<AssignmentModel> GetAssignment(int AssignmentID);
        Task<ExecuteResult> InsertAssignment(AssignmentModel Model);
        Task<ExecuteResult> DeleteAssignment(AssignmentModel Model);
        Task<ExecuteResult> UpdateAssignment(AssignmentModel Model);

    }

    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _AssignmentRepository;

        public AssignmentService(IAssignmentRepository _AssignmentRepository)
        {
            this._AssignmentRepository = _AssignmentRepository;
        }

        public async Task<List<AssignmentModel>> GetAllAssignment()
        {
            List<AssignmentModel> ListAssignment = (await _AssignmentRepository.ExecSPToListAsync("bn_RecDB_GetAllAssignment")).ToList();

            return ListAssignment;
        }

        public async Task<AssignmentModel> GetAssignment(int AssignmentID)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@AssignmentID", AssignmentID)
            };

            AssignmentModel assigment = await _AssignmentRepository.ExecSPToSingleAsync("bn_RecDB_GetAssignment @AssignmentID", Param);

            return assigment;
        }

        public async Task<ExecuteResult> DeleteAssignment(AssignmentModel Model)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@AssignmentID", Model.AssignmentID)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_RecDB_DeleteAssignment @AssignmentID",
                SQLParam = Param
            }); ; ;

            ExecuteResult Result = (await _AssignmentRepository.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }

        public async Task<ExecuteResult> InsertAssignment(AssignmentModel Model)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@Title", Model.Title),
                new SqlParameter("@DateDue", Model.DateDue),
                new SqlParameter("@Description", Model.Description),
                new SqlParameter("@AssignmentFilePath", Model.AssignmentFilepath)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_RecDB_InsertAssignment @Title, @Description, @AssignmentFilePath, @DateDue",
                SQLParam = Param
            });

            ExecuteResult Result = (await _AssignmentRepository.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }

        public async Task<ExecuteResult> UpdateAssignment(AssignmentModel Model)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@AssignmentID", Model.AssignmentID),
                new SqlParameter("@Title", Model.Title),
                new SqlParameter("@DateDue", Model.DateDue),
                new SqlParameter("@Description", Model.Description),
                new SqlParameter("@AssignmentFilePath", Model.AssignmentFilepath)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_RecDB_UpdateAssignment @AssignmentID, @Title, @Description, @AssignmentFilePath, @DateDue",
                SQLParam = Param
            });

            ExecuteResult Result = (await _AssignmentRepository.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }
    }
}