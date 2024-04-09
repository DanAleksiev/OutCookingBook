namespace CookBook.Core.Models.Shared
    {
    public class RecepieQueryModel
        {
        public int TotalRecepies { get; set; }
        public IEnumerable<AllRecepieViewModel> Recepies { get; set; }

        }
    }
