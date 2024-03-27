using CookBook.Constants;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Core.Models.Shared
    {
    public class EditStepForm
        {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        [StringLength(LenghtParams.StepDescriptionMaxLengt)]
        public string Description { get; set; } = string.Empty;

        public string? OwnerId { get; set; }
        }
    }
