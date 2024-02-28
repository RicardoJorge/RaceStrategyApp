namespace RaceStrategyApp.Services.Models
{
    public class StintCalculatorInputs
    {
        public TimeSpan LapTime { get; }
        public double LitersPerLap { get; }
        public RaceTime RaceTime { get; }
        public bool HasFormationLap { get; }
        public int TankSize { get; }
        public int StintLimitInSeconds { get; }

        public StintCalculatorInputs(int laptimeMinutes, int laptimeSeconds, int laptimeMiliseconds, double litersPerLap, int stintHours, int stintMinutes, bool hasFormationLap, int tankSize, int stintLimitInMinutes)
        {
            this.LapTime = new TimeSpan(0, 0, laptimeMinutes, laptimeSeconds, laptimeMiliseconds);
            this.LitersPerLap = litersPerLap;
            this.RaceTime = new RaceTime(stintHours, stintMinutes);
            this.HasFormationLap = hasFormationLap;
            this.TankSize = tankSize;
            this.StintLimitInSeconds = stintLimitInMinutes == 0 ? int.MaxValue : stintLimitInMinutes * 60;
        }
    }
}
