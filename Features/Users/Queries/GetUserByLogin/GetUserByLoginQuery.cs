namespace Features.Users.Queries;

public class GetUserByLoginQuery : IRequest<User>
{
    public string? Login { get; set; }

    public GetUserByLoginQuery(string login) => Login = login;

    public GetUserByLoginQuery() { }
}