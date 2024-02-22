using CookBook.Data.Models.Shared;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Data.Models.Drinks
    {
    public class DrinkRecepie
        {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public IList<IngredientDrinkRecepie> IngredientsRecepies { get; set; } = new List<IngredientDrinkRecepie>();
        public ICollection<DrinkRecepiesUsers> RecepiesUsers { get; set; } = new List<DrinkRecepiesUsers>();

        [Required]
        public DateTime DatePosted { get; set; }

        [Required]
        public ICollection<Step> Steps { get; set; } = new HashSet<Step>();

        [Required]
        public bool IsAlcoholic { get; set; }

        [Required]
        public string Image { get; set; } = string.Empty;

        [Required]
        public int PrepTime { get; set; }

        public string Origen { get; set; } = string.Empty;

        [Required]
        public string Preparation { get; set; } = string.Empty;

        [Required]
        public string OwnerId { get; set; } = string.Empty;

        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; }

        [Required]
        public int TumbsUp { get; set; } = 0;
        [Required]
        public int Cups { get; set; }
    }
    }
