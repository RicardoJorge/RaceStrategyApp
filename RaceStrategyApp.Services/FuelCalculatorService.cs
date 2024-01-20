using RaceStrategyApp.Services.Models;

namespace RaceStrategyApp.Services
{
    public class FuelCalculatorService : IFuelCalculatorService
    {
        public FuelCalculatorResult CalculateFuel(FuelCalculatorInputs inputs)
        {
            var estimatedLaps = (int)Math.Floor(inputs.StintTime.RaceLengthInSeconds / inputs.LapTime.TotalSeconds);
            estimatedLaps += inputs.HasFormationLap ? 1 : 0;
            var totalFuelNeeded = (int)Math.Ceiling(estimatedLaps * inputs.LitersPerLap);

            return new FuelCalculatorResult(totalFuelNeeded, estimatedLaps);
        }
    }
}
