using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.SqlClient;
using Binus.WebAPI.Model.MSSQL;
using Binus.WebAPI.Model.Oracle;

namespace Binus.SampleWebAPI.Data.Infrastructures.Base.Oracle
{
    public interface IOracleRepository<T> where T : class
    {
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
        void Delete(Expression<Func<T, bool>> where);

        T GetById(int Id);
        T Get(Expression<Func<T, bool>> where);
       
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        T ExecSQLToSingle(string SQL, object[] Param = null);
        Task<T> ExecSQLToSingleAsync(string SQL, object[] Param = null);
        IEnumerable<T> ExecSQLToList(string SQL, SqlParameter[] Param = null);
        Task<IEnumerable<T>> ExecSQLToListAsync(string SQL, SqlParameter[] Param = null);
        ExecuteResult ExecMultipleSQLWithTransaction(List<BulkSQL> BulkSQL);
        Task<ExecuteResult> ExecMultipleSQLWithTransactionAsync(List<BulkSQL> BulkSQL);
    }
}
