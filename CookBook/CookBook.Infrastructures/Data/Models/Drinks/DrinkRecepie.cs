using CookBook.Constants;
using CookBook.Infrastructures.Data.Models.Shared;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Infrastructures.Data.Models.Drinks
    {
    public class DrinkRecepie
        {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LenghtParams.RecepieNameMaxLengt)]
        public string Name { get; set; } = string.Empty;

        public IList<IngredientDrinkRecepie> IngredientsRecepies { get; set; } = new List<IngredientDrinkRecepie>();
        public ICollection<DrinkRecepiesUsers> RecepiesUsers { get; set; } = new List<DrinkRecepiesUsers>();
        public ICollection<FavouriteDrinkRecepiesUsers> FavouriteRecepiesUsers { get; set; } = new List<FavouriteDrinkRecepiesUsers>();

        [Required]
        public DateTime DatePosted { get; set; }

        [Required]
        public ICollection<DrinkStepDrinkRecepie> Steps { get; set; } = new List<DrinkStepDrinkRecepie>();

        [StringLength(LenghtParams.DescriptionMaxLengt)]
        public string Descripton { get; set; } = string.Empty;

        [Required]
        public bool IsAlcoholic { get; set; }

        [Required]
        public bool IsPrivate { get; set; }

        [Required]
        [StringLength(LenghtParams.ImageMaxLengt)]
        public string Image { get; set; } = string.Empty;

        [StringLength(LenghtParams.OrigenMaxLenght)]
        public string? Origen { get; set; } = string.Empty;

        [Required]
        public string OwnerId { get; set; } = string.Empty;

        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; }

        [Required]
        public int TumbsUp { get; set; } = 0;

        public ICollection<DrinkLikeUser> Likes { get; set; } = new List<DrinkLikeUser>();

        [Required]
        public int Cups { get; set; }
        }
    }
