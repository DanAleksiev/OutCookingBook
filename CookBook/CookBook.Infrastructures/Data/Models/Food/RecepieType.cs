using System.ComponentModel.DataAnnotations;

namespace CookBook.Infrastructures.Data.Models.Food
{
    public class RecepieType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        }
}
