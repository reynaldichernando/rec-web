using Binus.SampleWebAPI.Data.Infrastructures.Base.MSSQL;
using Binus.SampleWebAPI.Data.Infrastructures.Training.MSSQL;
using Binus.SampleWebAPI.Model.Training.RecDB.MSSQL.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Data.Repositories.Training.RecDB.MSSQL.App
{
    public interface IScheduleRepository
     : IMSSQLRepository<ScheduleModel>
    { }

    public class ScheduleRepository
        : RecDBMSSQLRepositoryBase<ScheduleModel>, IScheduleRepository
    {
        public ScheduleRepository(RecDBMSSQLIDBFactory DBFactory)
            : base(DBFactory)
        {
        }
    }
}
    