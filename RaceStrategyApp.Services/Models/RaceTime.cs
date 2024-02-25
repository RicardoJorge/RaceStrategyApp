namespace RaceStrategyApp.Services.Models
{
    public class RaceTime
    {
        public int RaceLengthInSeconds { get; } = 0;

        public RaceTime(int hours, int minutes)
        {
            if (hours > 0)
            {
                this.RaceLengthInSeconds = hours*60*60;
            }

            if(minutes > 0)
            {
                this.RaceLengthInSeconds += minutes*60;
            }
        }
    }
}