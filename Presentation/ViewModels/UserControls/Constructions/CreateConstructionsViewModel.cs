namespace Presentation.ViewModels.UserControls.Constructions;

internal class CreateConstructionsViewModel
    : BaseCreateViewModel, ICreateConstructionsViewModel
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

    public string Status
    {
        get => _status ?? string.Empty;
        set
        {
            _status = value;
            OnPropertyChanged(nameof(Status));
        }
    }

    public string Address
    {
        get => _address ?? string.Empty;
        set
        {
            _address = value;
            OnPropertyChanged(nameof(Address));
        }
    }

    public DateTime? EndDate
    {
        get => _endDate;
        set
        {
            _endDate = value;
            OnPropertyChanged(nameof(EndDate));
        }
    }

    public List<Client> Items
    {
        get => _items;
        set
        {
            if (value is not null)
                _items = value;

            OnPropertyChanged(nameof(Items));
        }
    }

    public Client? SelectedItem
    {
        get => _selectedItem;
        set
        {
            // If the object has not been selected yet

            if (_lastItemId is null)
            {
                _selectedItem = value;

                OnPropertyChanged(nameof(SelectedItem));

                if (_selectedItem is null) return;

                _lastItemId = _selectedItem.Id;
            }

            // if the object was selected and the data was updated

            else if (_selectedItem is null)
            {
                _selectedItem = _items.Find(food => food.Id == _lastItemId);

                OnPropertyChanged(nameof(SelectedItem));
            }

            // Allow the selection of another object
            // if the data has not been updated yet

            else if (value is not null)
            {
                _selectedItem = value;

                OnPropertyChanged(nameof(SelectedItem));
            }
        }
    }

    #endregion

    #region Private

    private string? _name;

    private string? _status;

    private string? _address;

    private DateTime? _endDate;

    private List<Client> _items = new();

    private Client? _selectedItem;

    private int? _lastItemId;

    #endregion

    #region Dependencies

    private readonly IConstructionFacadeService _constructionService;
    private readonly IClientFacadeService _clientService;

    #endregion

    #endregion

    public CreateConstructionsViewModel(IClientFacadeService clientService,
        IConstructionFacadeService constructionService)
    {
        _clientService = clientService;
        _constructionService = constructionService;

        InitializeCommands();

        Task.Run(InitializeData);
    }

    #region Command Logic

    protected override bool CanExecuteCreate(object obj) =>
        StringHelper.StrIsNotNullOrWhiteSpace(Name, Status, Address) && SelectedItem is not null;

    protected override async void ExecuteCreate(object obj)
    {
        if (SelectedItem is null) return;

        Construction construction = new()
        {
            Name = Name,
            Status = Status,
            Address = Address,
            EndDate = EndDate,
            ClientId = SelectedItem.Id
        };

        await _constructionService.CreateAsync(construction);

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

    private async Task InitializeData()
    {
        Items = await _clientService.GetClientListAsync();
    }

    private void Clear()
    {
        Name = string.Empty;
        Status = string.Empty;
        Address = string.Empty;

        _selectedItem = null;
        OnPropertyChanged(nameof(SelectedItem));
    }

    #endregion
}