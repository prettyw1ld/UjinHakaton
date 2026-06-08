using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace UjinHakaton.Views;

public partial class AuthorisationView : UserControl
{
    public AuthorisationView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}