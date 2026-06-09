using CommunityToolkit.Mvvm.ComponentModel;

namespace UjinHakaton.ViewModels
{
    public partial class ShellViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ViewModelBase? currentViewModel;
    }
}
