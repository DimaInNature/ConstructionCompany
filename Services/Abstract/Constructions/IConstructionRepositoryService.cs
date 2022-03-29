namespace Services.Abstract.Constructions;

public interface IConstructionRepositoryService
{
    Task<List<Construction>?> GetConstructionListAsync();
    Task CreateAsync(Construction construction);
    Task UpdateAsync(Construction construction);
    Task DeleteAsync(int constructionId);
}