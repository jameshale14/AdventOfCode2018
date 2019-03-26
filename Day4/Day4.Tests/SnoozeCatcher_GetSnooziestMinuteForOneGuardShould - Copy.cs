using NUnit.Framework;

namespace Day4
{
    public class SnoozeCatcher_GetSnooziestMinuteForOneGuardShould
    {
        private readonly SnoozeCatcher _snoozeCatcher;

        public SnoozeCatcher_GetSnooziestMinuteForOneGuardShould()
        {
            _snoozeCatcher = new SnoozeCatcher();
        }

        [TestCase("[1518 - 11 - 01 00:00] Guard #10 begins shift\n[1518 - 11 - 01 00:05] falls asleep\n[1518 - 11 - 01 00:25] wakes up\n[1518 - 11 - 01 00:30] falls asleep\n[1518 - 11 - 01 00:55] wakes up\n[1518 - 11 - 01 23:58] Guard #99 begins shift\n[1518 - 11 - 02 00:40] falls asleep\n[1518 - 11 - 02 00:50] wakes up\n[1518 - 11 - 03 00:05] Guard #10 begins shift\n[1518 - 11 - 03 00:24] falls asleep\n[1518 - 11 - 03 00:29] wakes up\n[1518 - 11 - 04 00:02] Guard #99 begins shift\n[1518 - 11 - 04 00:36] falls asleep\n[1518 - 11 - 04 00:46] wakes up\n[1518 - 11 - 05 00:03] Guard #99 begins shift\n[1518 - 11 - 05 00:45] falls asleep\n[1518 - 11 - 05 00:55] wakes up", 99, 45)]
        public void ReturnSnooziestMinuteForOneGuard(string input, int guardId, int sleepiestMinute)
        {
            var result = _snoozeCatcher.GetSnooziestMinuteForOneGuard(input);
            Assert.AreEqual(guardId, result.guardID);
            Assert.AreEqual(sleepiestMinute, result.minute);
        }
    }
}