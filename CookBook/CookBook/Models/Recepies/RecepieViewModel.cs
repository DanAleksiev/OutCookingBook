using CookBook.Models.Utilities;

namespace CookBook.Models.Recepies
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

        public string Origen { get; set; }
        public int Portions { get; set; }
        public string Preparation { get; set; }

        public int Temperature { get; set; }


        }
    }
