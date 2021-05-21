using AgendaMatic.Domain.Dto.Commands;
using AgendaMatic.Domain.Dto.Queries;
using System.Threading.Tasks;

namespace AgendaMatic.Domain.Interfaces.Interactors
{
    public interface IScheduleManager
    {
        Task<bool> AddSchedule(AddScheduleCommand cmd);
        Task<GetScheduleResult[]> GetSchedules(GetScheduleQuery qry);
        Task<bool> DeleteSchedule(DeleteScheduleCommand cmd);
    }
}
