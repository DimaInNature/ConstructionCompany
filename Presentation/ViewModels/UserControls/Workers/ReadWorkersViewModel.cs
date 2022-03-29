namespace Presentation.ViewModels.UserControls.Workers;

internal class ReadWorkersViewModel
    : BaseReadViewModel<Worker>, IReadWorkersViewModel
{
    private readonly IWorkerFacadeService _workerService;

    public ReadWorkersViewModel(IWorkerFacadeService workerService)
    {
        _workerService = workerService;

        Task.Run(InitializeData);
    }

    private async Task InitializeData()
    {
        Items = await _workerService.GetWorkerListAsync();
    }
}