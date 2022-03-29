namespace Presentation.Views.UserControls.Constructions;

public partial class ReadConstructionsView : UserControl
{
    private readonly IReadConstructionsViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IReadConstructionsViewModel>();

    public ReadConstructionsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}