namespace Presentation.ViewModels.UserControls.Clients;

internal class CreateClientsViewModel
    : BaseCreateViewModel, ICreateClientsViewModel
{
    #region Members

    #region Properties

    public string Name
    {
        get => _name ?? string.Empty;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public string Surname
    {
        get => _surname ?? string.Empty;
        set
        {
            _surname = value;
            OnPropertyChanged(nameof(Surname));
        }
    }

    public string Patronymic
    {
        get => _patronymic ?? string.Empty;
        set
        {
            _patronymic = value;
            OnPropertyChanged(nameof(Patronymic));
        }
    }

    public string Phone
    {
        get => _phone ?? string.Empty;
        set
        {
            _phone = value;
            OnPropertyChanged(nameof(Phone));
        }
    }

    #endregion

    #region Private

    private string? _name;

    private string? _surname;

    private string? _patronymic;

    private string? _phone;

    #endregion

    #region Dependencies

    private readonly IClientFacadeService _clientService;

    #endregion

    #endregion

    public CreateClientsViewModel(IClientFacadeService clientService)
    {
        _clientService = clientService;

        InitializeCommands();
    }

    #region Command Logic

    protected override bool CanExecuteCreate(object obj) =>
        StringHelper.StrIsNotNullOrWhiteSpace(Name, Surname, Patronymic, Phone);

    protected override async void ExecuteCreate(object obj)
    {
        Client client = new()
        {
            Name = Name,
            Surname = Surname,
            Patronymic = Patronymic,
            Phone = Phone
        };

        await _clientService.CreateAsync(client);

        MessageBox.Show(
            messageBoxText: "Добавление произошло успешно",
            caption: "Успех",
            button: MessageBoxButton.OK,
            icon: MessageBoxImage.Information);

        Clear();
    }

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        CreateCommand = new RelayCommand(executeAction: ExecuteCreate,
            canExecuteFunc: CanExecuteCreate);
    }

    private void Clear()
    {
        Name = string.Empty;
        Surname = string.Empty;
        Patronymic = string.Empty;
        Phone = string.Empty;
    }

    #endregion
}