using CookBook.Core.Enum;
using CookBook.Core.Models.Shared;

namespace CookBook.Core.Services
    {
    public class AllRecepieQuerySerciveModel
        {
        public int RecepiesPerPage { get; } = 5;
        public string SearchTerm { get; set; } = null!;
        public SearchFieldsEnum Searching { get; init; }
        public SortingFieldsEnum Sorting { get; init; }
        public int CurrentPage { get; init; } = 1;
        public int TotalRecepiesCount { get; set; }
        public IEnumerable<AllRecepieViewModel> Recepies { get; set; } = new List<AllRecepieViewModel>();
        }
    }
