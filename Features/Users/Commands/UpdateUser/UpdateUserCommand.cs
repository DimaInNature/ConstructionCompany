namespace Features.Users.Commands;

public class UpdateUserCommand : IRequest
{
    public User? User { get; set; }

    public UpdateUserCommand(User user) => User = user;

    public UpdateUserCommand() { }
}