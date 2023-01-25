using Data.Models;

namespace FoodPlannerApi.DTO
{
    public class RecipeDTO
    {
        public string? Name { get; set; }
        public string? Howto { get; set; }
        public string? Picture { get; set; }
        public string? FinalProduct { get; set; }
        public List<Ingrediants> Ingrediants { get; set; }
    }
}
