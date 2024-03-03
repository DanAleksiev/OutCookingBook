using CookBook.Constants;
using CookBook.Infrastructures.Data.Models.Food;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Infrastructures.Data.Models.Shared
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

        public FoodRecepie FoodRecepie { get; set; }
    }
}
