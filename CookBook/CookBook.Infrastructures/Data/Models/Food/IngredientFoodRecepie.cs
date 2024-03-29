using CookBook.Infrastructures.Data.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Infrastructures.Data.Models.Food
    {
    public class IngredientFoodRecepie
        {
        public int IngredientId { get; set; }

        [ForeignKey(nameof(IngredientId))]
        public Ingredient Ingredient { get; set; }
        public int RecepieId { get; set; }

        [ForeignKey(nameof(RecepieId))]
        public FoodRecepie Recepie { get; set; }
        }
    }
