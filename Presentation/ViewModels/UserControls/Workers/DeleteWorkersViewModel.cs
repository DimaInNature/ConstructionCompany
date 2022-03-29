namespace Presentation.ViewModels.UserControls.Workers;

internal class DeleteWorkersViewModel
    : BaseDeleteViewModel<Worker>, IDeleteWorkersViewModel
{
    private readonly IWorkerFacadeService _workerService;

    public DeleteWorkersViewModel(IWorkerFacadeService workerService)
    {
        _workerService = workerService;

        InitializeCommands();

        Task.Run(InitializeData);
    }

    #region Command Logic

    #region Can Execute

    protected override bool CanExecuteDeleteCommand(object obj) =>
        SelectedItem is not null;

    #endregion

    #region Execute

    protected override async void ExecuteDeleteCommand(object obj)
    {
        if (SelectedItem is null) return;

        await _workerService.DeleteAsync(SelectedItem.Id);

        MessageBox.Show(
           messageBoxText: "Удаление произошло успешно",
           caption: "Успех",
           button: MessageBoxButton.OK,
           icon: MessageBoxImage.Information);

        await InitializeData();

        Clear();
    }

    #endregion

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        DeleteCommand = new RelayCommand(executeAction: ExecuteDeleteCommand,
            canExecuteFunc: CanExecuteDeleteCommand);
    }

    private void Clear()
    {
        _selectedItem = null;
        OnPropertyChanged(nameof(SelectedItem));

        _lastItemId = null;
    }

    private async Task InitializeData()
    {
        Items = await _workerService.GetWorkerListAsync();
    }

    #endregion
}