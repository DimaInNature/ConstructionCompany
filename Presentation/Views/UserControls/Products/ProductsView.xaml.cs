namespace Presentation.Views.UserControls.Products;

public partial class ProductsView : UserControl
{
    private readonly IProductsViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IProductsViewModel>();

    public ProductsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}