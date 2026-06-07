using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using UjinHakaton.Services;
using UjinHakaton.ViewModels.Models;
using UjinTemplateServer.Models;

namespace UjinHakaton.ViewModels
{
    public partial class TemplateViewModel(ScreenService screenService) : ViewModelBase
    {
        private readonly ScreenService _screenService = screenService;
        [ObservableProperty]
        private ScreenDto? selectedScreen;

        [ObservableProperty]
        private TemplateItemViewModel? selectedTemplate;

        [ObservableProperty]
        private ObservableCollection<TemplateItemViewModel> templates = [];

        partial void OnSelectedScreenChanged(ScreenDto? value)
        {
            _ = LoadTemplatesAsync();
        }

        private async Task LoadTemplatesAsync()
        {
            var result = await _screenService.GetTemplatesAsync();

            if (result is null)
                return;

            var items = new ObservableCollection<TemplateItemViewModel>();

            foreach (var template in result)
            {
                Bitmap? bitmap = null;

                if (!string.IsNullOrWhiteSpace(template.Image))
                {
                    bitmap = await _screenService.LoadBitmapAsync(template.Image);
                }

                items.Add(new TemplateItemViewModel
                {
                    Template = template,
                    Preview = bitmap
                });
            }

            Templates = items;

            SelectedTemplate = Templates.FirstOrDefault(x => x.Template.Id == SelectedScreen?.TemplateId) ?? Templates.FirstOrDefault();
        }

        [RelayCommand]
        private async Task SaveTemplateAsync()
        {
            if (SelectedScreen is null || SelectedTemplate is null)
                return;

            await _screenService.SetTemplateAsync(SelectedScreen.Id, SelectedTemplate.Template.Id);
        }
    }
}
