using CookBook.Data.Models.Drinks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Data.Models.Shared
    {
    public class DrinkRecepiesUsers
    {
        [Required]
        public int RecepieId { get; set; }

        [ForeignKey(nameof(RecepieId))]
        public DrinkRecepie Recepie { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
    }

}
