using CookBook.Constants;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Infrastructures.Data.Models.Drinks
    {
    public class DrinkStep
        {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        [StringLength(LenghtParams.StepDescriptionMaxLengt)]
        public string Description { get; set; } = string.Empty;

        public ICollection<DrinkStepsDrinkRecepies> DrinkRecepiesDrinkSteps { get; set; } = new HashSet<DrinkStepsDrinkRecepies>();
        }
    }
