namespace Presentation.ViewModels.UserControls.Reports;

internal class ReportsViewModel
    : BaseReadViewModel<Construction>, IReportsViewModel
{
    private readonly IConstructionFacadeService _constructionService;

    public ReportsViewModel(IConstructionFacadeService constructionService)
    {
        _constructionService = constructionService;

        Task.Run(InitializeData);
    }

    private async Task InitializeData()
    {
        Items = await _constructionService.GetConstructionListAsync();
    }
}