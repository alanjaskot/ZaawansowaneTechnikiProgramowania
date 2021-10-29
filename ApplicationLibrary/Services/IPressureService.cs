using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLibrary.Services
{
    public interface IPressureService
    {
        public List<Pressure> GetAllPressures();
        public List<Pressure> GetPressuresByDate(DateTime fromDate, DateTime toDate);
        public Pressure GetPressureById(Guid id);
        public bool AddPressure(Pressure pressure);
        public bool UpdatePressure(Pressure pressure);
        public bool SoftDeletePressure(Guid id);
        public List<Guid> SoftDeletesPressures(List<Pressure> pressures);
        public bool HardDeletePressure(Guid id);
        public List<Guid> HardDeletesPressures(List<Pressure> pressures);
    }
}
