namespace Features.Users.Commands;

public class CreateUserCommand : IRequest
{
    public User? User { get; set; }

    public CreateUserCommand(User user) => User = user;

    public CreateUserCommand() { }
}