using AgendaMatic.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AgendaMatic.Domain.Interfaces.Persistence.Repositories
{
    public interface IScheduleRepository
    {
        Task<Schedule[]> GetSchedules(Guid? userId);
        Task<Schedule> GetSchedule(DateTime date);
        Task<bool> AddSchedule(Schedule schedule);
        Task<bool> DeleteSchedule(Guid id);
        Task<User> GetUser(string email, string password);
        Task<bool> AddUser(User user);
    }
}
