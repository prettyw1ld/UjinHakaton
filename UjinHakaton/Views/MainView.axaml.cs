
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace UjinHakaton.Views;

public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}