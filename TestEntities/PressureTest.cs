using System;
using Entities;
using NUnit.Framework;

namespace TestEntities
{
    public class PressureTest
    {
        [Test]
        public void TestPressureEntityValues()
        {
            var createdAtValueTest = DateTime.Now;
            var idValueTest = Guid.NewGuid();
            var deletedAtValueTest = DateTime.Now;
            var lastModifiedAtValueTest = DateTime.Now;
            var measurementDateTimeValueTest = DateTime.Now;

            var pressure = new Pressure
            {
                Id = idValueTest,
                IsBuildIn = true,
                DiastolicPressure = "120",
                SystolicPressure = "80",
                Pulse = "80",
                MeasurementDateTime = measurementDateTimeValueTest,
                CreatedAt = createdAtValueTest,
                IsModified = true,
                LastModifiedAt = lastModifiedAtValueTest,
                IsDeleted = true,
                DeletedAt = deletedAtValueTest
            };

            Assert.AreEqual(idValueTest, pressure.Id);
            Assert.AreEqual(true, pressure.IsBuildIn);
            Assert.AreEqual("120", pressure.DiastolicPressure);
            Assert.AreEqual("80", pressure.SystolicPressure);
            Assert.AreEqual("80", pressure.Pulse);
            Assert.AreEqual(measurementDateTimeValueTest, pressure.MeasurementDateTime);
            Assert.AreEqual(createdAtValueTest, pressure.CreatedAt);
            Assert.AreEqual(true, pressure.IsModified);
            Assert.AreEqual(lastModifiedAtValueTest, pressure.LastModifiedAt);
            Assert.AreEqual(true, pressure.IsDeleted);
            Assert.AreEqual(deletedAtValueTest, pressure.DeletedAt);
        }
    }
}
