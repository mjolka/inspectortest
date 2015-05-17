using System;
using System.Threading;

namespace InspectorTest
{
    public class Inspector
    {
        private static readonly Random Random = new Random();

        public string GetInspectionResults()
        {
            var delay = Random.Next(800, 1200);
            Thread.Sleep(TimeSpan.FromMilliseconds(delay));
            return delay.ToString();
        }
    }
}
