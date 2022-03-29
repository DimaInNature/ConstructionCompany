namespace Presentation.Views.UserControls.Constructions;

public partial class CreateConstructionsView : UserControl
{
    private readonly ICreateConstructionsViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<ICreateConstructionsViewModel>();

    public CreateConstructionsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}