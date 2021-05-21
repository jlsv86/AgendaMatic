using System;

namespace AgendaMatic.Domain.Dto.Queries
{
    public class GetUserResult
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }

        public GetUserResult()
        {
        }

        public GetUserResult(Guid id, string email)
        {
            UserId = id;
            Email = email;
        }
    }
}
