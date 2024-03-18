using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Infrastructures.Data.Models.Food
    {
    public class FavouriteFoodRecepiesUsers
        {
        [Required]
        public int FoodRecepieId { get; set; }

        [ForeignKey(nameof(FoodRecepieId))]
        public FoodRecepie FoodRecepie { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
        }

    }
