using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using UjinHakaton.Services;

namespace UjinHakaton.ViewModels
{
    public partial class AuthorisationViewModel(NavigationService navigationService, IServiceProvider provider) : ViewModelBase
    {
        private readonly IServiceProvider _provider = provider;
        private readonly NavigationService _navigationService = navigationService;
        [ObservableProperty]
        public required string _login;

        [ObservableProperty]
        public required string _password;

        [ObservableProperty]
        private string? _errorMessage;

        [ObservableProperty]
        private bool _isErrorVisible;

        [RelayCommand]
        private async Task Authorise()
        {
            if (Login == "admin" && Password == "admin")
            {
                IsErrorVisible = false;

                if (OperatingSystem.IsBrowser())
                {
                    //await JSHost.ImportAsync("Storage", "./storage.js");
                    //try
                    //{
                    //    BrowserStorage.SetItem("IsAuthenticated", "true");
                    //}
                    //catch (Exception ex)
                    //{
                    //    Console.WriteLine(ex.ToString());
                    //}
                }

                _navigationService.Navigate(ActivatorUtilities.CreateInstance<DisplayViewModel>(_provider));
            }
            else
            {
                ErrorMessage = "Неверный логин или пароль";
                IsErrorVisible = true;
            }
        }
    }
}