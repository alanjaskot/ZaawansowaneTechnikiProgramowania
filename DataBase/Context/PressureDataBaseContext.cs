using Base;
using DataBase.EntityConfig.Pressure;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Context
{
    public class PressureDataBaseContext : DbContext, IPressureDataBaseContext
    {
        private IDbContextTransaction _transaction;
        public DbSet<Pressure> Pressures { get; set; }

        public PressureDataBaseContext()
        {
        }

        public PressureDataBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string _db = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pressure.db");
            builder.UseSqlite($"Data Source = {_db}");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PressureEntityConfiguration());
        }

        #region Transakcje

        public void BeginTransaction()
        {
            try
            {
                if (_transaction == null)
                    _transaction = Database.BeginTransaction();
            }
            catch
            {
                throw new Exception("Błąd przy inicjalizacji transakcji");
            }
        }

        public void CommitTransaction()
        {
            try
            {
                if (_transaction != null)
                {
                    _transaction.Commit();
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
            catch
            {
                throw new Exception("Błąd przy zatwierdzaniu tranzakcji");
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
            catch
            {
                throw new Exception("Błąd przy cofaniu tranzakcji");
            }
        }
        #endregion

        #region Zapis

        private Tuple<bool, Exception> SaveChangesTest()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;

            try
            {
                base.SaveChanges();
            }
            catch (Exception err)
            {
                return new Tuple<bool, Exception>(false, err);
                throw new Exception("Błąd podczas sprawdzaniu zapisu");
            }
            finally
            {
                ChangeTracker.AutoDetectChangesEnabled = true;
            }

            return new Tuple<bool, Exception>(true, null); ;
        }

        public override int SaveChanges()
        {
            try
            {
                AddTimeStamp();

                var saveChangesTestResult = SaveChangesTest();

                if (saveChangesTestResult.Item1)
                {
                    return base.SaveChanges();
                }
                else
                {
                    ChangeTracker
                        .Entries()
                        .Where(p => p.State == EntityState.Added || p.State == EntityState.Modified || p.State == EntityState.Deleted)
                        .ToList()
                        .ForEach(x => x.State = Microsoft.EntityFrameworkCore.EntityState.Detached);

                    throw new Exception(saveChangesTestResult.Item2.Message, saveChangesTestResult.Item2);
                }
            }
            catch
            {
                throw new Exception("Błąd zapisu");
            }
        }

        public override ChangeTracker ChangeTracker
        {
            get
            {
                return base.ChangeTracker;
            }
        }

        private void AddTimeStamp()
        {
            var createdEntities = new List<ICreated>();
            var lastModifiedEntities = new List<ILastModified>();
            var deletedEntities = new List<IDeleted>();

            foreach (var entry in ChangeTracker.Entries())
            {
                var isAdded = entry.State == EntityState.Added;
                var isModified = entry.State == EntityState.Modified;
                var isDeleted = entry.State == EntityState.Deleted;

                if (isAdded && entry.Entity is ICreated addedEntity)
                {
                    createdEntities.Add(addedEntity);
                }

                if ((isModified || isAdded) && entry.Entity is ILastModified modifiedEntity)
                {
                    lastModifiedEntities.Add(modifiedEntity);
                }

                foreach (var item in createdEntities)
                {
                    if (item.CreatedAt == default(DateTime))
                        item.CreatedAt = DateTime.Now;
                }
                foreach (var item in lastModifiedEntities)
                {
                    item.LastModifiedAt = DateTime.Now;
                }
                foreach (var item in deletedEntities)
                {
                    if ((isDeleted) && entry.Entity is IDeleted deletedEntity)
                    {
                        if ((entry.Entity as IEntity).IsBuildIn)
                        {
                            entry.State = EntityState.Unchanged;
                        }
                        else if ((bool)deletedEntity.IsDeleted)
                        {
                            deletedEntities.Add(deletedEntity);
                            entry.State = EntityState.Unchanged;
                        }
                    }
                }

            }
        }
        #endregion

    }
}
