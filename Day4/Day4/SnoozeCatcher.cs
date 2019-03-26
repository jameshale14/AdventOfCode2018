using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Day4
{
    public class SnoozeCatcher
    {
        public (int guardID, int minute) GetSnooziestGuard(string input)
        {
            // parse the input into something manageable
            string[] inputArray = input.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            SortedDictionary<string, string> timestamps = new SortedDictionary<string, string>();
            foreach (string line in inputArray)
            {
                string[] lineArr = line.Split(']');
                timestamps.Add(lineArr[0], lineArr[1]);
            }

            // go through each line of the input, total up the time spent asleep, and the number of times each minute was spent asleep by each guard

            Dictionary<int, Dictionary<int, int>> guards = new Dictionary<int, Dictionary<int, int>>();
            //guards[guardID][minute] - value = frequency of minute asleep

            int guardId = 0;
            var guardRegex = new Regex(@"#(\d+) ");
            var minuteRegex = new Regex(@":(\d\d)");

            int sleepTime = 0;
            int wakeTime = 0;
            foreach (var entry in timestamps)
            {
                if (entry.Value.Contains("begins"))
                {
                    //get the guardID
                    var match = guardRegex.Match(entry.Value);
                    guardId = Int32.Parse(match.Groups[1].Value);
                    guards.TryAdd(guardId, new Dictionary<int, int>());

                }
                else if (entry.Value.Contains("falls"))
                {
                    var minuteMatch = minuteRegex.Match(entry.Key);
                    sleepTime = Int32.Parse(minuteMatch.Groups[1].Value);
                }
                else if (entry.Value.Contains("up"))
                {
                    //get the awake time
                    var minuteMatch = minuteRegex.Match(entry.Key);
                    wakeTime = Int32.Parse(minuteMatch.Groups[1].Value);

                    // add entries for the guardID for each minute between asleep time and wake up time
                    for (int i = sleepTime; i < wakeTime; i++)
                    {
                        if (guards[guardId].TryGetValue(i, out var val))
                        {
                            guards[guardId][i]++;
                        }
                        else
                        {
                            guards[guardId].Add(i, 1);
                        }
                    }
                }
            }

            // get the guard that is asleep for the most amount of minutes
            int sleepiestGuard = 0;
            int minutesSlept = 0;

            foreach (var guard in guards)
            {
                int minutes = 0;
                foreach (var minute in guard.Value)
                {
                    minutes += minute.Value;
                }

                if (minutes > minutesSlept)
                {
                    minutesSlept = minutes;
                    sleepiestGuard = guard.Key;
                }
            }

            // for the guard that is asleep the most, get the minute that most spent asleep
            int sleepiestMinute = 0;
            minutesSlept = 0;
            foreach (var minute in guards[sleepiestGuard])
            {
                if (minutesSlept < minute.Value)
                {
                    sleepiestMinute = minute.Key;
                    minutesSlept = minute.Value;
                }
            }

            return (sleepiestGuard, sleepiestMinute);
        }

        public (int guardID, int minute) GetSnooziestMinuteForOneGuard(string input)
        {
            string[] inputArray = input.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            SortedDictionary<string, string> timestamps = new SortedDictionary<string, string>();
            foreach (string line in inputArray)
            {
                string[] lineArr = line.Split(']');
                timestamps.Add(lineArr[0], lineArr[1]);
            }

            // go through each line of the input, total up the time spent asleep, and the number of times each minute was spent asleep by each guard

            Dictionary<int, Dictionary<int, int>> guards = new Dictionary<int, Dictionary<int, int>>();
            //guards[guardID][minute] - value = frequency of minute asleep

            int guardId = 0;
            var guardRegex = new Regex(@"#(\d+) ");
            var minuteRegex = new Regex(@":(\d\d)");

            int sleepTime = 0;
            int wakeTime = 0;
            foreach (var entry in timestamps)
            {
                if (entry.Value.Contains("begins"))
                {
                    //get the guardID
                    var match = guardRegex.Match(entry.Value);
                    guardId = Int32.Parse(match.Groups[1].Value);
                    guards.TryAdd(guardId, new Dictionary<int, int>());

                }
                else if (entry.Value.Contains("falls"))
                {
                    var minuteMatch = minuteRegex.Match(entry.Key);
                    sleepTime = Int32.Parse(minuteMatch.Groups[1].Value);
                }
                else if (entry.Value.Contains("up"))
                {
                    //get the awake time
                    var minuteMatch = minuteRegex.Match(entry.Key);
                    wakeTime = Int32.Parse(minuteMatch.Groups[1].Value);

                    // add entries for the guardID for each minute between asleep time and wake up time
                    for (int i = sleepTime; i < wakeTime; i++)
                    {
                        if (guards[guardId].TryGetValue(i, out var val))
                        {
                            guards[guardId][i]++;
                        }
                        else
                        {
                            guards[guardId].Add(i, 1);
                        }
                    }
                }
            }

            // get the minute that was spent asleep most by the same guard
            int sleepiestMinute = 0;
            int minutesSlept = 0;
            int snoozyGuard = 0;
            foreach (var guard in guards)
            {
                foreach (var minute in guard.Value)
                {
                    if (minutesSlept < minute.Value)
                    {
                        sleepiestMinute = minute.Key;
                        minutesSlept = minute.Value;
                        snoozyGuard = guard.Key;
                    }
                }
            }

            return (snoozyGuard, sleepiestMinute);
        }
    }

}
