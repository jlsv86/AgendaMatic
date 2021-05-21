using System;

namespace AgendaMatic.WebApi.Models
{
    public class ScheduleModel
    {
        public Guid UserId { get; set; }
        public DateTime ScheduleTime { get; set; }

        public ScheduleModel()
        {
        }

        public ScheduleModel(Guid userId, DateTime scheduleTime)
        {
            UserId = userId;
            ScheduleTime = scheduleTime;
        }
    }
}
