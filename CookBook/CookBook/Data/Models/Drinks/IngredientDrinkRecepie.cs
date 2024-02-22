using CookBook.Data.Models.Drinks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Data.Models.Shared
{
    public class IngredientDrinkRecepie
    {
        public int IngredientId { get; set; }

        [ForeignKey(nameof(IngredientId))]
        public Ingredient Ingredient { get; set; }
        public int RecepieId { get; set; }

        [ForeignKey(nameof(RecepieId))]
        public DrinkRecepie Recepie { get; set; }
    }
}
