using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using UjinHakaton.Views;

namespace UjinHakaton;

public partial class AuthorisationView : Window
{
    public AuthorisationView()
    {
        InitializeComponent();
    }

    private void Authorise(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var logintb = login.Text;
        var passwordtb = password.Text;

        if (logintb == "admin" && passwordtb == "admin")
        {
            
        }
    }
}