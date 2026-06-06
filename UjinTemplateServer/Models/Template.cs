using System.ComponentModel.DataAnnotations;

namespace UjinTemplateServer.Models
{
    public class Template
    {
        [Key]
        public int Id { get; set; }
        public string? Image { get; set; }
    }
}
