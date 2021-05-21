namespace AgendaMatic.Domain.Dto.Queries
{
    public class GetUserQuery
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public GetUserQuery()
        {
        }

        public GetUserQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
