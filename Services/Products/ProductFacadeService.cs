namespace Services.Products;

public class ProductFacadeService : IProductFacadeService
{
    private readonly IProductRepositoryService _repository;

    public ProductFacadeService(IProductRepositoryService repository) =>
        _repository = repository;

    public async Task<List<Product>> GetProductListAsync() =>
        await _repository.GetProductListAsync() ?? new();

    public async Task CreateAsync(Product product)
    {
        if (product is null) return;

        await _repository.CreateAsync(product);
    }

    public async Task DeleteAsync(int productId)
    {
        if (productId < 1) return;

        await _repository.DeleteAsync(productId);
    }
}