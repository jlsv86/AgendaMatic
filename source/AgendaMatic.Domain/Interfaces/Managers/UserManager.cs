using AgendaMatic.Domain.Dto.Commands;
using AgendaMatic.Domain.Dto.Queries;
using AgendaMatic.Domain.Entities;
using AgendaMatic.Domain.Interfaces.Interactors;
using AgendaMatic.Domain.Interfaces.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AgendaMatic.Domain.Interfaces.Managers
{
    public class UserManager : IUserManager
    {
        ILogger<UserManager> _logger;
        IScheduleRepository _repository;

        public UserManager(ILogger<UserManager> logger, IScheduleRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<bool> AddUser(AddUserCommand cmd)
        {
            try
            {
                await _repository.AddUser(new User(Guid.NewGuid(), cmd.Email, cmd.Password));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el usuario", cmd);
                throw ex;
            }
        }

        public async Task<GetUserResult> GetUser(GetUserQuery qry)
        {
            try
            {
                var data = await _repository.GetUser(qry.Email, qry.Password);

                return new GetUserResult(data.UserId, data.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el usuario", qry);
                throw ex;
            }
        }
    }
}
