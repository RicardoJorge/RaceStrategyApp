using RaceStrategyApp.Services.Models;

namespace RaceStrategyApp.Services.Tests.Models
{
    [TestClass]
    public class StintTimeTests
    {
        [TestMethod]
        public void StintTime_OnlyMinutes_ShouldReturnOnlyMinutes()
        {
            //arrange && act
            var stintTime = new RaceTime(0, 30);

            //assert
            Assert.AreEqual(1800, stintTime.RaceLengthInSeconds);
        }

        [TestMethod]
        public void StintTime_OnlyHours_ShouldReturnOnlyHours()
        {
            //arrange && act
            var stintTime = new RaceTime(2, 0);

            //assert
            Assert.AreEqual(7200, stintTime.RaceLengthInSeconds);
        }

        [TestMethod]
        public void StintTime_HoursPlusMinutes_ShouldAddBoth()
        {
            //arrange && act
            var stintTime = new RaceTime(2, 45);

            //assert
            Assert.AreEqual(9900, stintTime.RaceLengthInSeconds);
        }

        [TestMethod]
        public void StintTime_NegativeHours_ShouldReturn0()
        {
            //arrange && act
            var stintTime = new RaceTime(-2, 0);

            //assert
            Assert.AreEqual(0, stintTime.RaceLengthInSeconds);
        }

        [TestMethod]
        public void StintTime_NegativeMinutes_ShouldReturn0()
        {
            //arrange && act
            var stintTime = new RaceTime(0, -10);

            //assert
            Assert.AreEqual(0, stintTime.RaceLengthInSeconds);
        }
    }
}
