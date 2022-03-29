namespace Services.Abstract.Clients;

public interface IClientRepositoryService
{
    Task<List<Client>?> GetClientListAsync();
    Task CreateAsync(Client client);
    Task DeleteAsync(int clientId);
}