﻿using Binus.SampleWebAPI.Data.Repositories.Training.RecDB.MSSQL.App;
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

        public async Task<ExecuteResult> DeleteAssignment(AssignmentModel Model)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@AssignmentID", Model.AssignmentID)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_AssignmentDB_DeleteAssignment @AssignmentID",
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
                new SqlParameter("@Duedate", Model.Duedate),
                new SqlParameter("@DateUploaded", Model.DateUploaded),
                new SqlParameter("@Description", Model.Description),
                new SqlParameter("@AssignmentFilePath", Model.AssignmentFilepath)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_AssignmentDB_InsertAssignment @UserID, @AssignmentID, @AssignmentFilePath, @DateUploaded",
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
                new SqlParameter("@Duedate", Model.Duedate),
                new SqlParameter("@DateUploaded", Model.DateUploaded),
                new SqlParameter("@Description", Model.Description),
                new SqlParameter("@AssignmentFilePath", Model.AssignmentFilepath)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_BookDB_UpdateAssignment @AnsweID, @UserID, @AssignmentID, @AssignmentFilePath, @DateUploaded",
                SQLParam = Param
            });

            ExecuteResult Result = (await _AssignmentRepository.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }
    }
}