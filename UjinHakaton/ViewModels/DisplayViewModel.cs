using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using UjinHakaton.Services;
using UjinTemplateServer.Models;

namespace UjinHakaton.ViewModels
{
    public partial class DisplayViewModel : ObservableObject
    {

        private readonly ScreenService _screenService;
        public DisplayViewModel(ScreenService screenService)
        {
            _screenService = screenService;
            LoadAsync();

        }
        [ObservableProperty]
        private string? _selectedTV;

        [ObservableProperty]
        private string _errorMessage;

        [ObservableProperty]
        private bool _isErrorVisible;
        [ObservableProperty]
        private ScreenDto? selectedScreen;
        [ObservableProperty]
        private ObservableCollection<ScreenDto> screens = [];
        
        public async Task LoadAsync()
        {
            var result = await _screenService.GetScreensAsync();

            if (result != null)
            {
                Screens = new ObservableCollection<ScreenDto>(result);
            }
        }

        [RelayCommand]
        private void ChooseTV()
        {
            if (SelectedScreen == null)
            {
                ErrorMessage = "Выберите телевизор!";
                IsErrorVisible = true;
            }
            else
            {
                IsErrorVisible = false;
                if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                {
                    var app = (App)Application.Current!;
                    var vm = app.Services.GetRequiredService<TemplateViewModel>();

                    vm.SelectedScreen = SelectedScreen;

                    var templateWindow = new TemplatesView
                    {
                        DataContext = vm
                    };

                    templateWindow.Show();

                    desktop.MainWindow.Close();
                }
            }
        }
    }
}