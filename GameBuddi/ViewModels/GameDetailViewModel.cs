using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameBuddi.Pages;
using GameBuddi.Services;
using IGDB;
using IGDB.Models;

namespace GameBuddi.ViewModels;

[QueryProperty(nameof(Game), nameof(Game))]
public partial class GameDetailViewModel : ObservableObject
{
    [ObservableProperty]
    Game game;

    [ObservableProperty]
    Cover cover;

    [ObservableProperty]
    InvolvedCompany[] companies;

    [ObservableProperty]
    List<Company> developers;

    [ObservableProperty]
    List<Company> publishers;

    [ObservableProperty]
    bool isLoading = true;
    [ObservableProperty]
    bool isLoaded = false;

    private readonly Task initTask;

    public GameDetailViewModel()
    {
        cover = new Cover();
        initTask = InitAsync();
        Loaded();
    }

    //https://www.damirscorner.com/blog/posts/20221021-AvoidAsyncCallsInViewmodelConstructors.html
    private async Task InitAsync()
    {
        Cover = await IGDBManager.GetCover((long)Game.Cover.Id);
        /*Companies = await IGDBManager.GetGamesCompanies(Game);

        foreach(var company in Companies)
        {
            if((bool)company.Publisher)
            {
                Publishers.Add(company.Company.Value);
            }
            if ((bool)company.Developer)
            {
                Developers.Add(company.Company.Value);
            }
        }*/
        Loaded();
    }

    [RelayCommand]
    async Task ViewCompany(Company company)
    {
        await Shell.Current.GoToAsync($"{nameof(CompanyDetailPage)}",
            new Dictionary<string, object>
            {
                    {nameof(Company), company}
            });
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

