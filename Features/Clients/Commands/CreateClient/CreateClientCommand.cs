namespace Features.Clients.Commands;

public class CreateClientCommand : IRequest
{
    public Client? Client { get; set; }

    public CreateClientCommand(Client client) => Client = client;

    public CreateClientCommand() { }
}