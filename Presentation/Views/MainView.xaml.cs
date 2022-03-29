namespace Presentation.Views;

public partial class MainView : Window
{
    private readonly IMainViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IMainViewModel>();

    private readonly UserSessionService? _sessionService = (Application.Current as App)?
        .ServiceProvider?.GetService<UserSessionService>();

    public MainView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;

        if (_sessionService?.ActiveUser?.Role is not UserRole.Admin)
        {
            UsersMenuRadioButton.Visibility = Visibility.Collapsed;
            UsersButton.Visibility = Visibility.Collapsed;

            ClientsMenuRadioButton.Visibility = Visibility.Collapsed;
            ClientsButton.Visibility = Visibility.Collapsed;
        }
    }

    private void WindowDragMove(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }

    private void ConstructionsButton_Click(object sender, RoutedEventArgs e) =>
        (ConstructionsMenuRadioButton.IsChecked, Title) = (true, "Юг-Строй - Работы");

    private void UsersButton_Click(object sender, RoutedEventArgs e) =>
        (UsersMenuRadioButton.IsChecked, Title) = (true, "Юг-Строй - Пользователи");

    private void WorkersButton_Click(object sender, RoutedEventArgs e) =>
        (WorkersMenuRadioButton.IsChecked, Title) = (true, "Юг-Строй - Рабочие");

    private void ClientsButton_Click(object sender, RoutedEventArgs e) =>
        (ClientsMenuRadioButton.IsChecked, Title) = (true, "Юг-Строй - Клиенты");

    private void ProductsButton_Click(object sender, RoutedEventArgs e) =>
        (ProductsMenuRadioButton.IsChecked, Title) = (true, "Юг-Строй - Склад");

    private void ReportsButton_Click(object sender, RoutedEventArgs e) =>
        (ReportsMenuRadioButton.IsChecked, Title) = (true, "Юг-Строй - Склад");

    private void HomeMenuRadioButton_Click(object sender, RoutedEventArgs e) =>
        Title = "Юг-Строй - Главная";

    private void ConstructionsMenuRadioButton_Click(object sender, RoutedEventArgs e) =>
        Title = "Юг-Строй - Работы";

    private void UsersMenuRadioButton_Click(object sender, RoutedEventArgs e) =>
        Title = "Юг-Строй - Пользователи";

    private void WorkersMenuRadioButton_Click(object sender, RoutedEventArgs e) =>
        Title = "Юг-Строй - Рабочие";

    private void ClientsMenuRadioButton_Click(object sender, RoutedEventArgs e) =>
        Title = "Юг-Строй - Клиенты";

    private void ProductsMenuRadioButton_Click(object sender, RoutedEventArgs e) =>
        Title = "Юг-Строй - Склад";

    private void ReportsMenuRadioButton_Click(object sender, RoutedEventArgs e) =>
        Title = "Юг-Строй - Отчёт";

    private void LogoutMenuButton_Click(object sender, RoutedEventArgs e)
    {
        _sessionService?.EndSession();

        new LoginView().Show();

        Close();
    }

    private void CloseApplicationButton_Click(object sender, RoutedEventArgs e) =>
        Application.Current.Shutdown();
}