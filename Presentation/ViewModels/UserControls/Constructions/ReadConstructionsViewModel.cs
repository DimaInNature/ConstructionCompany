namespace Presentation.ViewModels.UserControls.Constructions;

internal class ReadConstructionsViewModel
    : BaseReadViewModel<Construction>, IReadConstructionsViewModel
{
    private readonly IConstructionFacadeService _constructionService;

    public ReadConstructionsViewModel(IConstructionFacadeService constructionService)
    {
        _constructionService = constructionService;

        Task.Run(InitializeData);
    }

    private async Task InitializeData()
    {
        Items = await _constructionService.GetConstructionListAsync();
    }
}