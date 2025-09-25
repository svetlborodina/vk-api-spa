using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VkApiSPA.Data
{
    public abstract class Repository<T> : IRepository<T> 
        where T : BaseEntity, new()
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _set;

        public Repository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            _set.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public IQueryable<T> Read()
        {
            return _set.AsNoTracking().AsQueryable();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entityEntry = _set.Update(entity);
            await _context.SaveChangesAsync();
            return await Task.FromResult(entityEntry.Entity);
        }

        public async Task<T> FindAsync(int id)
        {
            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
