namespace Services.Constructions;

public class ConstructionFacadeService : IConstructionFacadeService
{
    private readonly IConstructionRepositoryService _repository;

    public ConstructionFacadeService(IConstructionRepositoryService repository) =>
        _repository = repository;

    public async Task<List<Construction>> GetConstructionListAsync() =>
        await _repository.GetConstructionListAsync() ?? new();

    public async Task CreateAsync(Construction construction)
    {
        if (construction is null) return;

        await _repository.CreateAsync(construction);
    }

    public async Task UpdateAsync(Construction construction)
    {
        if (construction is null) return;

        await _repository.UpdateAsync(construction);
    }

    public async Task DeleteAsync(int constructionId)
    {
        if (constructionId < 1) return;

        await _repository.DeleteAsync(constructionId);
    }
}