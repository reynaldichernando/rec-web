﻿using Binus.SampleWebAPI.Data.Repositories.Training.RecDB.MSSQL.App;
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
        Task<ExecuteResult> InsertPost(PostModel post);
        Task<List<PostModel>> GetPost(int ThreadID);
        Task<ExecuteResult> UpdatePost(PostModel Post);
        Task<ExecuteResult> DeletePost(PostModel Post);
        Task<PostModel> GetPostByID(int PostID);
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository _PostRepo;

        public PostService(IPostRepository _PostRepo)
        {
            this._PostRepo = _PostRepo;
        }

        public async Task<ExecuteResult> InsertPost(PostModel Post)
        {
            var Param = new SqlParameter[]
             {
                new SqlParameter("@UserID", Post.UserID),
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
            var Param = new SqlParameter[]
            {
                new SqlParameter("@ThreadID", ThreadID)
            };

            List<PostModel> ListPost = (await _PostRepo.ExecSPToListAsync("bn_RecDB_GetPost @ThreadID", Param)).ToList();

            return ListPost;
        }

        public async Task<PostModel> GetPostByID(int PostID)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@PostID", PostID)
            };

            PostModel Post = (await _PostRepo.ExecSPToSingleAsync("bn_RecDB_GetPostByID @PostID", Param));

            return Post;
        }

        public async Task<ExecuteResult> UpdatePost(PostModel Post)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@PostID", Post.PostID),
                new SqlParameter("@Content", Post.Content)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_RecDB_UpdatePost @PostID, @Content",
                SQLParam = Param
            });

            ExecuteResult Result = (await _PostRepo.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }
        public async Task<ExecuteResult> DeletePost(PostModel Post)
        {
            var Param = new SqlParameter[]
           {
                new SqlParameter("@PostID", Post.PostID)
           };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure {
                SPName = "bn_RecDB_DeletePost @PostID",
                SQLParam = Param
            });

            ExecuteResult Result = (await _PostRepo.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }

    }
}
