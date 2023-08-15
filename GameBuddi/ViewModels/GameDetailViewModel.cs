using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameBuddi.Pages;
using IGDB;
using IGDB.Models;

namespace GameBuddi.ViewModels;

[QueryProperty(nameof(Game), nameof(Game))]
public partial class GameDetailViewModel : ObservableObject
{
    [ObservableProperty]
    Game game;

    //This command navigates to the student page with a student that will be edited
    [RelayCommand]
    async Task ViewCompany(Company company)
    {
        await Shell.Current.GoToAsync($"{nameof(CompanyDetailPage)}",
            new Dictionary<string, object>
            {
                    {nameof(Company), company}
            });
    }
}

