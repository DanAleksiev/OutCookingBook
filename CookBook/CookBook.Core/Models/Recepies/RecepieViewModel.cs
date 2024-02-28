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
        public IEnumerable<UtilTypeModel> RecepieTypes { get; set; } = new List<UtilTypeModel>();

        public string Image { get; set; }


        public int PrepTime { get; set; }


        public int CookTime { get; set; }
        public int OvenTypeId { get; set; }
        public IEnumerable<UtilTypeModel> OvenTypes { get; set; } = new List<UtilTypeModel>();
        public int MeasurmentId { get; set; }
        public IEnumerable<UtilTypeModel> MeasurmentTypes { get; set; } = new List<UtilTypeModel>();

        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "lenght wrong")]
        public string IngredientName { get; set; }

        //[Required]
        //[Range(1.00,3.123)]
        public double IngredientAmount { get; set; }

        public string Origen { get; set; }
        public int Portions { get; set; }
        public string Preparation { get; set; }

        public int Temperature { get; set; }


        }
    }
