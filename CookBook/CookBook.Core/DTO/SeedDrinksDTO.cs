namespace CookBook.Core.DTO
    {
    public class SeedDrinksDTO
        {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DatePosted { get; set; }
        public string Descripton { get; set; } = string.Empty;
        public bool IsAlcoholic { get; set; }
        public bool IsPrivate { get; set; }
        public string Image { get; set; } = string.Empty;
        public string? Origen { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;
        public int TumbsUp { get; set; } = 0;
        public int Cups { get; set; }

        public TempIngrediantModel[] Ingredients { get; set; }
        public TempStepModel[] Steps { get; set; }
        }
    }
