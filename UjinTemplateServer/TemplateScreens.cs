using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjinTemplateServer
{
    public class TemplateScreens
    {
        [Key]
        public int Id { get; set; }
        public int? CurrentTemplateId { get; set; }
    }
}
