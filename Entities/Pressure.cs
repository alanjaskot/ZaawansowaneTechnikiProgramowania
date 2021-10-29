using Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Pressure : BaseCreatedLastModifiedDeletedEntity
    {
        public string SystolicPressure { get; set; }
        public string DiastolicPressure { get; set; }
        public string Pulse { get; set; }
        public DateTime MeasurementDateTime { get; set; }
    }
}
