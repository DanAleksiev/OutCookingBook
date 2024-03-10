using CookBook.Infrastructures.Data.Models.Shared;

namespace CookBook.Core.Models.Food
    {
    public class DetailedFoodViewModel
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DatePosted { get; set; }
        public string Image { get; set; }
        public int PrepTime { get; set; }
        public int Temperature { get; set; }
        public int CookTime { get; set; }
        public string Origen { get; set; }
        public int Portions { get; set; }
        public int TumbsUp { get; set; }
        public string RecepieType { get; set; }
        public string TemperatureType { get; set; }
        public string OvenType { get; set; }
        public string Owner { get; set; }
        public string OwnerId { get; set; }

        public bool Like { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public ICollection<FoodStep> Steps { get; set; } = new List<FoodStep>();
        }
    }
