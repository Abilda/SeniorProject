using System;
using System.Collections.Generic;

#nullable disable

namespace Catalog.Models
{
    public partial class RestaurantsAndCuisineType
    {
        public Guid RestaurantId { get; set; }
        public Guid CuisineTypeId { get; set; }
        public Guid Id { get; set; }
    }
}
