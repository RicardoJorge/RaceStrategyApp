using RaceStrategyApp.Services.Models;

namespace RaceStrategyApp.Services.Interfaces
{
    public interface IFuelCalculatorService
    {
        public FuelCalculatorResult CalculateFuel(FuelCalculatorInputs intput);
    }
}
