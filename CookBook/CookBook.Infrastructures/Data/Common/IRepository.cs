namespace CookBook.Infrastructures.Data.Common
    {
    public interface IRepository
        {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllReadOnly<T>() where T : class;

        Task AddAsync<T>(T entity) where T : class;

        Task<int> SaveChangesAsync();

        Task<T?> GetByIdAsync<T>(string id) where T: class; 
        }
    }
