using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using UjinHakaton.Services;
using UjinHakaton.ViewModels;
using UjinHakaton.Views;


namespace UjinHakaton;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
    private IServiceProvider? _services;
    public IServiceProvider Services => _services!;
    public override void OnFrameworkInitializationCompleted()
    {
        var collection = new ServiceCollection();


        collection.AddSingleton(new HttpClient
        {
            BaseAddress = new Uri("https://api-uae-test.ujin.tech")
        });

        collection.AddSingleton<ScreenService>();

        collection.AddSingleton<HttpClient>();
        collection.AddTransient<DisplayViewModel>();
        collection.AddTransient<TemplateViewModel>();
        collection.AddTransient<AuthorisationViewModel>();

        _services = collection.BuildServiceProvider();

        if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = _services.GetRequiredService<MainViewModel>()
            };
        }

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new AuthorisationView
            {
                DataContext = _services.GetRequiredService<AuthorisationViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}