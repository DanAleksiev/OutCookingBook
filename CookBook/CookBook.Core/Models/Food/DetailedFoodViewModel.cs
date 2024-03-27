using CookBook.Core.Contracts;
using CookBook.Infrastructures.Data.Models.Shared;

namespace CookBook.Core.Models.Food
{
    public class DetailedFoodViewModel : IRecepie
        {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DatePosted { get; set; }
        public string Image { get; set; } = string.Empty;
        public int PrepTime { get; set; }
        public int Temperature { get; set; }
        public int CookTime { get; set; }
        public string Origen { get; set; } = string.Empty;
        public int Portions { get; set; }
        public int TumbsUp { get; set; }
        public string RecepieType { get; set; } = string.Empty;
        public string TemperatureType { get; set; } = string.Empty;
        public string OvenType { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;

        public bool Like { get; set; }
        public bool Favourite { get; set; }
        public bool Private { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public ICollection<FoodStep> Steps { get; set; } = new List<FoodStep>();
        }
    }
