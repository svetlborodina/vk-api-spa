using System;
using System.Threading.Tasks;
using VkApiSPA.Models;

namespace VkApiSPA.Services.Interfaces
{
    public interface IAuthService
    {
        string GetToken();
        Uri GenerateUrl(int clientId);
        Task<Token> CreateAsync(int clientId, string secretKey, string code);
    }
}
