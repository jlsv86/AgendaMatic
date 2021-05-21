using System;

namespace AgendaMatic.Domain.Dto.Commands
{
    public class AddScheduleCommand
    {
        public Guid UserId { get; set; }
        public DateTime ScheduledTime { get; set; }

        public AddScheduleCommand()
        {
        }

        public AddScheduleCommand(Guid userId, DateTime scheduledTime)
        {
            UserId = userId;
            ScheduledTime = new DateTime(scheduledTime.Year, scheduledTime.Month, scheduledTime.Day, scheduledTime.Hour, scheduledTime.Minute, 0); ;
        }
    }
}
