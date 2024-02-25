using RaceStrategyApp.Services.Interfaces;
using RaceStrategyApp.Services.Models;

namespace RaceStrategyApp.Services.Implementations
{
    public class StintCalculatorService : IStintCaluclatorService
    {
        private const int AVERAGE_TIME_LOST_PITTING = 65;

        public StintCalculatorResult CalculateStint(StintCalculatorInputs inputs)
        {
            var lapsOnAFullTank = CalculateLapsForTheFuel(inputs.TankSize, inputs.LitersPerLap);
            var secondsOnFullTank = CalculateLengthForAGivenLapAmount(lapsOnAFullTank, inputs.LapTime.TotalSeconds);

            var estimatedLapsPerStint = lapsOnAFullTank;
            var estimatedStintLengthInSeconds = secondsOnFullTank;
            var estimatedFuelPerStint = inputs.TankSize;
            var startingFuel = inputs.TankSize;

            if (secondsOnFullTank > inputs.StintLimitInSeconds)
            {
                estimatedLapsPerStint = CalculateLapsInAStint(inputs.LapTime.TotalSeconds, inputs.StintLimitInSeconds);
                estimatedFuelPerStint = CalculateFuel(estimatedLapsPerStint, inputs.LitersPerLap);
                estimatedStintLengthInSeconds = CalculateLengthForAGivenLapAmount(estimatedLapsPerStint, inputs.LapTime.TotalSeconds);
                startingFuel = CalculateStartingFuelConsideringFormationLap(inputs.HasFormationLap, inputs.LitersPerLap, estimatedFuelPerStint);
            }

            var numberOfPitStops = CalculatePitstops(inputs.RaceTime.RaceLengthInSeconds, estimatedStintLengthInSeconds);

            return new StintCalculatorResult(
                    CalculateRaceLaps(inputs.RaceTime.RaceLengthInSeconds, inputs.LapTime.TotalSeconds, numberOfPitStops),
                    startingFuel,
                    CalculatePitStops(estimatedLapsPerStint, estimatedStintLengthInSeconds, numberOfPitStops, estimatedFuelPerStint, inputs.RaceTime.RaceLengthInSeconds, inputs.LapTime.TotalSeconds, inputs.LitersPerLap, inputs.TankSize, inputs.HasFormationLap)
            );
        }

        private static PitStop[] CalculatePitStops(int lapsInStint, double stintLengthInSeconds, int numberOfPitStops, int estimatedFuelPerStint, double raceLengthInSeconds, double lapTimeInSeconds, double litersPerLap, int tankSize, bool hasFormationLap)
        {
            var pitboard = new PitStop[numberOfPitStops];

            pitboard[0] = CalculateFirstStintConsideringFormationLap(hasFormationLap, stintLengthInSeconds, estimatedFuelPerStint, tankSize, lapsInStint, lapTimeInSeconds);

            for (int i = 1; i < numberOfPitStops - 1; i++)
            {
                pitboard[i] = new PitStop(
                    TimeSpan.FromSeconds(CalculateStopSchedule(pitboard[i - 1].EleapsedTime.TotalSeconds, stintLengthInSeconds)),
                    pitboard[i - 1].Lap + lapsInStint,
                    estimatedFuelPerStint);
            }

            var timeLeftAfterLastPitStop = raceLengthInSeconds - pitboard[numberOfPitStops - 2].EleapsedTime.TotalSeconds - stintLengthInSeconds - AVERAGE_TIME_LOST_PITTING;
            int lapsLeftAfterLastPitstop = CalculateLapsToEndTheRace(lapTimeInSeconds, timeLeftAfterLastPitStop);

            pitboard[numberOfPitStops - 1] = new PitStop(
                TimeSpan.FromSeconds(CalculateStopSchedule(pitboard[numberOfPitStops - 2].EleapsedTime.TotalSeconds, stintLengthInSeconds)),
                pitboard[numberOfPitStops - 2].Lap + lapsInStint,
                CalculateFuel(lapsLeftAfterLastPitstop, litersPerLap));

            return pitboard;
        }

        private static PitStop CalculateFirstStintConsideringFormationLap(bool hasFormationLap, double stintLengthInSeconds, int estimatedFuelPerStint, int tankSize, int lapsPerStint, double lapTimeInSeconds)
        {
            if (hasFormationLap && tankSize == estimatedFuelPerStint)
            {
                return new PitStop(
                    TimeSpan.FromSeconds(stintLengthInSeconds - lapTimeInSeconds),
                    lapsPerStint - 2, //you stop on the lap prior to completing it, but they need to be considered for fuel and the full race
                    estimatedFuelPerStint);
            }

            return new PitStop(
                TimeSpan.FromSeconds(stintLengthInSeconds),
                lapsPerStint - 1, //you stop on the lap prior to completing it, but they need to be considered for fuel and the full race
                estimatedFuelPerStint);
        }

        private static int CalculateStartingFuelConsideringFormationLap(bool hasFormationLap, double litersPerLap, int estimatedFuelPerStint)
        {
            return hasFormationLap ? estimatedFuelPerStint + (int)Math.Ceiling(litersPerLap) : estimatedFuelPerStint;
        }

        private static int CalculateLapsForTheFuel(int fuelAmount, double litersPerLap)
        {
            return (int)Math.Floor(fuelAmount / litersPerLap);
        }

        private static double CalculateLengthForAGivenLapAmount(int laps, double lapTimeInSeconds)
        {
            return laps * lapTimeInSeconds;
        }

        private static double CalculateStopSchedule(double currentTimeInSeconds, double stintLengthInSeconds)
        {
            return currentTimeInSeconds + stintLengthInSeconds + AVERAGE_TIME_LOST_PITTING;
        }

        private static int CalculateRaceLaps(double raceLengthInSeconds, double lapTimeInSeconds, int numberOfPitStops)
        {
            return CalculateLapsInAStint(lapTimeInSeconds, raceLengthInSeconds - AVERAGE_TIME_LOST_PITTING * numberOfPitStops);
        }

        private static int CalculatePitstops(double raceLengthInSeconds, double stintLengthInSeconds)
        {
            return (int)Math.Ceiling(raceLengthInSeconds / stintLengthInSeconds) - 1;
        }

        private static int CalculateLapsInAStint(double lapTimeInSeconds, double stintLengthInSeconds)
        {
            return (int)Math.Floor(stintLengthInSeconds / lapTimeInSeconds);
        }

        private static int CalculateLapsToEndTheRace(double lapTimeInSeconds, double stintLengthInSeconds)
        {
            return (int)Math.Ceiling(stintLengthInSeconds / lapTimeInSeconds);
        }

        private static int CalculateFuel(int laps, double litersPerLap)
        {
            return (int)Math.Ceiling(litersPerLap * laps);
        }
    }
}
