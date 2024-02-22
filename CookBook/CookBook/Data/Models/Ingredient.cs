using CookBook.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Data.Models
    {
    public class Ingredient
        {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LenghtParams.IngredientMaxLengt,
            MinimumLength = LenghtParams.IngredientMaxLengt,
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
        public ICollection<IngredientRecepie> IngredientsRecepies { get; set; } = new HashSet<IngredientRecepie>();
    }

    }
