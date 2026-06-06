using System;
using System.Collections.Generic;
using System.Text;

namespace UjinHakaton.Models
{
    public class Screens
    {
        public Guid Id { get; set; }
        public string DeviceCode { get; set; } = string.Empty;
        public bool? IsAproved { get; set; } = null;
        public int? BuildingId { get; set; } = null;
        public int? TemplateId { get; set; }

    }
}
