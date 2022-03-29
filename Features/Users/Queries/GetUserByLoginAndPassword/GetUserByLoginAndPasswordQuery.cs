namespace Features.Users.Queries;

public class GetUserByLoginAndPasswordQuery : IRequest<User>
{
    public string? Login { get; set; }

    public string? Password { get; set; }

    public GetUserByLoginAndPasswordQuery(string login, string password) =>
        (Login, Password) = (login, password);

    public GetUserByLoginAndPasswordQuery() { }
}