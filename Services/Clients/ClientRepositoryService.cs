namespace Services.Clients;

public class ClientRepositoryService : IClientRepositoryService
{
    private readonly IMediator _mediator;

    public ClientRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<Client>?> GetClientListAsync() =>
        await _mediator.Send(request: new GetClientListQuery());

    public async Task CreateAsync(Client client) =>
        await _mediator.Send(request: new CreateClientCommand(client: client));

    public async Task DeleteAsync(int clientId) =>
        await _mediator.Send(request: new DeleteClientCommand(id: clientId));
}