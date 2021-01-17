using System;
using System.Collections.Generic;
using System.Linq;

namespace ActivitySelection
{
    class Activity
    {
        public int StartTime { get; set; }

        public int EndTime { get; set; }
    }

    class ActivitySelection
    {
        static void Main(string[] args)
        {
            var startingTimes = new[] { 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12 };
            var endingTimes = new[] {4, 5, 6, 7 ,8 ,9 ,10, 11, 12, 13, 14 };

            var activities = new List<Activity>();

            for (int i = 0; i < startingTimes.Length; i++)
            {
                activities.Add(new Activity 
                {
                    StartTime = startingTimes[i],
                    EndTime = endingTimes[i]
                });
            }

            activities = activities.OrderBy(a => a.EndTime).ToList();

            var last = activities.First();
            Console.WriteLine($"{last.StartTime} - {last.EndTime}");

            for (int i = 1; i < activities.Count; i++)
            {
                var currentActivity = activities[i];
                if (currentActivity.StartTime >= last.EndTime)
                {
                    last = currentActivity;
                    Console.WriteLine($"{last.StartTime} - {last.EndTime}");
                }
            }
        }
    }
}
