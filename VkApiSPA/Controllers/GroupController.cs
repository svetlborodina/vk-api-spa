using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VkApiSPA.Models;
using VkApiSPA.Services.Interfaces;

namespace VkApiSPA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost("leave")]
        public async Task<ActionResult> Leave([FromQuery]int userId, [FromBody]ExcludeGroups excludeGroups)
        {
            var excludesIds = excludeGroups.ExcludesIdsStr?.Split(',').Select(int.Parse).ToList();
            var result = await _groupService.LeaveGroups(userId, excludesIds);
            return Ok(result);
        }
    }
}
