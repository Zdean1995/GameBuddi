using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiAppGT.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class GamesDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    SampleItem item;
}
