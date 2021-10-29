using DataBase.UnitOfWorks;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLibrary.Services
{
    public class PressureService : IPressureService
    {
        private IUnitOfWork _unitOfWork;

        public PressureService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddPressure(Pressure pressure)
        {
            var result = false;
            try
            {
                var add = _unitOfWork.GetPressureRepository.Add(pressure);
                if (add)
                {
                    var save = _unitOfWork.SaveChanges();
                    if (save > -1)
                        result = true;
                    else
                        _unitOfWork.Rollback();
                }
            }
            catch
            {
                throw new Exception("PressureService.AddPressure");
            }
            return result;
        }

        public List<Pressure> GetAllPressures()
        {
            var result = default(List<Pressure>);
            try
            {
                result = _unitOfWork.GetPressureRepository.GetAll();
            }
            catch
            {
                throw new Exception("PressureService.GetAllPressures");
            }
            return result;
        }

        public Pressure GetPressureById(Guid id)
        {
            var result = default(Pressure);
            try
            {
                result = _unitOfWork.GetPressureRepository.GetById(id);
            }
            catch
            {
                throw new Exception("PressureService.GetPressureById");
            }
            return result;
        }

        public List<Pressure> GetPressuresByDate(DateTime fromDate, DateTime toDate)
        {
            var result = default(List<Pressure>);
            try
            {
                result = _unitOfWork.GetPressureRepository.GetMeasurementsByDate(fromDate, toDate);
            }
            catch
            {
                throw new Exception("PressureService.GetPressuresByDate");
            }
            return result;
        }

        public bool HardDeletePressure(Guid id)
        {
            var result = false;
            try
            {
                var delete = _unitOfWork.GetPressureRepository.HardDelete(id);
                if (delete)
                {
                    var save = _unitOfWork.SaveChanges();
                    if (save > -1)
                        result = true;
                    else
                        _unitOfWork.Rollback();
                }
            }
            catch
            {
                throw new Exception("PressureService.HardDeletePressure");
            }
            return result;
        }

        public List<Guid> HardDeletesPressures(List<Pressure> pressures)
        {
            var result = default(List<Guid>);
            try
            {
                _unitOfWork.BeginTransaction();
                result = _unitOfWork.GetPressureRepository.HardDeletes(pressures);
                if (result != null)
                {
                    var save = _unitOfWork.SaveChanges();
                    if (save > -1)
                    {
                        _unitOfWork.CommitTransaction();
                        _unitOfWork.SaveChanges();
                    }
                    else
                    {
                        _unitOfWork.RollbackTransaction();
                        _unitOfWork.Rollback();
                    }
                }
            }
            catch
            {
                throw new Exception("PressureService.HardDeletesPressures");
            }
            return result;
        }

        public bool SoftDeletePressure(Guid id)
        {
            var result = false;
            try
            {
                var delete = _unitOfWork.GetPressureRepository.SoftDelete(id);
                if (delete)
                {
                    var save = _unitOfWork.SaveChanges();
                    if (save > -1)
                        result = true;
                    else
                        _unitOfWork.Rollback();
                }
            }
            catch
            {
                throw new Exception("PressureService.SoftDeletePressure");
            }
            return result;
        }

        public List<Guid> SoftDeletesPressures(List<Pressure> pressures)
        {
            var result = default(List<Guid>);
            try
            {
                _unitOfWork.BeginTransaction();
                result = _unitOfWork.GetPressureRepository.SoftDeletes(pressures);
                if (result != null)
                {
                    _unitOfWork.CommitTransaction();
                    _unitOfWork.SaveChanges();
                }
                else
                {
                    _unitOfWork.RollbackTransaction();
                    _unitOfWork.Rollback();
                }
            }
            catch
            {
                throw new Exception("PressureService.SoftDeletesPressures");
            }
            return result;
        }

        public bool UpdatePressure(Pressure pressure)
        {
            var result = false;
            try
            {
                var update = _unitOfWork.GetPressureRepository.Update(pressure);
                if (update)
                {
                    var save = _unitOfWork.SaveChanges();
                    if (save > -1)
                    {
                        _unitOfWork.SaveChanges();
                        result = true;
                    }
                    else
                        _unitOfWork.Rollback();
                }
            }
            catch
            {
                throw new Exception("PressureService.UpdatePressure");
            }
            return result;
        }
    }
}
