using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using UjinHakaton.ViewModels;
using UjinHakaton.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System;
using UjinHakaton.Interfaces;
using UjinHakaton.Service;

namespace UjinHakaton;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
    private IServiceProvider? _services;

    public override void OnFrameworkInitializationCompleted()
    {
        var collection = new ServiceCollection();

        collection.AddSingleton(new HttpClient
        {
            BaseAddress = new Uri("https://api-uae-test.ujin.tech")
        });

        collection.AddTransient<INewsService, NewsService>();
        collection.AddTransient<MainViewModel>();

        _services = collection.BuildServiceProvider();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is IActivityApplicationLifetime singleViewFactoryApplicationLifetime)
        {
            singleViewFactoryApplicationLifetime.MainViewFactory = () => new MainView { DataContext = new MainViewModel() };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }


        base.OnFrameworkInitializationCompleted();
    }
}