namespace GameBuddi.ViewModels;

public partial class GamesViewModel : BaseViewModel
{

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    ObservableCollection<Game> items;

    public GamesViewModel()
    {
       
    }

    [RelayCommand]
    private async void OnRefreshing()
    {
        IsRefreshing = true;

        try
        {
            await LoadDataAsync();
        }
        finally
        {
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    public async Task LoadMore()
    {
    }

    public async Task LoadDataAsync()
    {
        
    }

    [RelayCommand]
    private async void GoToDetails(Game item)
    {
        
    }
}
