using CookBook.Constants;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Infrastructures.Data.Models.Food
    {
    public class FoodStep
        {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        [StringLength(LenghtParams.StepDescriptionMaxLengt)]
        public string Description { get; set; } = string.Empty;

        public ICollection<FoodStepsFoodRecepies> FoodRecepie { get; set; } = new List<FoodStepsFoodRecepies>();
        }
    }
