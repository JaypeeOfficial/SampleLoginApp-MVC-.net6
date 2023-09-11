using NuGet.Protocol.Plugins;
using SampleLoginApp.Common;
using SampleLoginApp.Contracts;
using SampleLoginApp.Data;

namespace SampleLoginApp.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base (context)
        {
            
        }

        public async Task<PaginatedResult<Product>> GetPaginated(int page, int pageSize, string keyword)
        {
            return await GetPaginated(page, pageSize, t => t.ProductName.Contains(keyword ?? string.Empty));
        }
    }
}
