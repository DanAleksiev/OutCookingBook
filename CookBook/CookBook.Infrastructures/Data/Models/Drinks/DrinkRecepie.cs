using CookBook.Constants;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
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
        [Description("Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Description("All ingredients in the recepie")]
        public IList<IngredientDrinkRecepie> IngredientsRecepies { get; set; } = new List<IngredientDrinkRecepie>();

        [Description("")]
        public ICollection<DrinkRecepiesUsers> RecepiesUsers { get; set; } = new List<DrinkRecepiesUsers>();

        [Description("All the Users who have Favor this revepie")]
        public ICollection<FavouriteDrinkRecepiesUsers> FavouriteRecepiesUsers { get; set; } = new List<FavouriteDrinkRecepiesUsers>();

        [Required]
        [Description("Date")]
        public DateTime DatePosted { get; set; }

        [Required]
        [Description("Steps to follow")]
        public ICollection<DrinkStepsDrinkRecepies> Steps { get; set; } = new List<DrinkStepsDrinkRecepies>();

        [StringLength(LenghtParams.DescriptionMaxLengt)]
        [Description("Description")]
        public string Descripton { get; set; } = string.Empty;

        [Required]
        [Description("Alcohol in the drink")]
        public bool IsAlcoholic { get; set; }

        [Required]
        [Description("Private?")]
        public bool IsPrivate { get; set; }

        [Required]
        [Description("Is the recepie published by profesional cook")]
        public bool IsProfesional { get; set; }

        [Required]
        [StringLength(LenghtParams.ImageMaxLengt)]
        [Description("How does the recepie looks when cooked")]
        public string Image { get; set; } = string.Empty;

        [StringLength(LenghtParams.OrigenMaxLenght)]
        [Description("Where is the country of origen of the recepie")]
        public string? Origen { get; set; } = string.Empty;

        [Required]
        public string OwnerId { get; set; } = string.Empty;

        [ForeignKey(nameof(OwnerId))]
        [Description("The author of the recepie")]
        public IdentityUser? Owner { get; set; }

        [Required]
        [Description("Upvotes")]
        public int TumbsUp { get; set; } = 0;

        [Description("List of people who like the recepie")]
        public ICollection<DrinkLikeUser> Likes { get; set; } = new List<DrinkLikeUser>();

        [Required]
        [Description("How many cups are maid if you follow the recepie")]
        public int Cups { get; set; }

        }
    }
