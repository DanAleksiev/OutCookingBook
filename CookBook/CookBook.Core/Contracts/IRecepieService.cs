using CookBook.Core.Enum;
using CookBook.Core.Models.Shared;

namespace CookBook.Core.Contracts
    {
    public interface IRecepieService
        {
        Task<RecepieQueryModel> AllAsync(
            string? serachTerm = null,
            SearchFieldsEnum serching = SearchFieldsEnum.Name,
            SortingFieldsEnum sorting = SortingFieldsEnum.Newest,
            int currentPage = 1,
            int recepiesPerPage = 1);

        }
    }
