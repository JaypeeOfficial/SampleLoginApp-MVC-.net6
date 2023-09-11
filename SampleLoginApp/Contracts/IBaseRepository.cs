using SampleLoginApp.Common;

namespace SampleLoginApp.Contracts
{
    public interface IBaseRepository<T>
    {

        Task Create(T entity);
        Task<T> GetOne(object id);
        Task<IEnumerable<T>> GetAll();
        Task Update(object id, object model);
        Task Delete (object id);

        Task<PaginatedResult<T>> GetPaginated(int page, int pageSize);

    }
}
