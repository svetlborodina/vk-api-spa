using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VkApiSPA.Services.Interfaces;

namespace VkApiSPA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public ActionResult Read()
        {
            return Ok(_authService.GetToken());
        }

        [HttpGet("generate")]
        public async Task<ActionResult> GenerateUrl(int clientId)
        {
            return Ok(_authService.GenerateUrl(clientId));
        }

        [HttpGet("add")]
        public async Task<ActionResult> Add(int clientId, string secretKey, string code)
        {
            var token = await _authService.CreateAsync(clientId, secretKey, code);

            if (token?.AuthToken != null)
            {
                return Ok(token?.AuthToken);
            }
            else
            {
                return BadRequest("Unauthorized user");
            }
        }
    }
}
