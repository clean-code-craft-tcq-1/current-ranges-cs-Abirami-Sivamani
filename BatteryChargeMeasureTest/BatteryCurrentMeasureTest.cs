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
            CurrentReadingValidation _evaluate = new CurrentReadingValidation();
            bool _readingsAvailable = _evaluate.IsReadingsEmpty(new List<double> {  });
            Assert.IsTrue(_readingsAvailable);
        }

        [TestMethod]
        public void GivenValidReadings_WhenListHasReadings_ThenFalseIsReturned()
        {
            CurrentReadingValidation _evaluate = new CurrentReadingValidation();
            bool _readingsAvailable = _evaluate.IsReadingsEmpty(new List<double> { 2, 3, 4, 7, 8 });
            Assert.IsFalse(_readingsAvailable);
        }

        [TestMethod]
        public void GivenReadingsWithNaN_WhenReadingsHasNaN_ThenTrueIsReturned()
        {
            CurrentReadingValidation _evaluate = new CurrentReadingValidation();
            bool _validReadings = _evaluate.IsReadingsNaN(new List<double> { 2, 3, Double.NaN, 6 });
            Assert.IsTrue(_validReadings);
        }

        [TestMethod]
        public void GivenValidReading_WhenListHasValidReadings_ThenFalseIsReturned()
        {
            CurrentReadingValidation _evaluate = new CurrentReadingValidation();
            bool _validReadings = _evaluate.IsReadingsNaN(new List<double> { 2, 3, 3, 4 , 6 });
            Assert.IsFalse(_validReadings);
        }
    }
}
