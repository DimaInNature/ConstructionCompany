namespace Services.Abstract.Clients;

public interface IClientFacadeService
{
    Task<List<Client>> GetClientListAsync();
    Task CreateAsync(Client client);
    Task DeleteAsync(int clientId);
}