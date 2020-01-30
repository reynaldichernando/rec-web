using Binus.SampleWebAPI.Data.Repositories.Training.RecDB.MSSQL.App;
namespace Binus.SampleWebAPI.Services.Training.RecDB.MSSQL.App
{
    public interface IThreadService
    {
    }

    public class ThreadService : IThreadService
    {
        private readonly IThreadRepository _ThreadRepo;

        public ThreadService(IThreadRepository _ThreadRepo)
        {
            this._ThreadRepo = _ThreadRepo;
        }

      
    }
}
