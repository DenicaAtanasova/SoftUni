namespace P01_Chronometer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class Chronometer : IChronometer
    {
        private long milliseconds;

        private List<string> laps;

        private bool isRunning;

        public Chronometer()
        {
            this.Reset();
        }

        public string GetTime =>
            $"{this.milliseconds / 60000:D2}:{this.milliseconds / 1000:D2}:{this.milliseconds % 1000:D4}";

        public string Laps (){
            if (this.laps.Count == 0)
                return "Laps: no laps";

            return string.Join(Environment.NewLine, this.laps.Select((lap, index) => $"{index}. {lap}"));
        }


        public string Lap()
        {
            var cuurentLap =  this.GetTime;
            this.laps.Add(cuurentLap);

            return cuurentLap;
        }

        public void Reset()
        {
            this.isRunning = false;
            this.milliseconds = 0L;
            this.laps = new List<string>();
        }

        public void Start()
        {
            this.isRunning = true;

            Task.Run(() =>
            {
                while (this.isRunning)
                {
                    Thread.Sleep(1);
                    this.milliseconds++;
                }
            });          
        }

        public void Stop()
        {
            this.isRunning = false;
        }
    }
}
