using AgendaMatic.Domain.Entities;
using System;

namespace AgendaMatic.Domain.Dto.Queries
{
    public class GetScheduleResult
    {
        public Guid ScheduleId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ScheduleTime { get; set; }

        public GetScheduleResult()
        {
        }

        public GetScheduleResult(Schedule schedule)
        {
            ScheduleId = schedule.ScheduleId;
            UserId = schedule.UserId;
            ScheduleTime = schedule.ScheduleTime;
        }
    }
}
