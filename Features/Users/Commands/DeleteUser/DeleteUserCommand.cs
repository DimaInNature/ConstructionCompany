namespace Features.Users.Commands;

public class DeleteUserCommand : IRequest
{
    public int Id { get; set; }

    public DeleteUserCommand(int id) => Id = id;

    public DeleteUserCommand() { }
}