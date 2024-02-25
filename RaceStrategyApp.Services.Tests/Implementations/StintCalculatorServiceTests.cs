using RaceStrategyApp.Services.Implementations;
using RaceStrategyApp.Services.Models;

namespace RaceStrategyApp.Services.Tests.Implementations
{
    [TestClass]
    public class StintCalculatorServiceTests
    {
        [TestMethod]
        public void CalculateStint_KyalamiSampleThreeHour48MinuteStint()
        {
            //arrange
            var inputs = new StintCalculatorInputs(1, 42, 0, 2.67, 3, 0, false, 120, 48);
            var target = new StintCalculatorService();

            //act
            var result = target.CalculateStint(inputs);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(75, result.StartingFuel);
            Assert.AreEqual(3, result.Pitboard.Length);
            Assert.AreEqual(103, result.RaceLaps);
            Assert.AreEqual(27, result.Pitboard[0].Lap);
            Assert.AreEqual(75, result.Pitboard[0].Refuel);
            Assert.AreEqual(2856, result.Pitboard[0].EleapsedTime.TotalSeconds);
            Assert.AreEqual(55, result.Pitboard[1].Lap);
            Assert.AreEqual(75, result.Pitboard[1].Refuel);
            Assert.AreEqual(5777, result.Pitboard[1].EleapsedTime.TotalSeconds);
            Assert.AreEqual(83, result.Pitboard[2].Lap);
            Assert.AreEqual(57, result.Pitboard[2].Refuel);
            Assert.AreEqual(8698, result.Pitboard[2].EleapsedTime.TotalSeconds);
        }

        [TestMethod]
        public void CalculateStint_KyalamiSampleThreeHour48MinuteStintWithFormationLap()
        {
            //arrange
            var inputs = new StintCalculatorInputs(1, 42, 0, 2.67, 3, 0, true, 120, 48);
            var target = new StintCalculatorService();

            //act
            var result = target.CalculateStint(inputs);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(78, result.StartingFuel);
            Assert.AreEqual(3, result.Pitboard.Length);
            Assert.AreEqual(103, result.RaceLaps);
            Assert.AreEqual(27, result.Pitboard[0].Lap);
            Assert.AreEqual(75, result.Pitboard[0].Refuel);
            Assert.AreEqual(2856, result.Pitboard[0].EleapsedTime.TotalSeconds);
            Assert.AreEqual(55, result.Pitboard[1].Lap);
            Assert.AreEqual(75, result.Pitboard[1].Refuel);
            Assert.AreEqual(5777, result.Pitboard[1].EleapsedTime.TotalSeconds);
            Assert.AreEqual(83, result.Pitboard[2].Lap);
            Assert.AreEqual(57, result.Pitboard[2].Refuel);
            Assert.AreEqual(8698, result.Pitboard[2].EleapsedTime.TotalSeconds);
        }

        [TestMethod]
        public void CalculateStint_BathurstSample4h3048MinuteStint()
        {
            //arrange
            var inputs = new StintCalculatorInputs(2, 03, 0, 3.27, 4, 30, false, 120, 48);
            var target = new StintCalculatorService();

            //act
            var result = target.CalculateStint(inputs);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(76, result.StartingFuel);
            Assert.AreEqual(5, result.Pitboard.Length);
            Assert.AreEqual(129, result.RaceLaps);
            Assert.AreEqual(22, result.Pitboard[0].Lap);
            Assert.AreEqual(76, result.Pitboard[0].Refuel);
            Assert.AreEqual(2829, result.Pitboard[0].EleapsedTime.TotalSeconds);
            Assert.AreEqual(45, result.Pitboard[1].Lap);
            Assert.AreEqual(76, result.Pitboard[1].Refuel);
            Assert.AreEqual(5723, result.Pitboard[1].EleapsedTime.TotalSeconds);
            Assert.AreEqual(68, result.Pitboard[2].Lap);
            Assert.AreEqual(76, result.Pitboard[2].Refuel);
            Assert.AreEqual(8617, result.Pitboard[2].EleapsedTime.TotalSeconds);
            Assert.AreEqual(91, result.Pitboard[3].Lap);
            Assert.AreEqual(76, result.Pitboard[3].Refuel);
            Assert.AreEqual(11511, result.Pitboard[3].EleapsedTime.TotalSeconds);
            Assert.AreEqual(114, result.Pitboard[4].Lap);
            Assert.AreEqual(50, result.Pitboard[4].Refuel);
            Assert.AreEqual(14405, result.Pitboard[4].EleapsedTime.TotalSeconds);
        }

