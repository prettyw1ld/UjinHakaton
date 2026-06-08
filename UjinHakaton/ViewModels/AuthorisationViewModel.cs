using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using UjinHakaton.Services;
using UjinHakaton.Views;

namespace UjinHakaton.ViewModels
{
    public partial class AuthorisationViewModel : ViewModelBase
    {
        private readonly ShellViewModel _shell;
        public ViewModelBase CurrentViewModel { get; set; }
        public AuthorisationViewModel(ShellViewModel shell)
        {
            _shell = shell;
        }
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
                var app = (App)Application.Current!;
                _shell.CurrentViewModel =
                        new DisplayViewModel(app.Services.GetRequiredService<ScreenService>());
            }
            else
            {
                ErrorMessage = "Неверный логин или пароль";
                IsErrorVisible = true;
            }
        }
    }
}