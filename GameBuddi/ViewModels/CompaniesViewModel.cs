using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameBuddi.Pages;
using GameBuddi.Services;
using IGDB;
using IGDB.Models;

namespace GameBuddi.ViewModels;

public partial class CompaniesViewModel : ObservableObject
{
    [ObservableProperty]
    Company[] companies;

    //A boolean used for telling the ui that the data is still loading
    [ObservableProperty]
    bool isLoading = true;
    [ObservableProperty]
    bool isLoaded = false;
    [ObservableProperty]
    bool companiesEmpty = false;
    [ObservableProperty]
    string searchingText = "";

    int startCount = 0;

    [ObservableProperty]
    int currentPage = 1;

    private readonly Task initTask;

    public CompaniesViewModel()
    {
        initTask = InitAsync();
    }

    //https://www.damirscorner.com/blog/posts/20221021-AvoidAsyncCallsInViewmodelConstructors.html
    private async Task InitAsync()
    {
        Companies = await IGDBManager.GetCompanies(startCount.ToString());
        CompaniesCheck();
        Loaded();
    }

    [RelayCommand]
    public async Task NextPage()
    {
        Loading();
        startCount += 25;
        CurrentPage++;
        Companies = await IGDBManager.GetCompanies(25.ToString());
        CompaniesCheck();
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
            Companies = await IGDBManager.GetCompanies(startCount.ToString());
        }
        Loaded();
    }

    [RelayCommand]
    public async Task Search()
    {
        Loading();
        if (SearchingText != "")
        {
            Companies = await IGDBManager.GetCompaniesSearch(SearchingText);
        }
        CompaniesCheck();
        Loaded();
    }

    [RelayCommand]
    async Task GameDetails(Company company)
    {
        await Shell.Current.GoToAsync($"{nameof(CompanyDetailPage)}",
            new Dictionary<string, object>
            {
                    {nameof(Company), company}
            });
    }

    [RelayCommand]
    async Task GamePage()
    {
        await Shell.Current.GoToAsync($"{nameof(GamePage)}");
    }

    void CompaniesCheck()
    {
        if (Companies.Length == 0)
        {
            CompaniesEmpty = true;
        }
        else
        {
            CompaniesEmpty = false;
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
