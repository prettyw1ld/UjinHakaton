using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UjinHakaton.Services;
using UjinTemplateServer.Models;

namespace UjinHakaton.ViewModels
{
    public partial class DisplayViewModel : ViewModelBase
    {

        private readonly ScreenService _screenService;
        public DisplayViewModel(ScreenService screenService)
        {
            _screenService = screenService;
            _ = LoadAsync();

        }
        [ObservableProperty]
        private string? _selectedTV;

        [ObservableProperty]
        private string? _errorMessage;

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
        public async Task ConfirmScreen(ScreenDto screen)
        {
            await _screenService.ConfirmScreenAsync(screen);

            await LoadAsync();
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
                if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                {
                    var app = (App)Application.Current!;
                    var vm = app.Services.GetRequiredService<TemplateViewModel>();

                    vm.SelectedScreen = SelectedScreen;

                    var oldWindow = desktop.MainWindow;

                    var templateWindow = new TemplatesView
                    {
                        DataContext = vm
                    };

                    desktop.MainWindow = templateWindow;
                    templateWindow.Show();

                    oldWindow?.Close();
                }
            }
        }
    }
}