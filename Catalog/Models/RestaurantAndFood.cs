using System;
using System.Collections.Generic;

#nullable disable

namespace Catalog.Models
{
    public partial class RestaurantAndFood
    {
        public Guid? RestaurantId { get; set; }
        public Guid? FoodId { get; set; }
        public Guid Id { get; set; }
    }
}
