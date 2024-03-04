using CookBook.Constants;
using CookBook.Core.Models.Utilities;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Core.Models.Food
    {
    public class EditRecepieForm
        {
        public int Id { get; set; }
        [Required]
        [StringLength(LenghtParams.RecepieNameMaxLengt,
            MinimumLength = LenghtParams.RecepieNameMinLengt,
            ErrorMessage = LenghtErrors.LenghtError)]
        public string Name { get; set; }

        [Required]
        [StringLength(LenghtParams.DescriptionMaxLengt,
            MinimumLength = LenghtParams.DescriptionMinLengt,
            ErrorMessage = LenghtErrors.LenghtError)]
        public string Description { get; set; }
        public int RecepieTypeId { get; set; }
        public IEnumerable<UtilTypeModel> RecepieTypes { get; set; } = new HashSet<UtilTypeModel>();

        [Required]
        [StringLength(LenghtParams.ImageMaxLengt)]
        public string Image { get; set; }


        public int PrepTime { get; set; }

        public int Temperature { get; set; }
        public int TemperatureTypeId { get; set; }
        public IEnumerable<UtilTypeModel> TemperatureTypes { get; set; } = new HashSet<UtilTypeModel>();

        public int CookTime { get; set; }
        public int OvenTypeId { get; set; }
        public IEnumerable<UtilTypeModel> OvenTypes { get; set; } = new HashSet<UtilTypeModel>();
        public int MeasurmentId { get; set; }
        public IEnumerable<UtilTypeModel> MeasurmentTypes { get; set; } = new HashSet<UtilTypeModel>();
        public bool IsPrivate { get; set; } = true;
        [Required]
        [StringLength(LenghtParams.OrigenMaxLenght)]
        public string Origen { get; set; }
        public int Portions { get; set; }
        }
    }
