using CookBook.Infrastructures.Data.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Infrastructures.Data.Models.Drinks
    {
    public class DrinkStepsDrinkRecepies
        {

        public int DrinkRecepieId { get; set; }

        [ForeignKey(nameof(DrinkRecepieId))]
        public DrinkRecepie? DrinkRecepie { get; set; }

        [Required]
        public int StepId { get; set; }
        [ForeignKey(nameof(StepId))]
        public Step? DrinkStep { get; set; }
        }
    }