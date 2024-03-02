using CookBook.Constants;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Infrastructures.Data.Models.Food
{
    public class RecepieType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LenghtParams.RecepieTypeNameLenght)]
        public string Name { get; set; } = string.Empty;

        [StringLength(LenghtParams.RecepieTypeDescriptionLenght)]
        public string Description { get; set; } = string.Empty;
        }
}
