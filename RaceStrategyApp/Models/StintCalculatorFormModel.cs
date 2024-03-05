using System.ComponentModel.DataAnnotations;

namespace RaceStrategyApp.Models
{
    public class StintCalculatorFormModel
    {
        public bool HasFormationLap { get; set; }

        [Range(0, int.MaxValue)]
        public int LapMinutes { get; set; }
        public int LapSeconds { get; set; }
        public int LapMiliseconds { get; set; }
        public double LitersPerLap { get; set; }
        public int RaceHours { get; set; }
        public int RaceMinutes { get; set; }
        public int StintLimit { get; set; }
        public int TankSize { get; set; }

        public StintCalculatorFormModel() { }
    }
}
