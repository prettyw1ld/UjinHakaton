using System.ComponentModel.DataAnnotations;

namespace UjinTemplateServer.Models
{
    public class Complex
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public ICollection<Building> Buildings { get; set; } = [];
    }
}
