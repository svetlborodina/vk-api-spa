using System.Linq;
using System.Threading.Tasks;

namespace VkApiSPA.Data
{
    public interface IRepository<T>
    {
        Task<T> CreateAsync(T entity);
        IQueryable<T> Read();
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> FindAsync(int id);

    }
}
