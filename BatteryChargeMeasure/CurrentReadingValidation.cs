using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryChargeMeasure
{
    public static class CurrentReadingValidation
    {
        public static bool IsReadingsEmpty(List<double> readings)
        {
            return (readings.Count > 0) ? false : true;
        }

        public static bool IsReadingsNaN(List<double> readings)
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
