using System.ComponentModel.DataAnnotations;

namespace UjinTemplateServer
{
    public class Templates
    {
        [Key]
        public int Id { get; set; }
        public string? Image { get; set; }
    }
}
