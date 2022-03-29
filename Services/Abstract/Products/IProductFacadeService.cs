namespace Services.Abstract.Products;

public interface IProductFacadeService
{
    Task<List<Product>> GetProductListAsync();
    Task CreateAsync(Product product);
    Task DeleteAsync(int productId);
}