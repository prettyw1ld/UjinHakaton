using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace UjinHakaton.ViewModels
{
    public partial class DisplayViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? _selectedTV;

        [ObservableProperty]
        private string _errorMessage;

        [ObservableProperty]
        private bool _isErrorVisible;

        public ObservableCollection<string> TV { get; } = new()
        {
            "DEXP OLED 55\" - 1920x1080 (Full HD)",
            "DEXP OLED 55\" - 1920x1080 (Full HD)",
            "DEXP OLED 55\" - 1920x1080 (Full HD)",
            "DEXP OLED 55\" - 1920x1080 (Full HD)",
            "DEXP OLED 55\" - 1920x1080 (Full HD)",
            "DEXP OLED 55\" - 1920x1080 (Full HD)",
            "DEXP OLED 55\" - 1920x1080 (Full HD)"
        };

        [RelayCommand]
        private void ChooseTV()
        {
            if (SelectedTV == null)
            {
                ErrorMessage = "Выберите телевизор!";
                IsErrorVisible = true;
            }
            else
            {
                IsErrorVisible = false;
                if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                {
                    var templateWindow = new TemplatesView();
                    templateWindow.Show();

                    desktop.MainWindow.Close();
                }
            }
        }
    }
}
