namespace P01_Chronometer
{
    public interface IChronometer
    {
        string GetTime { get; }

        string Laps();

        void Start();

        void Stop();

        string Lap();

        void Reset();
    }
}
