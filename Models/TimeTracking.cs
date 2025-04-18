﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelanceManager.Models
{
    public class TimeTracking
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan EstimateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        [ForeignKey(nameof(MissionId))]
        public int MissionId { get; set; }                  

        public Mission Mission { get; set; }
    }
}