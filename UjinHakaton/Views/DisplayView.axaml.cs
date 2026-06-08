using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace UjinHakaton.Views;

public partial class DisplayView : UserControl
{
    public DisplayView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}