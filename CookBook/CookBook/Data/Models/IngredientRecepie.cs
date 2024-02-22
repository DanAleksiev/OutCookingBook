using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Data.Models
    {
    public class IngredientRecepie
        {
        public int IngredientId { get; set; }

        [ForeignKey(nameof(IngredientId))]
        public Ingredient Ingredient { get; set; }
        public int RecepieId { get; set; }

        [ForeignKey(nameof(RecepieId))]
        public Recepie Recepie { get; set; }
    }
    }
