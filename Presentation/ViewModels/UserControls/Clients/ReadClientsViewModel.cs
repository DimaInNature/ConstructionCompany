namespace Presentation.ViewModels.UserControls.Clients;

internal class ReadClientsViewModel
    : BaseReadViewModel<Client>, IReadClientsViewModel
{
    private readonly IClientFacadeService _clientService;

    public ReadClientsViewModel(IClientFacadeService clientService)
    {
        _clientService = clientService;

        Task.Run(InitializeData);
    }

    private async Task InitializeData()
    {
        Items = await _clientService.GetClientListAsync();
    }
}