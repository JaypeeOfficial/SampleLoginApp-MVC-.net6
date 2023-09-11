using SampleLoginApp.Common;
using SampleLoginApp.Data;

namespace SampleLoginApp.Contracts
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<PaginatedResult<Product>> GetPaginated(int page, int pageSize, string keyword);
         


    }
}
