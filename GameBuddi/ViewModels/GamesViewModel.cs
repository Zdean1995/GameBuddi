using CommunityToolkit.Mvvm.ComponentModel;
using GameBuddi.Services;
using IGDB;
using IGDB.Models;

namespace GameBuddi.ViewModels;

public partial class GamesViewModel : ObservableObject
{
    [ObservableProperty]
    Game[] games;

    int startCount = 0;

    private readonly Task initTask;

    public GamesViewModel(INavigation navigation)
    {
        initTask = InitAsync();
    }

    //https://www.damirscorner.com/blog/posts/20221021-AvoidAsyncCallsInViewmodelConstructors.html
    private async Task InitAsync()
    {
        Games = await IGDBManager.GetGames(startCount.ToString());
    }

    public async Task NextPage()
    {
        startCount += 100;
        Games = await IGDBManager.GetGames(startCount.ToString());

    }
    public async Task PrevPage()
    {
        startCount -= 100;
        Games = await IGDBManager.GetGames(startCount.ToString());

    }

    public async Task Search(string searchText)
    {
        Games = await IGDBManager.GetGamesSearch(searchText);
    }
}
