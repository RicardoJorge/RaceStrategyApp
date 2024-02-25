using RaceStrategyApp.Services.Models;

namespace RaceStrategyApp.Services.Interfaces
{
    public interface IStintCaluclatorService
    {
        public StintCalculatorResult CalculateStint(StintCalculatorInputs inputs);
    }
}
