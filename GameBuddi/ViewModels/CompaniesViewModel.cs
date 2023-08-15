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
        initTask = InitAsync();
    }

    private async Task InitAsync()
    {
        Companies = await IGDBManager.GetCompanies(startCount.ToString());
    }

    public async Task NextPage()
    {
        startCount += 25;
        Companies = await IGDBManager.GetCompanies(startCount.ToString());

    }
    public async Task PrevPage()
    {
        if (startCount != 0)
        {
            startCount -= 25;
            Companies = await IGDBManager.GetCompanies(startCount.ToString());
        }
    }

}
