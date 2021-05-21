using AgendaMatic.Domain.Entities;
using AgendaMatic.Domain.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaMatic.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ScheduleContext Context;

        public ScheduleRepository(ScheduleContext context)
        {
            Context = context;
        }

        public async Task<bool> AddSchedule(Schedule schedule)
        {
            await Context.Schedule.AddAsync(schedule);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddUser(User user)
        {

            await Context.User.AddAsync(user);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSchedule(Guid id)
        {
            var schedule = await Context.Schedule.FindAsync(id);

            if (schedule == null)
                return false;

            Context.Remove(schedule);
            await Context.SaveChangesAsync();

            return true;
        }

        public async Task<Schedule[]> GetSchedules(Guid? userId)
        {
            return await Context.Schedule.Where(w => userId == null || w.UserId == userId).ToArrayAsync();
        }

        public async Task<Schedule> GetSchedule(DateTime scheduledTime)
        {
            var date = new DateTime(scheduledTime.Year, scheduledTime.Month, scheduledTime.Day, scheduledTime.Hour, scheduledTime.Minute, 0);

            return await Context.Schedule.FirstOrDefaultAsync(s => s.ScheduleTime == date);
        }

        public async Task<User> GetUser(string email, string password)
        {
            return await Context.User.Where(w => w.Email == email)
                .Where(w => w.Password == password)
                    .FirstOrDefaultAsync();
        }
    }
}