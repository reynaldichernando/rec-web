using Binus.SampleWebAPI.Data.Repositories.Training.RecDB.MSSQL.App;
using Binus.SampleWebAPI.Model.Training.RecDB.MSSQL.App;
using Binus.WebAPI.Model.MSSQL;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Services.Training.RecDB.MSSQL.App
{
    public interface IScheduleService
    {
        Task<List<ScheduleModel>> GetAllSchedule();
        Task<ExecuteResult> InsertSchedule(ScheduleModel Model);
        Task<ExecuteResult> DeleteSchedule(ScheduleModel Model);
        Task<ExecuteResult> UpdateSchedule(ScheduleModel Model);

    }

    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _ScheduleRepository;

        public ScheduleService(IScheduleRepository _ScheduleRepository)
        {
            this._ScheduleRepository = _ScheduleRepository;
        }

        public async Task<List<ScheduleModel>> GetAllSchedule()
        {
            List<ScheduleModel> ListSchedule = (await _ScheduleRepository.ExecSPToListAsync("bn_RecDB_GetAllSchedule")).ToList();

            return ListSchedule;
        }

        public async Task<ExecuteResult> DeleteSchedule(ScheduleModel Model)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@ScheduleID", Model.ScheduleID)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_ScheduleDB_DeleteSchedule @ScheduleID",
                SQLParam = Param
            }); ; ;

            ExecuteResult Result = (await _ScheduleRepository.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }

        public async Task<ExecuteResult> InsertSchedule(ScheduleModel Model)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@StartTime", Model.StartTime),
                new SqlParameter("@EndTime", Model.EndTime),
                new SqlParameter("@Place", Model.Place),
                new SqlParameter("@Topic", Model.Topic),
                new SqlParameter("@Description", Model.Description)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_ScheduleDB_InsertSchedule @StartTime, @EndTime, @Place, @Topic, @Description",
                SQLParam = Param
            });

            ExecuteResult Result = (await _ScheduleRepository.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }

        public async Task<ExecuteResult> UpdateSchedule(ScheduleModel Model)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@ScheduleID", Model.ScheduleID),
                new SqlParameter("@StartTime", Model.StartTime),
                new SqlParameter("@EndTime", Model.EndTime),
                new SqlParameter("@Place", Model.Place),
                new SqlParameter("@Topic", Model.Topic),
                new SqlParameter("@Description", Model.Description)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_BookDB_UpdateSchedule @ScheduleID, @StartTime, @EndTime, @Place, @Topic, @Description",
                SQLParam = Param
            });

            ExecuteResult Result = (await _ScheduleRepository.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }
    }
}
