using CookBook.Constants;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Infrastructures.Data.Models.Shared
{
    public class Step
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        [StringLength(LenghtParams.StepDescriptionMaxLengt)]
        public string Description { get; set; } = string.Empty;
        }
}
