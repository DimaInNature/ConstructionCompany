namespace Services.Abstract.Products;

public interface IProductRepositoryService
{
    Task<List<Product>?> GetProductListAsync();
    Task CreateAsync(Product product);
    Task DeleteAsync(int productId);
}