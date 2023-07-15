using CommunityToolkit.Mvvm.ComponentModel;
using IGDB;
using IGDB.Models;

namespace GameBuddi.ViewModels;

[QueryProperty("Game", "Game")]
public partial class GameDetailViewModel : ObservableObject
{
    [ObservableProperty]
    Game game;
}

