using System.Data.Entity;

namespace Binus.SampleWebAPI.Data.DBContext.Training.MSSQL
{
    //[DbConfigurationType(typeof(EntityFrameworkDb2000Configuration))]
    public class RecDBMSSQLDBContext : DbContext
    {
        public RecDBMSSQLDBContext() : base("RecDBMSSQLDBContext") { }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
