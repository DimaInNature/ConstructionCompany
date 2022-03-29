namespace Services.Abstract.Workers;

public interface IWorkerFacadeService
{
    Task<List<Worker>> GetWorkerListAsync();
    Task CreateAsync(Worker worker);
    Task DeleteAsync(int workerId);
}