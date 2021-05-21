using AgendaMatic.Domain.Dto.Commands;
using AgendaMatic.Domain.Dto.Queries;
using AgendaMatic.Domain.Interfaces.Interactors;
using AgendaMatic.WebApi.Models;
using AgendaMatic.WebApi.Models.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AgendaMatic.WebApi.Controllers.v1
{
    [ApiController]
    public class ScheduleController : ApiBaseController
    {
        private IScheduleManager Manager;

        public ScheduleController(IScheduleManager manager)
        {
            Manager = manager;
        }

        [HttpGet]
        public async Task<DefaultResponse<GetScheduleResult[]>> Get(Guid id)
        {
            return await Handle<GetScheduleResult[]>(async () =>
            {
                return await Manager.GetSchedules(new GetScheduleQuery(id));
            });
        }

        [HttpPost]
        public async Task<DefaultResponse<bool>> Post(ScheduleModel request)
        {
            return await Handle<bool>(async () =>
            {
                return await Manager.AddSchedule(new AddScheduleCommand(request.UserId, request.ScheduleTime));
            });
        }
    }
}