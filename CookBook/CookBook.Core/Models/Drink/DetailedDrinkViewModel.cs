using CookBook.Core.Contracts;
using CookBook.Infrastructures.Data.Models.Shared;

namespace CookBook.Core.Models.Drink

    {
    public class DetailedDrinkViewModel : IRecepie
        {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DatePosted { get; set; }
        public string Image { get; set; } = null!;
        public string Origen { get; set; } = null!;
        public bool IsAlcoholic { get; set; }
        public int Cups { get; set; }
        public int TumbsUp { get; set; }
        public string Owner { get; set; } = null!;
        public string OwnerId { get; set; } = null!;

        public bool Like { get; set; }
        public bool Favourite { get; set; }
        public bool Private { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public ICollection<Step> Steps { get; set; } = new List<Step>();
        }
    }
