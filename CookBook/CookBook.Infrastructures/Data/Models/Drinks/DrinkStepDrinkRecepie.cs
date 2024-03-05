using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Infrastructures.Data.Models.Drinks
    {
    public class DrinkStepDrinkRecepie
        {

        public int DrinkRecepieId { get; set; }

        [ForeignKey(nameof(DrinkRecepieId))]
        public DrinkRecepie DrinkRecepie { get; set; }

        [Required]
        public int StepId { get; set; }
        [ForeignKey(nameof(StepId))]
        public DrinkStep DrinkStep { get; set; }
        }
    }