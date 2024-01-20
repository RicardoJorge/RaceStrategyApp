using RaceStrategyApp.Services.Models;

namespace RaceStrategyApp.Services
{
    public interface IFuelCalculatorService
    {
        public FuelCalculatorResult CalculateFuel(FuelCalculatorInputs intput);
    }
}
