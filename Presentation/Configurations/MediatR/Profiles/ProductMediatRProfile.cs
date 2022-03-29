namespace Presentation.Configurations.MediatR.Profiles;

internal static class ProductMediatRProfile
{
    public static void AddProductMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get List<Product>

        services.AddScoped<IRequest<List<Product>?>, GetProductListQuery>();
        services.AddScoped<IRequestHandler<GetProductListQuery, List<Product>?>, GetProductListQueryHandler>();

        #endregion

        #region Commands

        // Create

        services.AddScoped<IRequest, CreateProductCommand>();
        services.AddScoped<IRequestHandler<CreateProductCommand, Unit>, CreateProductCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeleteProductCommand>();
        services.AddScoped<IRequestHandler<DeleteProductCommand, Unit>, DeleteProductCommandHandler>();

        #endregion
    }
}