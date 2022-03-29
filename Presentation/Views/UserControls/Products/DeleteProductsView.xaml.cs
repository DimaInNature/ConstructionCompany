namespace Presentation.Views.UserControls.Products;

public partial class DeleteProductsView : UserControl
{
    private readonly IDeleteProductsViewModel? _viewModel = (Application.Current as App)?
       .ServiceProvider?.GetService<IDeleteProductsViewModel>();

    public DeleteProductsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}