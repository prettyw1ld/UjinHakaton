using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;



namespace UjinHakaton.Services
{
    [SupportedOSPlatform("browser")]
    public static partial class BrowserStorage
    {
      
        [JSImport("setItem", "Storage")]
        internal static partial void SetItem(string key, string value);

        [JSImport("getItem", "Storage")]
        internal static partial string? GetItem(string key);
    }
}
    