using CookBook.Data.Models;
using CookBook.Models.Utilities;

namespace CookBook.Models.Ingredients
    {
    public class IngredientInputViewModel
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public IEnumerable<UtilTypeModel> Measurements { get; set; } = new HashSet<UtilTypeModel>();
        }
    }
