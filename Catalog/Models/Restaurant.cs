using System;
using System.Collections.Generic;

#nullable disable

namespace Catalog.Models
{
    public partial class Restaurant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string? WorkingStartTime { get; set; }
        public string? WorkingEndTime { get; set; }
        public string PlaceQuality { get; set; }
    }
}
