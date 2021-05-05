using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryChargeMeasure
{
    public class BatteryCurrentMeasure
    {
        public List<CurrentRangeWithCount> GetCurrentRangeWithCount(List<double> readings) 
        {
            List<CurrentRangeWithCount> _result = new List<CurrentRangeWithCount>();
            if(!CurrentReadingValidation.IsReadingsEmpty(readings) && !CurrentReadingValidation.IsReadingsNaN(readings))
            {
                readings.Sort();
                _result.Add(new CurrentRangeWithCount()
                {
                    ReadingCount = readings.Count,
                    Range = (readings[0] + "-" + readings[readings.Count - 1]).ToString()
                });
            }        
            return _result;
        }
    } 

    public class CurrentRangeWithCount
    {
        public string Range { get; set; }
        public int ReadingCount { get; set; }
    }
}
