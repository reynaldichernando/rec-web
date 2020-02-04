using Binus.SampleWebAPI.Data.Repositories.Training.RecDB.MSSQL.App;
using Binus.SampleWebAPI.Model.Training.RecDB.MSSQL.App;
using Binus.WebAPI.Model.MSSQL;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Services.Training.RecDB.MSSQL.App
{
    public interface IThreadService
    {
        Task<List<ThreadModel>> GetAllThread();
        Task<ThreadModel> GetOneThread(int ThreadID);
        Task<ExecuteResult> InsertThread(ThreadModel Thread);
        Task<ExecuteResult> UpdateThread(ThreadModel Thread);
        Task<ExecuteResult> DeleteThread(ThreadModel Thread);
    }

    public class ThreadService : IThreadService
    {
        private readonly IThreadRepository _ThreadRepo;

        public ThreadService(IThreadRepository _ThreadRepo)
        {
            this._ThreadRepo = _ThreadRepo;
        }

        public async Task<ExecuteResult> DeleteThread(ThreadModel Thread)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@ThreadID", Thread.ThreadID)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure {
                SPName = "bn_RecDB_DeleteThread @ThreadID",
                SQLParam = Param
            });

            ExecuteResult Result = (await _ThreadRepo.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }

        public async Task<List<ThreadModel>> GetAllThread()
        {
            List<ThreadModel> ListThread = (await _ThreadRepo.ExecSPToListAsync("bn_RecDB_GetAllThread")).ToList();
            return ListThread;
        }
        public async Task<ThreadModel> GetOneThread(int ThreadID)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@ThreadID", ThreadID)
            };

            ThreadModel Thread = (await _ThreadRepo.ExecSPToSingleAsync("bn_RecDB_GetOneThread @ThreadID", Param));

            return Thread;
        }

        public async Task<ExecuteResult> InsertThread(ThreadModel Thread)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@UserID", Thread.UserID),
                new SqlParameter("@Title",Thread.Title),
                new SqlParameter("@Content", Thread.Content)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure {
                SPName = "bn_RecDB_InsertThread @UserID, @Title, @Content",
                SQLParam = Param
            });

            ExecuteResult Result = (await _ThreadRepo.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }

        public async Task<ExecuteResult> UpdateThread(ThreadModel Thread)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@ThreadID", Thread.ThreadID),
                new SqlParameter("@Title", Thread.Title),
                new SqlParameter("@Content", Thread.Content)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure {
                SPName = "bn_RecDB_UpdateThread @ThreadID, @Title, @Content",
                SQLParam = Param
            });

            ExecuteResult Result = (await _ThreadRepo.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }
    }
}
