namespace AgendaMatic.Domain.Dto.Commands
{
    public class AddUserCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public AddUserCommand()
        {
        }

        public AddUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
