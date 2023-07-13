using CommunityToolkit.Mvvm.ComponentModel;

namespace GameBuddi.Viewmodels;

[QueryProperty(nameof(Item), "Item")]
public partial class GamesDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    Game item;
}
