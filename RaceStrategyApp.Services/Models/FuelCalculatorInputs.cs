﻿using System.ComponentModel;

namespace RaceStrategyApp.Services.Models
{
    public class FuelCalculatorInputs
    {
        public TimeSpan LapTime { get; }
        public double LitersPerLap { get; }
        public StintTime StintTime { get; }
        public bool HasFormationLap { get; }

        public FuelCalculatorInputs(int laptimeMinutes, int laptimeSeconds, int laptimeMiliseconds, double litersPerLap, int stintHours, int stintMinutes, bool hasFormationLap)
        {
            this.LapTime = new TimeSpan(0, 0, laptimeMinutes, laptimeSeconds, laptimeMiliseconds);
            this.LitersPerLap = litersPerLap;
            this.StintTime =  new StintTime(stintHours, stintMinutes);
            this.HasFormationLap = hasFormationLap;
        }
    }
}
