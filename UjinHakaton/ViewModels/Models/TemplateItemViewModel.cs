using Avalonia.Media.Imaging;
using UjinTemplateServer.Models;

namespace UjinHakaton.ViewModels.Models
{
    public class TemplateItemViewModel
    {
        public Template Template { get; set; } = null!;
        public Bitmap? Preview { get; set; }
    }
}
