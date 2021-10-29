using DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public IPressureRepository GetPressureRepository { get; }

        public int SaveChanges();
        public void Rollback();

        public void BeginTransaction();
        public void RollbackTransaction();
        public void CommitTransaction();
    }
}
