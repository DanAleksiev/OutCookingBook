using CookBook.Core.Contracts;
using CookBook.Core.Services;

namespace CookBook.Core.Models.Shared
    {
    public class RecepieQueryModel
        {
        public int TotalRecepies { get; set; }
        public IEnumerable<RecepieServiceModel> Recepies { get; set; }

    }
    }
