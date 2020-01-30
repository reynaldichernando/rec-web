using Binus.SampleWebAPI.Data.Repositories.Training.RecDB.MSSQL.App;
namespace Binus.SampleWebAPI.Services.Training.RecDB.MSSQL.App
{
    public interface IScheduleService
    {
    }

    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _ScheduleRepo;

        public ScheduleService(IScheduleRepository _ScheduleRepo)
        {
            this._ScheduleRepo = _ScheduleRepo;
        }


    }
}
