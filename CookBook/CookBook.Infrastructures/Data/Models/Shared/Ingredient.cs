using CookBook.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Infrastructures.Data.Models.Shared
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LenghtParams.IngredientMaxLengt,
            MinimumLength = LenghtParams.IngredientMinLengt,
            ErrorMessage = LenghtErrors.IngredientLenghtError)]
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Calories { get; set; }

        [Required]
        public double Amount { get; set; }
        [Required]
        public int MeasurementId { get; set; }

        [ForeignKey(nameof(MeasurementId))]
        public Measurement Measurement { get; set; }
        public ICollection<IngredientFoodRecepie> IngredientsRecepies { get; set; } = new HashSet<IngredientFoodRecepie>();
    }

}
