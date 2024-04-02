using CookBook.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Infrastructures.Data.Models.Shared
    {
    public class Ingredient
        {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LenghtParams.IngredientNameMaxLengt,
            MinimumLength = LenghtParams.IngredientNameMinLengt,
            ErrorMessage = LenghtErrors.IngredientLenghtError)]
        public string Name { get; set; } = string.Empty;

        [StringLength(LenghtParams.IngredientDescriptionMaxLengt)]
        public string? Description { get; set; }

        public double Amount { get; set; }
        [Required]
        [Description("The type of mesurement used to mesure the ingredient")]
        public int MeasurementId { get; set; }

        [ForeignKey(nameof(MeasurementId))]
        public Measurement? Measurement { get; set; }
        }

    }
