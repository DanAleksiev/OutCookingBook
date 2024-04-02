using CookBook.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Infrastructures.Data.Models.Food
    {
    public class OvenType
        {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LenghtParams.OvenMaxLenght)]
        [Description("Fan, conventional, gas , etc.")]
        public string Name { get; set; } = string.Empty;
        }
    }
