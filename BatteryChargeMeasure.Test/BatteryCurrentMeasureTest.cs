using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BatteryChargeMeasure;
using System.Collections.Generic;

namespace BatteryChargeMeasure.Test
{
    [TestClass]
    public class BatteryCurrentMeasureTest
    {
        [TestMethod]
        public void GivenEmptyListReadings_WhenNoReadings_ThenTrueIsReturned()
        {
            bool _readingsAvailable = CurrentReadingValidation.IsReadingsEmpty(new List<double> {  });
            Assert.IsTrue(_readingsAvailable);
        }

        [TestMethod]
        public void GivenValidReadings_WhenListHasReadings_ThenFalseIsReturned()
        {
            bool _readingsAvailable = CurrentReadingValidation.IsReadingsEmpty(new List<double> { 2, 3, 4, 7, 8 });
            Assert.IsFalse(_readingsAvailable);
        }

        [TestMethod]
        public void GivenReadingsWithNaN_WhenReadingsHasNaN_ThenTrueIsReturned()
        {
            bool _validReadings = CurrentReadingValidation.IsReadingsNaN(new List<double> { 2, 3, Double.NaN, 6 });
            Assert.IsTrue(_validReadings);
        }

        [TestMethod]
        public void GivenValidReading_WhenListHasValidReadings_ThenFalseIsReturned()
        {
            bool _validReadings = CurrentReadingValidation.IsReadingsNaN(new List<double> { 2, 3, 3, 4 , 6 });
            Assert.IsFalse(_validReadings);
        }

        [TestMethod]
        public void GivenSingleRangeReading_ReturnCurrentRangeWithCount()
        {
            BatteryCurrentMeasure _measure = new BatteryCurrentMeasure();
            List<double> _currentReadings = new List<double>() { 3, 3, 5, 4 };
            List<CurrentRangeWithCount> _expectedResult = new List<CurrentRangeWithCount>();
            _expectedResult.Add(new CurrentRangeWithCount() { Range = "3-5", ReadingCount = 4 });
            List<CurrentRangeWithCount> _actualResult = _measure.GetCurrentRangeWithCount(_currentReadings);
            Assert.AreEqual(_expectedResult[0].ReadingCount, _actualResult[0].ReadingCount);
            Assert.AreEqual(_expectedResult[0].Range, _actualResult[0].Range);
        }

        [TestMethod]
        public void GivenMultipleRangeReading_ReturnCurrentRangeWithCount()
        {
            BatteryCurrentMeasure _measure = new BatteryCurrentMeasure();
            List<double> _currentReadings = new List<double>() { 3, 3, 5, 4, 10, 11, 12 };
            List<CurrentRangeWithCount> _expectedResult = new List<CurrentRangeWithCount>();
            _expectedResult.Add(new CurrentRangeWithCount() { Range = "3-5", ReadingCount = 4 });
            _expectedResult.Add(new CurrentRangeWithCount() { Range = "10-12", ReadingCount = 3 });
            List<CurrentRangeWithCount> _actualResult = _measure.GetCurrentRangeWithCount(_currentReadings);
            Assert.AreEqual(_expectedResult.Count, _actualResult.Count);
        }
    }
}
