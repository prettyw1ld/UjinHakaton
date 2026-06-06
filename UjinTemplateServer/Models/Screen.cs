using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjinTemplateServer.Models
{
    public class Screen
    {
        [Key]
        public Guid Id { get; set; }
        public string DeviceCode { get; set; } = string.Empty;
        public bool? IsApproved { get; set; } = null;
        public int? BuildingId { get; set; } = null;
        public int? TemplateId { get; set; }

        [ForeignKey(nameof(TemplateId))]
        public Template? Template { get; set; }
    }

    [NotMapped]
    public record ScreenDtoFromClient(Guid Id);
    [NotMapped]
    public record ScreenDtoFromServer(Guid Id, string DeviceCode, int BuildingId, bool IsApproved);
    [NotMapped]
    public record ScreenDtoTo(Guid Id, string DeviceCode, int? BuildingId, bool? IsApproved, int? TemplateId);
}
