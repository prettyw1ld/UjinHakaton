using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UjinHakaton.Interfaces;
using UjinHakaton.Models.NewsModel;

namespace UjinHakaton.ViewModels;

public partial class MainViewModel(INewsService newsService) : ViewModelBase
{
    private readonly INewsService _newsService = newsService;

    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";

    public ObservableCollection<NewsItem> News { get; } = [];

    [RelayCommand]
    private async Task LoadNewsAsync()
    {
        var response = await _newsService.GetNewsAsync();

        News.Clear();

        if (response?.Error == 0 && response.Data?.Items is not null)
        {
            foreach (var item in response.Data.Items)
                News.Add(item);
        }
    }
}
