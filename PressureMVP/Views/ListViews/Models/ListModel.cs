using ApplicationLibrary;
using ApplicationLibrary.Services;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureMVP.Views.ListViews.Models
{
    public class ListModel
    {
        public Pressure Pressure { get; set; }
        public IPressureService _service;

        public ListModel()
        {
            _service = ManageService.IPressureService;
        }

        public async Task<List<Pressure>> GetAllPressures()
        {
            var result = default(List<Pressure>);
            try
            {
                result = _service.GetAllPressures();
            }
            catch
            {
                throw new Exception("ListModel.GetAllPresures");
            }
            return await Task.FromResult(result);
        }

        public async Task<List<Pressure>> GetPressuresByDates(DateTime startDate, DateTime endDate)
        {
            var result = default(List<Pressure>);
            try
            {
                result = _service.GetPressuresByDate(startDate, endDate);
            }
            catch
            {
                throw new Exception("ListModel.GetAllPresures");
            }
            return await Task.FromResult(result);
        }

        public async Task<bool> UpdatePressure(Pressure pressure)
        {
            var result = false;
            try
            {
                var update = _service.UpdatePressure(pressure);
                if (update)
                    result = true;
            }
            catch
            {
                throw new Exception("ListModel.UpdatePressure");
            }
            return await Task.FromResult(result);
        }

        public Pressure GetPressureById(Guid id)
        {
            var result = default(Pressure);
            try
            {
                result = _service.GetPressureById(id);
            }
            catch
            {
                throw new Exception("ListModel.GetPressureById");
            }
            return result;
        }

        public async Task<List<Guid>> SoftDeletes(List<Pressure> list)
        {
            var result = default(List<Guid>);
            try
            {
                result = _service.SoftDeletesPressures(list);
            }
            catch
            {
                throw new Exception("ListModel.SoftDeletes");
            }
            return await Task.FromResult(result);
        }

        public async Task<List<Guid>> HardDeletesPressures(List<Pressure> list)
        {
            var result = default(List<Guid>);
            try
            {
                result = _service.HardDeletesPressures(list);
            }
            catch
            {
                throw new Exception("ListModel.HardDeletes");
            }
            return await Task.FromResult(result);
        }
    }
}
