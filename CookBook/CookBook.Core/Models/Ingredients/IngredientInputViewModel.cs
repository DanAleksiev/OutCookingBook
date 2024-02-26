using CookBook.Core.Models.Utilities;

namespace CookBook.Core.Models.Ingredients
    {
    public class IngredientInputViewModel
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int MeasurementId { get; set; }
        public IEnumerable<UtilTypeModel> Measurements { get; set; } = new List<UtilTypeModel>();
        }
    }
