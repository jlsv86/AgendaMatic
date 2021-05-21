using System;

namespace AgendaMatic.Domain.Dto.Commands
{
    public class DeleteScheduleCommand
    {
        public Guid ScheduleId { get; set; }

        public DeleteScheduleCommand()
        {
        }

        public DeleteScheduleCommand(Guid id)
        {
            ScheduleId = id;
        }
    }
}
