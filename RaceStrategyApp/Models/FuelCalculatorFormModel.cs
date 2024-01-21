using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RaceStrategyApp.Models
{
    public class FuelCalculatorFormModel
    {
        public bool HasFormationLap { get; set; }

        [Range(0, int.MaxValue)]
        public int LapMinutes { get; set; }
        public int LapSeconds { get; set; }
        public int LapMiliseconds { get; set; }
        public double LitersPerLap { get; set; }
        public int StintHours { get; set; }
        public int StintMinutes { get; set; }

        public FuelCalculatorFormModel() { }
    }
}
