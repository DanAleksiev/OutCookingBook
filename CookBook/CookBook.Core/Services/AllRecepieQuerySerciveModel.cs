using CookBook.Core.Enum;

namespace CookBook.Core.Services
    {
    public class AllRecepieQuerySerciveModel
        {
        public const int RecepiesPerPage = 5;
        public string? SearchTerm { get; set; }
        public SearchFieldsEnum Searching { get; set; }
        public SortingFieldsEnum Sorting { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalRecepiesCount { get; set; }
        public IEnumerable<RecepieServiceModel> Recepies { get; set; } = new List<RecepieServiceModel>();
        }
    }
