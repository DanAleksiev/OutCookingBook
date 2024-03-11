using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Infrastructures.Data.Models.Drinks
{
    public class FavouriteDrinkRecepiesUsers
        {
        [Required]
        public int DrinkRecepieId { get; set; }

        [ForeignKey(nameof(DrinkRecepieId))]
        public DrinkRecepie DrinkRecepie { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
    }

}
