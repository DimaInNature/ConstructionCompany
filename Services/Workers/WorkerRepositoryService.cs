namespace Services.Workers;

public class WorkerRepositoryService : IWorkerRepositoryService
{
    private readonly IMediator _mediator;

    public WorkerRepositoryService(IMediator mediator) =>
        _mediator = mediator;

    public async Task<List<Worker>?> GetWorkerListAsync() =>
        await _mediator.Send(request: new GetWorkerListQuery());

    public async Task CreateAsync(Worker worker) =>
        await _mediator.Send(request: new CreateWorkerCommand(worker: worker));

    public async Task DeleteAsync(int workerId) =>
        await _mediator.Send(request: new DeleteWorkerCommand(id: workerId));
}