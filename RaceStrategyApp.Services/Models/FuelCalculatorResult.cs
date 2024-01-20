namespace RaceStrategyApp.Services.Models
{
    public class FuelCalculatorResult
    {
        public int FuelNeeded { get; set; }
        public int EstimatedLaps { get; set; }

        public FuelCalculatorResult(int fuelNeeded, int estimatedLaps) {
            this.FuelNeeded = fuelNeeded;
            this.EstimatedLaps = estimatedLaps;
        }
    }
}
