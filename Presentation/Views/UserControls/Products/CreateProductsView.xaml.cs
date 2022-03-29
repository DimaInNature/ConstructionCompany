namespace Presentation.Views.UserControls.Products;

public partial class CreateProductsView : UserControl
{
    private readonly ICreateProductsViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<ICreateProductsViewModel>();

    public CreateProductsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}