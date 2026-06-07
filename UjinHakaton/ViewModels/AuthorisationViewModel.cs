using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using UjinHakaton.Views;

namespace UjinHakaton.ViewModels
{
    public partial class AuthorisationViewModel : ViewModelBase
    {
        [ObservableProperty]
        public required string _login;

        [ObservableProperty]
        public required string _password;

        [ObservableProperty]
        private string? _errorMessage;

        [ObservableProperty]
        private bool _isErrorVisible;

        [RelayCommand]
        private void Authorise()
        {
            if (Login == "admin" && Password == "admin")
            {
                IsErrorVisible = false;

                if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                {
                    var app = (App)Application.Current!;

                    var oldWindow = desktop.MainWindow;

                    var mainWindow = new MainView
                    {
                        DataContext = app.Services.GetRequiredService<DisplayViewModel>()
                    };

                    desktop.MainWindow = mainWindow;
                    mainWindow.Show();

                    oldWindow?.Close();
                }
            }
            else
            {
                ErrorMessage = "Неверный логин или пароль";
                IsErrorVisible = true;
            }
        }
    }
}