using Microsoft.EntityFrameworkCore;
using SampleLoginApp.Common;
using SampleLoginApp.Contracts;
using SampleLoginApp.Data;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace SampleLoginApp.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
                                           where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _table;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public async Task Create(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetOne(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task Update(object id, object model)
        {
            var t = await GetOne(id);
            if (t != null)
            {
                _context.Entry(t).CurrentValues.SetValues(model);
                await _context.SaveChangesAsync();

            }
        }

        public async Task Delete(object id)
        {
            var t = await GetOne(id);
            if(t != null)
            {
                _context.Remove(t);
                await _context.SaveChangesAsync();  
            }
        }

        public async Task<PaginatedResult<T>> GetPaginated(int page, int pageSize,
                        Expression<Func<T, bool>> condition) 
        {
           var count = await _table.Where(condition).CountAsync();
           var records = await _table.Where(condition)
                        .Skip((page - 1 ) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();

            return new PaginatedResult<T>
            { 
                Result = records,
                Page = page,
                TotalCount = (int)Math.Ceiling(count / (double)pageSize)
            };

        }
    }
}
