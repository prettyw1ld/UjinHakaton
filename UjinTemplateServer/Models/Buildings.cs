using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjinTemplateServer.Models
{
    public class Building
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ComplexId { get; set; }
        public Complex Complex { get; set; } = null!;
        public ICollection<Screen> Screens { get; set; } = [];
    }
}
