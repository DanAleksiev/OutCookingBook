using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CookBook.Data.Models
    {
    public class Recepie
        {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public IList<IngredientRecepie> IngredientsRecepies { get; set; } = new List<IngredientRecepie>();
        public ICollection<RecepiesUsers> RecepiesUsers { get; set;} = new List<RecepiesUsers>();

        [Required]
        public DateTime DatePosted { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; } = string.Empty;

        [Required]
        public int PrepTime { get; set; }
        
        [Required]
        public int CookTime { get; set; }

        public int Portions { get; set; }

        [Required]
        public int RecepieTypeId { get; set; }

        [ForeignKey(nameof(RecepieTypeId))]
        public RecepieType RecepieType { get; set; }
        public string Origen { get; set; } = string.Empty;

        [Required]
        public string Preparation { get; set; } = string.Empty;

        public int Temperature { get; set; }

        [Required]
        public int TemperatureMeasurmentId { get; set; }

        [ForeignKey(nameof(TemperatureMeasurmentId))]
        public TemperatureMeasurment TemperatureMeasurment { get; set; }

        public int OvenTypeId { get; set; }
        public OvenType OvenType { get; set; }

        [Required]
        public string OwnerId { get; set; } = string.Empty;

        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; }

        [Required]
        public int TumbsUp { get; set; } = 0;
        public DateTime LastTimeYouHadIt { get; set; }

    }
    }
