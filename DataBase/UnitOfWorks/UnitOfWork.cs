using DataBase.Context;
using DataBase.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IPressureDataBaseContext _context;
        private IPressureRepository _pressureRepo;
        public UnitOfWork(IPressureDataBaseContext context,
            IPressureRepository pressureRepo)
        {
            _context = context;
            _pressureRepo = pressureRepo;
        }

        public IPressureRepository GetPressureRepository
        {
            get
            {
                if (_pressureRepo == null)
                    _pressureRepo = new PressureRepository(_context);

                return _pressureRepo;
            }
        }

        public void BeginTransaction()
        {
            _context.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _context.RollbackTransaction();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());

            var changedEntries = _context.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
    }
}
