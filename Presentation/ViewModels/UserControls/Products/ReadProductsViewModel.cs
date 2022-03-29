namespace Presentation.ViewModels.UserControls.Products;

internal class ReadProductsViewModel
    : BaseReadViewModel<Product>, IReadProductsViewModel
{
    private readonly IProductFacadeService _productService;

    public ReadProductsViewModel(IProductFacadeService productService)
    {
        _productService = productService;

        Task.Run(InitializeData);
    }

    private async Task InitializeData()
    {
        Items = await _productService.GetProductListAsync();
    }
}