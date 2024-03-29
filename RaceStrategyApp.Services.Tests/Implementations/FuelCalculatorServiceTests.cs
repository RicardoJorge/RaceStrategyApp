﻿using RaceStrategyApp.Services.Implementations;
using RaceStrategyApp.Services.Models;

namespace RaceStrategyApp.Services.Tests.Implementations
{
    [TestClass]
    public class FuelCalculatorServiceTests
    {
        [TestMethod]
        public void CalculateFuel_SpaSampleFormationLapOneHour_27Laps92Liters()
        {
            //arrange
            var inputs = new FuelCalculatorInputs(2, 17, 500, 3.4, 1, 0, true);
            var target = new FuelCalculatorService();

            //act
            var result = target.CalculateFuel(inputs);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(27, result.EstimatedLaps);
            Assert.AreEqual(96, result.FuelNeeded);
        }

        [TestMethod]
        public void CalculateFuel_SpaSampleNoFormationLap45Minutes_19Laps65Liters()
        {
            //arrange
            var inputs = new FuelCalculatorInputs(2, 17, 500, 3.4, 0, 45, false);
            var target = new FuelCalculatorService();

            //act
            var result = target.CalculateFuel(inputs);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(19, result.EstimatedLaps);
            Assert.AreEqual(68, result.FuelNeeded);
        }

        [TestMethod]
        public void CalculateFuel_MonzaSampleFormationLap90Minutes_51Laps143Liters()
        {
            //arrange
            var inputs = new FuelCalculatorInputs(1, 47, 900, 2.8, 0, 90, true);
            var target = new FuelCalculatorService();

            //act
            var result = target.CalculateFuel(inputs);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(51, result.EstimatedLaps);
            Assert.AreEqual(146, result.FuelNeeded);
        }
    }
}
