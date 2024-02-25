namespace RaceStrategyApp.Services.Models
{
    public class PitStop
    {
        public TimeSpan EleapsedTime { get; }
        public int Lap { get; }
        public int Refuel { get; }

        public PitStop(TimeSpan eleapsedTime, int lap, int refuel)
        {
            this.EleapsedTime = eleapsedTime;
            this.Lap = lap;
            this.Refuel = refuel;
        }
    }
}