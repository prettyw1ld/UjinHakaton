using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjinTemplateServer
{
    public class Screen
    {
        [Key]
        public Guid Id { get; set; }
        public string? DeviceName { get; set; } = null!;
        public int? BuildingId { get; set; }
        public bool? IsApproved { get; set; }
    }

    [NotMapped]
    public record ScreenDto(Guid Id, string DeviceName, int BuildingId, bool IsApproved);
}
