﻿using Binus.SampleWebAPI.Data.Infrastructures.Base.MSSQL;
using Binus.SampleWebAPI.Data.Infrastructures.Training.MSSQL;
using Binus.SampleWebAPI.Model.Training.RecDB.MSSQL.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Data.Repositories.Training.RecDB.MSSQL.App
{
    public interface IAnswerRepository
     : IMSSQLRepository<AnswerModel>
    { }

    public class AnswerRepository
        : RecDBMSSQLRepositoryBase<AnswerModel>, IAnswerRepository
    {
        public AnswerRepository(RecDBMSSQLIDBFactory DBFactory)
            : base(DBFactory)
        {
        }
    }
}
