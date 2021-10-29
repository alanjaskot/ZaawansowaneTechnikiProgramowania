using ApplicationLibrary;
using ApplicationLibrary.Services;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureMVP.Views.MainViews.Models
{
    public class MainModel
    {
        private IPressureService _service;
        public Pressure Pressure { get; set; }

        public MainModel()
        {
            _service = ManageService.IPressureService;
        }

        public async Task AddPressure(Pressure pressure)
        {
            var result = false;
            try
            {
                result = _service.AddPressure(pressure);
            }
            catch
            {
                throw new Exception("MainModel.AddPressure");
            }
            await Task.CompletedTask;
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
                throw new Exception("MainModel.GetAllPressures");
            }
            return await Task.FromResult(result);
        }
    }
}
