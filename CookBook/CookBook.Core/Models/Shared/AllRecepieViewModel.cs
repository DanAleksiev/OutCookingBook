using CookBook.Core.Contracts;

namespace CookBook.Core.Models.Shared
    {
    public class AllRecepieViewModel : IRecepie
        {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DatePosted { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
        public int TumbsUp { get; set; }
        public string Description { get; set; } = string.Empty;


        public bool Private { get; set; }
        public bool Like { get; set; }
        public bool Favourite { get; set; }

        }
    }
