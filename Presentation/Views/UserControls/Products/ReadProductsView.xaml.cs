namespace Presentation.Views.UserControls.Products;

public partial class ReadProductsView : UserControl
{
    private readonly IReadProductsViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IReadProductsViewModel>();

    public ReadProductsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}