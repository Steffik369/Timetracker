using System;
using System.ComponentModel.DataAnnotations;

namespace Timetracker.Models
{
    public class JobItem
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Type { get; set; }

        [Required]
        public DateTime? Start { get; set; }

        [Required]
        public DateTime? End { get; set; }
        //public TimeSpan ElapsedTime
        //{
        //    get { return (Start != null && End != null) ? (End.Value.TimeOfDay - Start.Value.TimeOfDay) : TimeSpan.Zero; }
        //}
    }

    public enum JobType
    {
        Coding,
        Testing,
        Debuging
    }
}
