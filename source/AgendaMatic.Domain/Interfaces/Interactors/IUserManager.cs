using AgendaMatic.Domain.Dto.Commands;
using AgendaMatic.Domain.Dto.Queries;
using System.Threading.Tasks;

namespace AgendaMatic.Domain.Interfaces.Interactors
{
    public interface IUserManager
    {
        Task<bool> AddUser(AddUserCommand cmd);
        Task<GetUserResult> GetUser(GetUserQuery qry);
    }
}
