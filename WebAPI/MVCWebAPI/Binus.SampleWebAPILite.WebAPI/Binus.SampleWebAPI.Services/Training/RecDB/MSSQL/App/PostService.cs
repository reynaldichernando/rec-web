using Binus.SampleWebAPI.Data.Repositories.Training.RecDB.MSSQL.App;
namespace Binus.SampleWebAPI.Services.Training.RecDB.MSSQL.App
{
    public interface IPostService
    {
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository _PostRepo;

        public PostService(IPostRepository _PostRepo)
        {
            this._PostRepo = _PostRepo;
        }


    }
}
