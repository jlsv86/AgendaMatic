using System;

namespace AgendaMatic.Domain.Dto.Queries
{
    public class GetScheduleQuery
    {
        public Guid UserId { get; set; }

        public GetScheduleQuery()
        {
        }

        public GetScheduleQuery(Guid id)
        {
            UserId = id;
        }
    }
}
