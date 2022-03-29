namespace Features.Workers.Commands;

public class CreateWorkerCommandHandler
    : IRequestHandler<CreateWorkerCommand>
{
    private readonly ApplicationContext _context;

    public CreateWorkerCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(CreateWorkerCommand request, CancellationToken token)
    {
        if (request.Worker is null) return Unit.Value;

        await _context.Workers.AddAsync(entity: request.Worker, cancellationToken: token);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}