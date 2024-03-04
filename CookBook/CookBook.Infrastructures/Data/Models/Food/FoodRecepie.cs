using CookBook.Infrastructures.Data.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using CookBook.Constants;

namespace CookBook.Infrastructures.Data.Models.Food
    {
    public class FoodRecepie
        {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LenghtParams.RecepieNameMaxLengt)]
        public string Name { get; set; } = string.Empty;

        public ICollection<IngredientFoodRecepie> IngredientsRecepies { get; set; } = new List<IngredientFoodRecepie>();

        public ICollection<FoodRecepiesUsers> RecepiesUsers { get; set; } = new List<FoodRecepiesUsers>();

        public ICollection<FavouriteFoodRecepiesUsers> FavouriteRecepiesUsers { get; set; } = new List<FavouriteFoodRecepiesUsers>();

        [StringLength(LenghtParams.DescriptionMaxLengt)]
        public string Descripton { get; set; } = string.Empty;

        [Required]
        public DateTime DatePosted { get; set; }

        [Required]
        public ICollection<FoodStepsFoodRecepies> Steps { get; set; } = new List<FoodStepsFoodRecepies>();

        [Required]
        [StringLength(LenghtParams.ImageMaxLengt)]
        public string Image { get; set; } = string.Empty;

        [Required]
        public int PrepTime { get; set; }

        [StringLength(LenghtParams.OrigenMaxLenght)]
        public string Origen { get; set; } = string.Empty;

        [Required]
        public string OwnerId { get; set; } = string.Empty;

        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; }

        [Required]
        public int TumbsUp { get; set; }

        [Required]
        public int CookTime { get; set; }

        public int Portions { get; set; }

        [Required]
        public int RecepieTypeId { get; set; }

        [ForeignKey(nameof(RecepieTypeId))]
        public RecepieType RecepieType { get; set; }

        public int Temperature { get; set; }

        [Required]
        public int TemperatureMeasurmentId { get; set; }

        [ForeignKey(nameof(TemperatureMeasurmentId))]
        public TemperatureMeasurment TemperatureMeasurment { get; set; }

        public int OvenTypeId { get; set; }

        [ForeignKey(nameof(OvenTypeId))]
        public OvenType OvenType { get; set; }

        public DateTime LastTimeYouHadIt { get; set; }

        public bool IsPrivate { get; set; }
    }
    }
