using DataBase.Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class PressureRepository : IPressureRepository
    {
        private readonly IPressureDataBaseContext _context;

        public PressureRepository(IPressureDataBaseContext context)
        {
            _context = context;
        }

        public Pressure GetById(Guid id)
        {
            var result = default(Pressure);
            try
            {
                result = _context.Pressures.AsNoTracking()
                    .Where(p => p.Id == id && p.IsDeleted != true)
                    .FirstOrDefault();
            }
            catch
            {
                throw new Exception("PressureRepository.GetById");
            }
            return result;
        }

        public bool Add(Pressure pressure)
        {
            var result = false;

            if (pressure == null)
                return false;

            if (pressure.Id == Guid.Empty)
                pressure.Id = Guid.NewGuid();

            try
            {
                pressure.IsBuildIn = true;
                var context = _context.Pressures.Add(pressure);
                if(context.State == EntityState.Added)
                    result = true;
            }
            catch
            {
                throw new Exception("PressureRepository.Add");
            }
            return result;
        }

        public List<Pressure> GetAll()
        {
            var result = default(List<Pressure>);
            try
            {
                result = _context.Pressures.AsNoTracking()
                    .Where(p => p.IsDeleted != true).ToList();
            }
            catch
            {
                throw new Exception("PressureRepository.GetAll");
            }
            return result;
        }

        public List<Pressure> GetMeasurementsByDate(DateTime fromDate, DateTime toDate)
        {
            var result = default(List<Pressure>);
            try
            {
                result = _context.Pressures.AsNoTracking()
                    .Where(p => p.IsDeleted != true
                    && p.MeasurementDateTime >= fromDate
                    && p.MeasurementDateTime <= toDate)
                    .ToList();
            }
            catch
            {
                throw new Exception("PressureRepository.GetMeasurementsByDate");
            }
            return result;
        }

        public bool HardDelete(Guid id)
        {
            var result = false;
            try
            {
                var pressure = _context.Pressures
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
                if (pressure == null)
                    return false;

                _context.Pressures.Remove(pressure);
                result = true;
            }
            catch
            {
                throw new Exception("PressureRepository.HardDelete");
            }
            return result;
        }

        public List<Guid> HardDeletes(List<Pressure> pressures)
        {
            var result = new List<Guid>();
            try
            {
                foreach (var pressure in pressures)
                {
                    if (pressure.Id == Guid.Empty)
                        return null;

                    result.Add(pressure.Id);
                }

                _context.Pressures.RemoveRange(pressures);
            }
            catch
            {
                throw new Exception("PressureRepository.HardDeletes");
            }
            return result;
        }

        public bool SoftDelete(Guid id)
        {
            var result = false;
            try
            {
                var pressure = _context.Pressures
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
                if (pressure == null)
                    return false;

                pressure.IsDeleted = true;
                pressure.DeletedAt = DateTime.Now;

                _context.Pressures.Update(pressure);
                result = true;
            }
            catch
            {
                throw new Exception("PressureRepository.SoftDelete");
            }
            return result;
        }

        public List<Guid> SoftDeletes(List<Pressure> pressures)
        {
            var result = default(List<Guid>);
            var deletedPressures = default(List<Pressure>);
            try
            {
                foreach (var pressure in pressures)
                {
                    if (pressure == null)
                        return null;
                    result.Add(pressure.Id);

                    pressure.IsDeleted = true;
                    pressure.DeletedAt = DateTime.Now;

                    deletedPressures.Add(pressure);
                }

                _context.Pressures.UpdateRange(deletedPressures);
            }
            catch
            {
                throw new Exception("PressureRepository.SoftDeletes");
            }
            return result;
        }

        public bool Update(Pressure pressure)
        {
            var result = false;
            try
            {
                if (pressure == null)
                    return false;
                
                _context.ChangeTracker.DetectChanges();
                var temp = _context.Pressures.Update(pressure);
                result = true;
            }
            catch
            {
                throw new Exception("PressureRepository.Update");
            }
            return result;
        }
    }
}
