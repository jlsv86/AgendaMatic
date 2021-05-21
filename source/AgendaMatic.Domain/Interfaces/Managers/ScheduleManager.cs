using AgendaMatic.Domain.Dto.Commands;
using AgendaMatic.Domain.Dto.Queries;
using AgendaMatic.Domain.Entities;
using AgendaMatic.Domain.Interfaces.Interactors;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AgendaMatic.Domain.Interfaces.Persistence.Repositories;
using AgendaMatic.Domain.Exceptions;
using System.Linq;

namespace AgendaMatic.Domain.Interfaces.Managers
{
    public class ScheduleManager : IScheduleManager
    {
        ILogger<ScheduleManager> _logger;
        IScheduleRepository _repository;

        public ScheduleManager(ILogger<ScheduleManager> logger, IScheduleRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<bool> AddSchedule(AddScheduleCommand cmd)
        {
            try
            {
                var exits = await _repository.GetSchedule(cmd.ScheduledTime);

                if (exits != null)
                    throw new BusinessException("La hora reservada no esta disponible");

                var schedule = new Schedule(Guid.NewGuid(), cmd.UserId, cmd.ScheduledTime);

                await _repository.AddSchedule(schedule);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la reserva", cmd);
                throw ex;
            }
        }

        public async Task<bool> DeleteSchedule(DeleteScheduleCommand cmd)
        {
            try
            {
                await _repository.DeleteSchedule(cmd.ScheduleId);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar la reserva", cmd);
                throw ex;
            }
        }

        public async Task<GetScheduleResult[]> GetSchedules(GetScheduleQuery qry)
        {
            try
            {
                var data = await _repository.GetSchedules(qry.UserId);

                return data.Select(s => new GetScheduleResult(s)).ToArray();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las reservas", qry);
                throw ex;
            }
        }
    }
}
