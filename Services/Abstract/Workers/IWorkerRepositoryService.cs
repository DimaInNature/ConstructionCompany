namespace Services.Abstract.Workers;

public interface IWorkerRepositoryService
{
    Task<List<Worker>?> GetWorkerListAsync();
    Task CreateAsync(Worker worker);
    Task DeleteAsync(int workerId);
}