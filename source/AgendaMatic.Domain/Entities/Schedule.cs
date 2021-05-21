using System;

namespace AgendaMatic.Domain.Entities
{
    public class Schedule
    {
        public Guid ScheduleId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime ScheduleTime { get; private set; }

        public Schedule()
        {
        }

        public Schedule(Guid scheduleId, Guid userId, DateTime scheduledTime)
        {
            ScheduleId = scheduleId;
            UserId = userId;
            ScheduleTime = new DateTime(scheduledTime.Year, scheduledTime.Month, scheduledTime.Day, scheduledTime.Hour, scheduledTime.Minute, 0);
        }
    }
}