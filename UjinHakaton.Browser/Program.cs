using Avalonia;
using Avalonia.Browser;
using System.Threading.Tasks;
using UjinHakaton;

internal sealed partial class Program
{

    private static Task Main(string[] args) => BuildAvaloniaApp()
            .WithInterFont()
            .WithDeveloperTools()
            .StartBrowserAppAsync("out");


    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>();
}