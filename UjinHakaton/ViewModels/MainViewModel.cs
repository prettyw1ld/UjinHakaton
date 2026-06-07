using CommunityToolkit.Mvvm.ComponentModel;

namespace UjinHakaton.ViewModels;

public partial class MainViewModel() : ViewModelBase
{
   
    [ObservableProperty]
    private string _greeting = "Welcome to Hakaton2026 хехе!";


}
