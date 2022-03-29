namespace Services.Clients;

public class ClientFacadeService : IClientFacadeService
{
    private readonly IClientRepositoryService _repository;

    public ClientFacadeService(IClientRepositoryService repository) =>
        _repository = repository;

    public async Task<List<Client>> GetClientListAsync() =>
        await _repository.GetClientListAsync() ?? new();

    public async Task CreateAsync(Client client)
    {
        if (client is null) return;

        await _repository.CreateAsync(client);
    }

    public async Task DeleteAsync(int clientId)
    {
        if (clientId < 1) return;

        await _repository.DeleteAsync(clientId);
    }
}