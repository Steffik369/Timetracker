using System;

namespace Timetracker.Models
{
    public class JobItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public JobType Type { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public TimeSpan ElapsedTime { get; set; }
    }

    public enum JobType
    {
        Coding,
        Testing,
        Debuging
    }
}
