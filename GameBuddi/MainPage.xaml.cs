using GameBuddi.Pages;
using GameBuddi.ViewModels;

namespace GameBuddi;

public partial class MainPage : ContentPage
{
    public MainPage(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}

