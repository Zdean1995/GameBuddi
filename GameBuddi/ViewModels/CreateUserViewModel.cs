﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameBuddi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBuddi.ViewModels
{
    public partial class CreateUserViewModel : ObservableObject
    {

        [ObservableProperty]
        string usernameText = "";
        [ObservableProperty]
        string emailText = "";
        [ObservableProperty]
        string passwordText = "";
        [ObservableProperty]
        string confirmPasswordText = "";

        [ObservableProperty]
        bool error = false;

        public CreateUserViewModel() { }

        [RelayCommand]
        async Task CreateUser()
        {
            if(PasswordText == ConfirmPasswordText)
            {
                await GameBuddiAPIManager.AddUser(UsernameText, EmailText, PasswordText);
                await Shell.Current.GoToAsync($"..");
            }
            else
            {
                Error = true;
            }
        }
    }
}
