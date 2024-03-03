﻿using CookBook.Infrastructures.Data.Models.Shared;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CookBook.Constants;

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

        [Required]
        public DateTime DatePosted { get; set; }

        [Required]
        public ICollection<DrinkStep> Steps { get; set; } = new HashSet<DrinkStep>();

        [StringLength(LenghtParams.DescriptionMaxLengt)]
        public string Descripton { get; set; } = string.Empty;

        [Required]
        public bool IsAlcoholic { get; set; }

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
        public int TumbsUp { get; set; } = 0;
        [Required]
        public int Cups { get; set; }
    }
    }
