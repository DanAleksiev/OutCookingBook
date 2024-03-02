using CookBook.Constants;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Infrastructures.Data.Models.Shared
{
    public class Measurement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LenghtParams.MeasurementsNameMaxLengt)]
        public string Name { get; set; } = string.Empty;

    }
}
