using System;
using System.Collections.Generic;

#nullable disable

namespace Catalog.Models
{
    public partial class Food
    {
        public Guid Id { get; set; }
        public Guid FoodCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? ExpectedCookingTime { get; set; }
        public decimal? Price { get; set; }
    }
}
