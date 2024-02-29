using CookBook.Core.Models.Utilities;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Core.Models.Recepies
    {
    public class RecepieViewModel
        {
        //[Required]
        //[StringLength(LenghtParams.RecepieNameMaxLengt,
        //    MinimumLength = LenghtParams.RecepieNameMinLengt,
        //    ErrorMessage = LenghtErrors.LenghtError)]
        public string Name { get; set; }

        //[Required]
        //[StringLength(LenghtParams.DescriptionNameMaxLengt,
        //    MinimumLength = LenghtParams.DescriptionNameMinLengt,
        //    ErrorMessage = LenghtErrors.LenghtError)]
        public string Description { get; set; }
        public int RecepieTypeId { get; set; }
        public IEnumerable<UtilTypeModel> RecepieTypes { get; set; } = new HashSet<UtilTypeModel>();

        public string? Image { get; set; }


        public int? PrepTime { get; set; }

        public int? Temperature { get; set; }
        public int? TemperatureTypeId { get; set; }
        public IEnumerable<UtilTypeModel> TemperatureTypes { get; set; } = new HashSet<UtilTypeModel>();

        public int? CookTime { get; set; }
        public int OvenTypeId { get; set; }
        public IEnumerable<UtilTypeModel> OvenTypes { get; set; } = new HashSet<UtilTypeModel>();
        public int MeasurmentId { get; set; }
        public IEnumerable<UtilTypeModel> MeasurmentTypes { get; set; } = new HashSet<UtilTypeModel>();
        public bool IsPrivate { get; set; } = true;
        
        public string? Origen { get; set; }
        public int? Portions { get; set; }



        //Ingredients
        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "lenght wrong")]
        public string IngredientName { get; set; }

        [Required]
        [Range(0.01, 10000.00)]
        public double IngredientAmount { get; set; }

        //Steps to follow 
        [Required]
        public int StepPosition { get; set; }

        [Required]
        [StringLength(500,MinimumLength =10)]
        public string StepDescription { get; set; }

    }
    }
