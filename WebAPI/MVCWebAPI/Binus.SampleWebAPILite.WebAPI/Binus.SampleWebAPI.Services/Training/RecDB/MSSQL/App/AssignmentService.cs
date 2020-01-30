using Binus.SampleWebAPI.Data.Repositories.Training.RecDB.MSSQL.App;
namespace Binus.SampleWebAPI.Services.Training.RecDB.MSSQL.App
{
    public interface IAssignmentService
    {
    }

    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _AssignmentRepo;

        public AssignmentService(IAssignmentRepository _AssignmentRepo)
        {
            this._AssignmentRepo = _AssignmentRepo;
        }


    }
}
