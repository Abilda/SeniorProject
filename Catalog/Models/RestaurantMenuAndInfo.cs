using System.Collections.Generic;

namespace Catalog.Models
{
    public class RestaurantMenuAndInfo
    {
        public Restaurant RestaurantInfo { get; set; }
        public Dictionary<string, List<Food>> MenuByFoodCategory { get; set; }
        
        public List<string> CuisineTypes { get; set; }
        public double Rating { get; set; }
    }
}
