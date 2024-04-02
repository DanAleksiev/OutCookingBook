using CookBook.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Infrastructures.Data.Models.Food
    {
    public class RecepieType
        {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LenghtParams.RecepieTypeNameLenght)]
        [Description("Commonly known as")]
        public string Name { get; set; } = string.Empty;

        [StringLength(LenghtParams.RecepieTypeDescriptionLenght)]
        [Description("Quick description of the type")]
        public string Description { get; set; } = string.Empty;
        }
    }
