using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameBuddi.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBuddi.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [RelayCommand]
        async Task Login()
        {
            await Shell.Current.GoToAsync($"{nameof(GamesPage)}");
        }

        [RelayCommand]
        async Task CreateAccount()
        {
            await Shell.Current.GoToAsync($"{nameof(CreateUserPage)}");
        }
    }
}