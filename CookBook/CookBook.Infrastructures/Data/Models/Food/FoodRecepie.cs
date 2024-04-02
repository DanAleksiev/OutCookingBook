using CookBook.Constants;
using CookBook.Infrastructures.Data.Models.Shared;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Infrastructures.Data.Models.Food
    {
    public class FoodRecepie
        {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LenghtParams.RecepieNameMaxLengt)]
        public string Name { get; set; } = string.Empty;

        [Description("All ingredients in the recepie")]
        public ICollection<IngredientFoodRecepie> IngredientsRecepies { get; set; } = new List<IngredientFoodRecepie>();

        [Description("All ingredients in the recepie")]
        public ICollection<FoodRecepiesUsers> RecepiesUsers { get; set; } = new List<FoodRecepiesUsers>();

        public ICollection<FavouriteFoodRecepiesUsers> FavouriteRecepiesUsers { get; set; } = new List<FavouriteFoodRecepiesUsers>();

        [StringLength(LenghtParams.DescriptionMaxLengt)]
        [Description("Description")]
        public string Descripton { get; set; } = string.Empty;

        [Required]
        [Description("Date")]
        public DateTime DatePosted { get; set; }

        [Required]
        [Description("Steps to follow")]
        public ICollection<FoodStepsFoodRecepies> Steps { get; set; } = new List<FoodStepsFoodRecepies>();

        [Required]
        [StringLength(LenghtParams.ImageMaxLengt)]
        [Description("How does the recepie looks when cooked")]
        public string Image { get; set; } = string.Empty;

        [Required]
        [Description("The time it takes to prepare all ingreadients before you start cooking")]
        public int PrepTime { get; set; }

        [StringLength(LenghtParams.OrigenMaxLenght)]
        [Description("Where is the country of origen of the recepie")]
        public string? Origen { get; set; }

        [Required]
        public string OwnerId { get; set; } = string.Empty;

        [ForeignKey(nameof(OwnerId))]
        [Description("The author of the recepie")]
        public IdentityUser? Owner { get; set; }

        [Required]
        [Description("Upvotes")]
        public int TumbsUp { get; set; }

        [Required]
        [Description("the time it takes to cook the ingredients")]
        public int CookTime { get; set; }

        [Description("How many portions are maid if you follow the recepie")]
        public int Portions { get; set; }

        [Required]
        public int RecepieTypeId { get; set; }

        [ForeignKey(nameof(RecepieTypeId))]
        [Description("The tipe of the meal(Dish, soup, salad, etc.)")]
        public RecepieType? RecepieType { get; set; }

        [Description("Whats the temperature of the oven during cooking")]
        public int Temperature { get; set; }

        [Required]
        [Description("Celsius or farenheit")]
        public int TemperatureMeasurmentId { get; set; }

        [ForeignKey(nameof(TemperatureMeasurmentId))]
        public TemperatureMeasurment? TemperatureMeasurment { get; set; }

        public int OvenTypeId { get; set; }

        [ForeignKey(nameof(OvenTypeId))]
        [Description("What oven was used originally")]
        public OvenType? OvenType { get; set; }

        [Description("List of people who like the recepie")]
        public ICollection<FoodLikeUser> Likes { get; set; } = new List<FoodLikeUser>();
        
        [Required]
        [Description("Is the recepie private")]
        public bool IsPrivate { get; set; }
        
        [Description("Is the recepie published by profesional cook")]
        public bool IsProfesional { get; set; }

        [Description("Did the Admin validated the location")]
        public bool VerifyedLocation { get; set; }
        }
    }
