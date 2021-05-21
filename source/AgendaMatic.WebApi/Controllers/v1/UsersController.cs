using AgendaMatic.Domain.Dto.Commands;
using AgendaMatic.Domain.Dto.Queries;
using AgendaMatic.Domain.Interfaces.Interactors;
using AgendaMatic.WebApi.Models;
using AgendaMatic.WebApi.Models.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AgendaMatic.WebApi.Controllers.v1
{
    [ApiController]
    public class UsersController : ApiBaseController
    {
        private IUserManager Manager;

        public UsersController(IUserManager manager)
        {
            Manager = manager;
        }

        [HttpGet]
        public async Task<DefaultResponse<GetUserResult>> Get(string email, string password)
        {
            return await Handle<GetUserResult>(async () =>
            {
                return await Manager.GetUser(new GetUserQuery(email, password));
            });
        }

        [HttpPost]
        public async Task<DefaultResponse<bool>> Post(UserModel request)
        {
            return await Handle<bool>(async () =>
            {
                return await Manager.AddUser(new AddUserCommand(request.Email, request.Password));
            });
        }
    }
}