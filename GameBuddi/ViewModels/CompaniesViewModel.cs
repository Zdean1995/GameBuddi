using CommunityToolkit.Mvvm.ComponentModel;
using GameBuddi.Services;
using IGDB;
using IGDB.Models;

namespace GameBuddi.ViewModels;

public partial class CompaniesViewModel : ObservableObject
{
    [ObservableProperty]
    Company[] companies;

    int startCount = 0;

    private readonly Task initTask;

    public CompaniesViewModel()
    {
        this.initTask = InitAsync();
    }

    private async Task InitAsync()
    {
        Companies = await IGDBManager.GetCompanies(startCount.ToString());
    }

    public async Task NextPage()
    {
        startCount += 100;
        Companies = await IGDBManager.GetCompanies(startCount.ToString());

    }
    public async Task PrevPage()
    {
        startCount += 100;
        Companies = await IGDBManager.GetCompanies(startCount.ToString());

    }

}
