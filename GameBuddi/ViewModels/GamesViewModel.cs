using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameBuddi.Pages;
using GameBuddi.Services;
using IGDB;
using IGDB.Models;

namespace GameBuddi.ViewModels;

public partial class GamesViewModel : ObservableObject
{
    [ObservableProperty]
    Game[] games;

    //A boolean used for telling the ui that the data is still loading
    [ObservableProperty]
    bool isLoading = true;
    [ObservableProperty]
    bool isLoaded = false;
    [ObservableProperty]
    bool gamesEmpty = false;
    [ObservableProperty]
    string searchingText = "";

    int startCount = 0;

    [ObservableProperty]
    int currentPage = 1;

    private readonly Task initTask;

    public GamesViewModel()
    {
        initTask = InitAsync();
    }

    //https://www.damirscorner.com/blog/posts/20221021-AvoidAsyncCallsInViewmodelConstructors.html
    private async Task InitAsync()
    {
        Games = await IGDBManager.GetGames(startCount.ToString());
        GamesCheck();
        Loaded();
    }

    [RelayCommand]
    public async Task NextPage()
    {
        Loading();
        startCount += 25;
        CurrentPage++;
        Games = await IGDBManager.GetGames(25.ToString());
        GamesCheck();
        Loaded();
    }

    [RelayCommand]
    public async Task PrevPage()
    {
        Loading();
        if (startCount != 0)
        {
            startCount -= 25;
            CurrentPage--;
            Games = await IGDBManager.GetGames(startCount.ToString());
        }
        Loaded();
    }

    [RelayCommand]
    public async Task Search()
    {
        Loading();
        if (SearchingText != "") 
        { 
            Games = await IGDBManager.GetGamesSearch(SearchingText); 
        }
        GamesCheck();
        Loaded();
    }

    [RelayCommand]
    async Task GameDetails(Game game)
    {
        await Shell.Current.GoToAsync($"{nameof(GamesDetailPage)}",
            new Dictionary<string, object>
            {
                    {nameof(Game), game}
            });
    }

    [RelayCommand]
    async Task CompanyPage()
    {
        await Shell.Current.GoToAsync($"{nameof(CompanyPage)}");
    }

    void GamesCheck()
    {
        if (Games.Length == 0)
        {
            GamesEmpty = true;
        }
        else
        {
            GamesEmpty = false;
        }
    }

    void Loading()
    {
        IsLoading = true;
        IsLoaded = false;
    }
    void Loaded()
    {
        IsLoading = false;
        IsLoaded = true;
    }
}
