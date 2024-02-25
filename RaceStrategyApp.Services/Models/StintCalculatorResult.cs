namespace RaceStrategyApp.Services.Models
{
    public class StintCalculatorResult
    {
        public int RaceLaps { get; }
        public int StartingFuel { get; }
        public PitStop[] Pitboard { get; }

        public StintCalculatorResult(int raceLaps, int startingFuel, PitStop[] pitboard)
        {
            this.RaceLaps = raceLaps;
            this.StartingFuel = startingFuel;
            this.Pitboard = pitboard;
        }
    }


}
