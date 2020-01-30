using Binus.SampleWebAPI.Data.DBContext.Training.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Binus.SampleWebAPI.Data.Infrastructures.Training.MSSQL
{
    public interface RecDBMSSQLIDBFactory : IDisposable
    {
        RecDBMSSQLDBContext Init();
    }
}
