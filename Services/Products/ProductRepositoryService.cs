namespace Services.Products;

public class ProductRepositoryService : IProductRepositoryService
{
    private readonly IMediator _mediator;

    public ProductRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<Product>?> GetProductListAsync() =>
        await _mediator.Send(request: new GetProductListQuery());

    public async Task CreateAsync(Product product) =>
        await _mediator.Send(request: new CreateProductCommand(product: product));

    public async Task DeleteAsync(int productId) =>
        await _mediator.Send(request: new DeleteProductCommand(id: productId));
}