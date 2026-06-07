using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UjinHakaton.Views;

namespace UjinHakaton.ViewModels
{
    public partial class AuthorisationViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _login;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private string _errorMessage;

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

                    var mainWindow = new MainView
                    {
                        DataContext = app.Services.GetRequiredService<DisplayViewModel>()
                    };

                    mainWindow.Show();

                    desktop.MainWindow.Close();
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