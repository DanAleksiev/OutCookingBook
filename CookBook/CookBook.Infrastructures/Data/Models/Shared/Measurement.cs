using CookBook.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Infrastructures.Data.Models.Shared
    {
    public class Measurement
        {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LenghtParams.MeasurementsNameMaxLengt)]
        [Description("Gram, each, table spoons, etc.")]
        public string Name { get; set; } = string.Empty;

        }
    }
