namespace Features.Workers.Commands;

public class DeleteWorkerCommand : IRequest
{
    public int Id { get; set; }

    public DeleteWorkerCommand(int id) => Id = id;

    public DeleteWorkerCommand() { }
}