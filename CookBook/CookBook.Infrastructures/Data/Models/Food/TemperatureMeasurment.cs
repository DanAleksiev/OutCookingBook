using CookBook.Constants;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Infrastructures.Data.Models.Food
{
    public class TemperatureMeasurment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LenghtParams.TemperatureMeasurmentMaxLenght)]
        public string Name { get; set; } = string.Empty;
    }
}