        [TestMethod]
        public void CalculateStint_BathurstSample4h3048MinuteStintWithFormationLap()
        {
            //arrange
            var inputs = new StintCalculatorInputs(2, 03, 0, 3.27, 4, 30, true, 120, 48);
            var target = new StintCalculatorService();

            //act
            var result = target.CalculateStint(inputs);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(80, result.StartingFuel);
            Assert.AreEqual(5, result.Pitboard.Length);
            Assert.AreEqual(129, result.RaceLaps);
            Assert.AreEqual(22, result.Pitboard[0].Lap);
            Assert.AreEqual(76, result.Pitboard[0].Refuel);
            Assert.AreEqual(2829, result.Pitboard[0].EleapsedTime.TotalSeconds);
            Assert.AreEqual(45, result.Pitboard[1].Lap);
            Assert.AreEqual(76, result.Pitboard[1].Refuel);
            Assert.AreEqual(5723, result.Pitboard[1].EleapsedTime.TotalSeconds);
            Assert.AreEqual(68, result.Pitboard[2].Lap);
            Assert.AreEqual(76, result.Pitboard[2].Refuel);
            Assert.AreEqual(8617, result.Pitboard[2].EleapsedTime.TotalSeconds);
            Assert.AreEqual(91, result.Pitboard[3].Lap);
            Assert.AreEqual(76, result.Pitboard[3].Refuel);
            Assert.AreEqual(11511, result.Pitboard[3].EleapsedTime.TotalSeconds);
            Assert.AreEqual(114, result.Pitboard[4].Lap);
            Assert.AreEqual(50, result.Pitboard[4].Refuel);
            Assert.AreEqual(14405, result.Pitboard[4].EleapsedTime.TotalSeconds);
        }

        [TestMethod]
        public void CalculateStint_KyalamiSampleThreeHour120LTank()
        {
            //arrange
            var inputs = new StintCalculatorInputs(1, 42, 0, 2.67, 3, 0, false, 120);
            var target = new StintCalculatorService();

            //act
            var result = target.CalculateStint(inputs);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(120, result.StartingFuel);
            Assert.AreEqual(2, result.Pitboard.Length);
            Assert.AreEqual(104, result.RaceLaps);
            Assert.AreEqual(43, result.Pitboard[0].Lap);
            Assert.AreEqual(120, result.Pitboard[0].Refuel);
            Assert.AreEqual(4488, result.Pitboard[0].EleapsedTime.TotalSeconds);
            Assert.AreEqual(87, result.Pitboard[1].Lap);
            Assert.AreEqual(49, result.Pitboard[1].Refuel);
            Assert.AreEqual(9041, result.Pitboard[1].EleapsedTime.TotalSeconds);
        }

        [TestMethod]
        public void CalculateStint_KyalamiSampleThreeHour120LTankWithFormationLap()
        {
            //arrange
            var inputs = new StintCalculatorInputs(1, 42, 0, 2.67, 3, 0, true, 120);
            var target = new StintCalculatorService();

            //act
            var result = target.CalculateStint(inputs);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(120, result.StartingFuel);
            Assert.AreEqual(2, result.Pitboard.Length);
            Assert.AreEqual(104, result.RaceLaps);
            Assert.AreEqual(42, result.Pitboard[0].Lap);
            Assert.AreEqual(120, result.Pitboard[0].Refuel);
            Assert.AreEqual(4386, result.Pitboard[0].EleapsedTime.TotalSeconds);
            Assert.AreEqual(86, result.Pitboard[1].Lap);
            Assert.AreEqual(51, result.Pitboard[1].Refuel);
            Assert.AreEqual(8939, result.Pitboard[1].EleapsedTime.TotalSeconds);
        }

        [TestMethod]
        public void CalculateStint_BathurstSample4h3FullTank()
        {
            //arrange
            var inputs = new StintCalculatorInputs(2, 03, 0, 3.27, 4, 30, false, 120);
            var target = new StintCalculatorService();

            //act
            var result = target.CalculateStint(inputs);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(120, result.StartingFuel);
            Assert.AreEqual(3, result.Pitboard.Length);
            Assert.AreEqual(130, result.RaceLaps);
            Assert.AreEqual(35, result.Pitboard[0].Lap);
            Assert.AreEqual(120, result.Pitboard[0].Refuel);
            Assert.AreEqual(4428, result.Pitboard[0].EleapsedTime.TotalSeconds);
            Assert.AreEqual(71, result.Pitboard[1].Lap);
            Assert.AreEqual(120, result.Pitboard[1].Refuel);
            Assert.AreEqual(8921, result.Pitboard[1].EleapsedTime.TotalSeconds);
            Assert.AreEqual(107, result.Pitboard[2].Lap);
            Assert.AreEqual(76, result.Pitboard[2].Refuel);
            Assert.AreEqual(13414, result.Pitboard[2].EleapsedTime.TotalSeconds);
        }

        [TestMethod]
        public void CalculateStint_BathurstSample4h3FullTankWithFormationLap()
        {
            //arrange
            var inputs = new StintCalculatorInputs(2, 03, 0, 3.27, 4, 30, true, 120);
            var target = new StintCalculatorService();

            //act
            var result = target.CalculateStint(inputs);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(120, result.StartingFuel);
            Assert.AreEqual(3, result.Pitboard.Length);
            Assert.AreEqual(130, result.RaceLaps);
            Assert.AreEqual(34, result.Pitboard[0].Lap);
            Assert.AreEqual(120, result.Pitboard[0].Refuel);
            Assert.AreEqual(4305, result.Pitboard[0].EleapsedTime.TotalSeconds);
            Assert.AreEqual(70, result.Pitboard[1].Lap);
            Assert.AreEqual(120, result.Pitboard[1].Refuel);
            Assert.AreEqual(8798, result.Pitboard[1].EleapsedTime.TotalSeconds);
            Assert.AreEqual(106, result.Pitboard[2].Lap);
            Assert.AreEqual(79, result.Pitboard[2].Refuel);
            Assert.AreEqual(13291, result.Pitboard[2].EleapsedTime.TotalSeconds);
        }
    }
}
