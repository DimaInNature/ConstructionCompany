namespace Features.Products.Queries;

public class GetProductListQueryHandler
    : IRequestHandler<GetProductListQuery, List<Product>?>
{
    private readonly ApplicationContext _context;

    public GetProductListQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<Product>?> Handle(GetProductListQuery request, CancellationToken token) =>
        await _context.Products.ToListAsync(token);
}