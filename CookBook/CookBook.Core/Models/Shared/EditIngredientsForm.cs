using CookBook.Constants;
using CookBook.Core.Models.Utilities;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Core.Models.Shared
    {
    public class EditIngredientsForm
        {
        public int Id { get; set; }

        [Required]
        [StringLength(LenghtParams.IngredientNameMaxLengt,
            MinimumLength = LenghtParams.IngredientNameMinLengt,
            ErrorMessage = LenghtErrors.IngredientLenghtError)]
        public string Name { get; set; } = string.Empty;

        [StringLength(LenghtParams.IngredientDescriptionMaxLengt)]
        public string Type { get; set; } = string.Empty;
        public int Calories { get; set; }

        public double Amount { get; set; }
        public int MeasurmentId { get; set; }
        public IEnumerable<UtilTypeModel> MeasurmentTypes { get; set; } = new HashSet<UtilTypeModel>();
        public string OwnerId { get; set; }
    }
    }
