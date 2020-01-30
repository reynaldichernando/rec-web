using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.SqlClient;
using Binus.WebAPI.Model.MSSQL;

namespace Binus.SampleWebAPI.Data.Infrastructures.Base.MSSQL
{
    public interface IMSSQLRepository<T> where T : class
    {
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
        void Delete(Expression<Func<T, bool>> where);

        T GetById(int Id);
        T Get(Expression<Func<T, bool>> where);
        T ExecSPToSingle(string SPName, object[] Param = null);
         Task<T> ExecSPToSingleAsync(string SPName, object[] Param = null);


        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        IEnumerable<T> ExecSPToList(string SPName, SqlParameter[] Param = null);
        Tuple<T, object> ExecSPToSingleWithOutput(string SPName, SqlParameter[] Param);
        Tuple<IEnumerable<T>, object> ExecSPToListWithOutput(string SPName, SqlParameter[] Param);
        Task<IEnumerable<T>> ExecSPToListAsync(string SPName, SqlParameter[] Param = null);
        ExecuteResult ExecMultipleSPWithTransaction(List<StoredProcedure> SP);
        Task<ExecuteResult> ExecMultipleSPWithTransactionAsync(List<StoredProcedure> SP);
    }
}
