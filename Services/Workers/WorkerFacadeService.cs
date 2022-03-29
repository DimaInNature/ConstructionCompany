namespace Services.Workers;

public class WorkerFacadeService : IWorkerFacadeService
{
    private readonly IWorkerRepositoryService _repository;

    public WorkerFacadeService(IWorkerRepositoryService repository) =>
        _repository = repository;

    public async Task<List<Worker>> GetWorkerListAsync() =>
        await _repository.GetWorkerListAsync() ?? new();

    public async Task CreateAsync(Worker worker)
    {
        if (worker is null) return;

        await _repository.CreateAsync(worker);
    }

    public async Task DeleteAsync(int workerId)
    {
        if (workerId < 1) return;

        await _repository.DeleteAsync(workerId);
    }
}