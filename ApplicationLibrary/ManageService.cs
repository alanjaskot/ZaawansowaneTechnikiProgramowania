using ApplicationLibrary.Services;
using DataBase.Context;
using DataBase.Repository;
using DataBase.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLibrary
{
    public static class ManageService
    {
        public static IPressureService IPressureService { get; set; }

        public static void Init()
        {
            IPressureDataBaseContext _context = new PressureDataBaseContext();
            IPressureRepository _repo = new PressureRepository(_context);
            IUnitOfWork _unitOfWork = new UnitOfWork(_context, _repo);

            IPressureService = new PressureService(_unitOfWork);
        }
    }
}
