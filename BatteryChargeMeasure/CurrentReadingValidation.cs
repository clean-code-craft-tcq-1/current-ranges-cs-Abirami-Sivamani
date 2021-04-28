using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryChargeMeasure
{
    public class CurrentReadingValidation
    {
        public bool IsReadingsEmpty(List<double> readings)
        {
            return (readings.Count > 0) ? false : true;
        }

        public bool IsReadingsNaN(List<double> readings)
        {
            foreach(double value in readings)
            {
                if (Double.IsNaN(value))
                    return true;
            }
            return false;
        }
    }
}
