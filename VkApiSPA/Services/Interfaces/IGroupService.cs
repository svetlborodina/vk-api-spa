using System.Collections.Generic;
using System.Threading.Tasks;
using VkApiSPA.Data;
using VkApiSPA.Models;

namespace VkApiSPA.Services.Interfaces
{
    public interface IGroupService : IRepository<Group>
    {
        Task<List<(int, bool)>> LeaveGroups(int userId, List<int> excludeIds);
    }
}
