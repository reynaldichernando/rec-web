using Binus.SampleWebAPI.Data.Repositories.Training.RecDB.MSSQL.App;
using Binus.SampleWebAPI.Model.Training.RecDB.MSSQL.App;
using Binus.WebAPI.Model.MSSQL;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Services.Training.RecDB.MSSQL.App
{
    public interface IPostService
    {
        Task<ExecuteResult> InsertPost(PostModel post, int UserID);
        Task<List<PostModel>> GetPost(int ThreadID);
        Task<ExecuteResult> UpdatePost(PostModel Post);
        Task<ExecuteResult> DeletePost(PostModel Post);
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository _PostRepo;

        public PostService(IPostRepository _PostRepo)
        {
            this._PostRepo = _PostRepo;
        }

        public async Task<ExecuteResult> InsertPost(PostModel Post, int UserID)
        {
            var Param = new SqlParameter[]
             {
                new SqlParameter("@UserID", UserID),
                new SqlParameter("@ThreadID", Post.ThreadID),
                new SqlParameter("@Content", Post.Content)
             };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_RecDB_InsertPost @UserID, @ThreadID, @Content",
                SQLParam = Param
            });

            ExecuteResult Result = (await _PostRepo.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }



        public async Task<List<PostModel>> GetPost(int ThreadID)
        {

            List<PostModel> ListPost = (await _PostRepo.ExecSPToListAsync("bn_RecDB_GetPost",
                new SqlParameter[]
                {
                    new SqlParameter("@ThreadID", ThreadID),
                }
                )).ToList();
            return ListPost;
        }

        public async Task<ExecuteResult> UpdatePost(PostModel Post)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@ThreadID", Post.ThreadID),
                new SqlParameter("@PostID", Post.PostID),
                new SqlParameter("@Content", Post.Content)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_RecDB_UpdatePost @ThreadID, @PostID, @Content",
                SQLParam = Param
            });

            ExecuteResult Result = (await _PostRepo.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }
        public async Task<ExecuteResult> DeletePost(PostModel Post)
        {
            var Param = new SqlParameter[]
           {
                new SqlParameter("@ThreadID", Post.ThreadID),
                new SqlParameter("@PostID", Post.PostID)
           };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure {
                SPName = "bn_RecDB_DeletePost @ThreadID, @PostID",
                SQLParam = Param
            });

            ExecuteResult Result = (await _PostRepo.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }

    }
}
