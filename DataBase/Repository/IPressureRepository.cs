using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public interface IPressureRepository
    {
        public List<Pressure> GetAll();
        public List<Pressure> GetMeasurementsByDate(DateTime fromDate, DateTime toDate);
        public Pressure GetById(Guid id);
        public bool Add(Pressure pressure);
        public bool Update(Pressure pressure);
        public bool SoftDelete(Guid id);
        public List<Guid> SoftDeletes(List<Pressure> pressures);
        public bool HardDelete(Guid id);
        public List<Guid> HardDeletes(List<Pressure> pressures);
    }
}
