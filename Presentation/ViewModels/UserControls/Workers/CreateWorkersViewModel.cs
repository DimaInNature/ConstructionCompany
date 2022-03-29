namespace Presentation.ViewModels.UserControls.Workers;

internal class CreateWorkersViewModel
    : BaseCreateViewModel, ICreateWorkersViewModel
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

    public string Specialization
    {
        get => _specialization ?? string.Empty;
        set
        {
            _specialization = value;
            OnPropertyChanged(nameof(Specialization));
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

    public List<Construction> Items
    {
        get => _items;
        set
        {
            if (value is not null)
                _items = value;

            OnPropertyChanged(nameof(Items));
        }
    }

    public Construction? SelectedItem
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

    private string? _surname;

    private string? _patronymic;

    private string? _specialization;

    private string? _phone;

    private List<Construction> _items = new();

    private Construction? _selectedItem;

    private int? _lastItemId;

    #endregion

    #region Dependencies

    private readonly IConstructionFacadeService _constructionService;
    private readonly IWorkerFacadeService _workerService;

    #endregion

    #endregion

    public CreateWorkersViewModel(IWorkerFacadeService workerService,
        IConstructionFacadeService constructionService)
    {
        _workerService = workerService;
        _constructionService = constructionService;

        InitializeCommands();

        Task.Run(InitializeData);
    }

    #region Command Logic

    protected override bool CanExecuteCreate(object obj) =>
        StringHelper.StrIsNotNullOrWhiteSpace(Name, Surname, Patronymic, Phone, Specialization)
        && SelectedItem is not null;

    protected override async void ExecuteCreate(object obj)
    {
        if (SelectedItem is null) return;

        Worker worker = new()
        {
            Name = Name,
            Surname = Surname,
            Patronymic = Patronymic,
            Specialization = Specialization,
            Phone = Phone,
            ConstructionId = SelectedItem.Id
        };

        await _workerService.CreateAsync(worker);

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
        Items = await _constructionService.GetConstructionListAsync();
    }

    private void Clear()
    {
        Name = string.Empty;
        Surname = string.Empty;
        Patronymic = string.Empty;

        _selectedItem = null;
        OnPropertyChanged(nameof(SelectedItem));
    }

    #endregion
}