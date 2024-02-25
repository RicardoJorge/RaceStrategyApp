using RaceStrategyApp.Services.Interfaces;
using RaceStrategyApp.Services.Models;

namespace RaceStrategyApp.Services.Implementations
{
    public class FuelCalculatorService : IFuelCalculatorService
    {
        public FuelCalculatorResult CalculateFuel(FuelCalculatorInputs inputs)
        {
            var estimatedLaps = (int)Math.Ceiling(inputs.RaceTime.RaceLengthInSeconds / inputs.LapTime.TotalSeconds);

            estimatedLaps = estimatedLaps > 0 ? estimatedLaps : 0;

            estimatedLaps += inputs.HasFormationLap ? 1 : 0;
            var totalFuelNeeded = (int)Math.Ceiling(estimatedLaps * inputs.LitersPerLap);

            return new FuelCalculatorResult(totalFuelNeeded, estimatedLaps - 1);
        }
    }
}
