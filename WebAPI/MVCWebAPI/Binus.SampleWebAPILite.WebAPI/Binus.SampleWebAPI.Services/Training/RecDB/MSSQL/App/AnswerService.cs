using Binus.SampleWebAPI.Data.Repositories.Training.RecDB.MSSQL.App;
namespace Binus.SampleWebAPI.Services.Training.RecDB.MSSQL.App
{
    public interface IAnswerService
    {
    }

    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _AnswerRepo;

        public AnswerService(IAnswerRepository _AnswerRepo)
        {
            this._AnswerRepo = _AnswerRepo;
        }


    }
}
