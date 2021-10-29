using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Context
{
    public interface IPressureDataBaseContext
    {
        public DbSet<Pressure> Pressures { get; set; }

        public int SaveChanges();
        public ChangeTracker ChangeTracker { get; }

        public void BeginTransaction();
        public void RollbackTransaction();
        public void CommitTransaction();
    }
}
