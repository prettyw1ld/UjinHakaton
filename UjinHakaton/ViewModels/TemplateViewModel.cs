using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using UjinHakaton.Services;
using UjinTemplateServer.Models;

namespace UjinHakaton.ViewModels
{
    public partial class TemplateViewModel : ObservableObject
    {
        [ObservableProperty]
        private ScreenDto? selectedScreen;
    }
}
