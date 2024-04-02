using CookBook.Infrastructures.Data.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Infrastructures.Data.Models.Food
    {
    public class FoodStepsFoodRecepies
        {
        [Required]
        public int FoodRecepieId { get; set; }

        [ForeignKey(nameof(FoodRecepieId))]
        public FoodRecepie? FoodRecepie { get; set; }

        [Required]
        public int FoodStepId { get; set; }

        [ForeignKey(nameof(FoodStepId))]
        public Step? FoodStep { get; set; }
        }

    }
