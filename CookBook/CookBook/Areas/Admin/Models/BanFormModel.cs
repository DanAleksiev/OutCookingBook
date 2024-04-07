using CookBook.Constants;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Areas.Admin.Models
    {
    public class BanFormModel
        {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public int Lenght { get; set; }

        [Required]
        [StringLength(LenghtParams.BanReasonMaxLenght,
            MinimumLength = LenghtParams.BanReasonMinLenght)]
        public string Reason { get; set; } = null!;
        }
    }
