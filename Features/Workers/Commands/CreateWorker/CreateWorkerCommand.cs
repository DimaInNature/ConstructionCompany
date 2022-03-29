namespace Features.Workers.Commands;

public class CreateWorkerCommand : IRequest
{
    public Worker? Worker { get; set; }

    public CreateWorkerCommand(Worker? worker) => Worker = worker;

    public CreateWorkerCommand() { }
}