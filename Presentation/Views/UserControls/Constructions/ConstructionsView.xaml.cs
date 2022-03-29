namespace Presentation.Views.UserControls.Constructions;

public partial class ConstructionsView : UserControl
{
    private readonly IConstructionsViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IConstructionsViewModel>();

    public ConstructionsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}