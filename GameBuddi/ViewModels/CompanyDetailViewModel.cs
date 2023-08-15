using CommunityToolkit.Mvvm.ComponentModel;
using IGDB;
using IGDB.Models;

namespace GameBuddi.ViewModels;

[QueryProperty(nameof(Company), nameof(Company))]
public partial class CompanyDetailViewModel : ObservableObject
{
    [ObservableProperty]
    Company company;
}

