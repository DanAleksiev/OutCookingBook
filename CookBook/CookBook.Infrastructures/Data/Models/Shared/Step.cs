using CookBook.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Infrastructures.Data.Models.Shared
    {
    public class Step
        {
        [Key]
        public int Id { get; set; }

        [Required]
        [Description("What number of step is that")]
        public int Position { get; set; }

        [Required]
        [StringLength(LenghtParams.StepDescriptionMaxLengt)]
        [Description("The instructions that the user  has to follow")]
        public string Description { get; set; } = string.Empty;
        }
    }
