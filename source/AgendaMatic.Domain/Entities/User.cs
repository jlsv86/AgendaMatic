using System;

namespace AgendaMatic.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User()
        {
        }

        public User(Guid userId, string email, string password)
        {
            UserId = userId;
            Email = email;
            Password = password;
        }
    }
}
