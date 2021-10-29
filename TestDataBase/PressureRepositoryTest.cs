using DataBase.Context;
using DataBase.Repository;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace TestDataBase
{
    public class PressureRepositoryTest
    {

        private DateTime createdAtValueTest = new DateTime(2021, 01, 01, 12, 12, 12, 00);
        private DateTime measurementDateTimeValueTest = new DateTime(2021, 01, 01, 12, 12, 12, 00);
        private Guid idValueTest1 = Guid.NewGuid();
        private Guid idValueTest2 = Guid.NewGuid();

        /*public PressureRepositoryTest()
        {

        }*/

        public PressureRepositoryTest()
        {
        }

        private Mock<IPressureDataBaseContext> CreateContext()
        {
            var pressure = new List<Pressure>
            {
                new Pressure
                {
                    Id = idValueTest1,
                    IsBuildIn = true,
                    DiastolicPressure = "120",
                    SystolicPressure = "80",
                    Pulse = "80",
                    MeasurementDateTime = measurementDateTimeValueTest,
                    CreatedAt = createdAtValueTest
                },
                new Pressure
                {
                    Id = idValueTest2,
                    IsBuildIn = true,
                    DiastolicPressure = "125",
                    SystolicPressure = "90",
                    Pulse = "85",
                    MeasurementDateTime = measurementDateTimeValueTest.AddDays(1),
                    CreatedAt = (createdAtValueTest).AddDays(1),
                },
                new Pressure
                {
                    Id = Guid.NewGuid(),
                    IsBuildIn = true,
                    DiastolicPressure = "123",
                    SystolicPressure = "85",
                    Pulse = "82",
                    MeasurementDateTime = measurementDateTimeValueTest.AddDays(2),
                    CreatedAt = (createdAtValueTest).AddDays(2),
                },
                new Pressure
                {
                    Id = Guid.NewGuid(),
                    IsBuildIn = true,
                    DiastolicPressure = "121",
                    SystolicPressure = "80",
                    Pulse = "85",
                    MeasurementDateTime = measurementDateTimeValueTest.AddDays(3),
                    CreatedAt = (createdAtValueTest).AddDays(3),
                },

            }.AsQueryable();

            var mockDBSet = new Mock<DbSet<Pressure>>();
            mockDBSet.As<IQueryable<Pressure>>().Setup(m => m.Provider).Returns(pressure.Provider);
            mockDBSet.As<IQueryable<Pressure>>().Setup(m => m.Expression).Returns(pressure.Expression);
            mockDBSet.As<IQueryable<Pressure>>().Setup(m => m.ElementType).Returns(pressure.ElementType);
            mockDBSet.As<IQueryable<Pressure>>().Setup(m => m.GetEnumerator()).Returns(pressure.GetEnumerator());

            var mockContextDb = new Mock<IPressureDataBaseContext>();
            mockContextDb.Setup(x => x.Pressures).Returns(mockDBSet.Object);

            return mockContextDb;
        }

        [Fact]
        public void RunGetAll()
        {
            var mockContextDb = CreateContext();

            var repo = new PressureRepository(mockContextDb.Object);

            var results = repo.GetAll().ToList();

            Assert.NotNull(results);

            Assert.Equal(4, results.Count());

            var model = results.Where(p => p.DiastolicPressure == "120").FirstOrDefault();

            Assert.NotNull(model);

            Assert.Equal(idValueTest1, model.Id);
            Assert.True(model.IsBuildIn);
            Assert.Equal("120", model.DiastolicPressure);
            Assert.Equal("80", model.SystolicPressure);
            Assert.Equal("80", model.Pulse);
            Assert.Equal(measurementDateTimeValueTest, model.MeasurementDateTime);
            Assert.Equal(createdAtValueTest, model.CreatedAt);
        }

        [Fact]
        public void RunGetByDateTimeRange()
        {
            var mockContextDb = CreateContext();

            var repo = new PressureRepository(mockContextDb.Object);

            var createdByValueFromTest = (createdAtValueTest).AddDays(1);
            var createdByValueToTest = (createdAtValueTest).AddDays(2).AddHours(23).AddMinutes(59).AddSeconds(59);

            var results = repo.GetMeasurementsByDate(createdByValueFromTest, createdByValueToTest).ToList();

            Assert.NotNull(results);

            Assert.Equal(2, results.Count);

            results = repo.GetMeasurementsByDate(createdByValueFromTest, createdByValueToTest).ToList();

            var model = results.FirstOrDefault();

            Assert.NotNull(model);

            Assert.Equal(idValueTest2, model.Id);
            Assert.True(model.IsBuildIn);
            Assert.Equal("125", model.DiastolicPressure);
            Assert.Equal("90", model.SystolicPressure);
            Assert.Equal("85", model.Pulse);
            Assert.Equal(measurementDateTimeValueTest.AddDays(1), model.MeasurementDateTime);
            Assert.Equal(createdAtValueTest.AddDays(1), model.CreatedAt);
        }
    }

}

