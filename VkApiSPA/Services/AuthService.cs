using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using VkApiSPA.Data;
using VkApiSPA.Helpers;
using VkApiSPA.Models;
using VkApiSPA.Services.Interfaces;

namespace VkApiSPA.Services
{
    public class AuthService : Repository<Token>, IAuthService
    {
        public AuthService(DbContext context) : base(context)
        {
        }

        public string GetToken()
        {
            return Read().OrderByDescending(x => x.Id).Select(i => i.AuthToken).FirstOrDefault();
        }

        public Uri GenerateUrl(int clientId)
        {
            return new Uri(Const.AuthorizeUrl(clientId));
        }

        public async Task<Token> CreateAsync(int clientId, string secretKey, string code)
        {
            var url = new Uri(Const.TokenUrl(clientId, secretKey, code));

            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var result = ParseResponseMessage(response, "access_token");
            if (string.IsNullOrEmpty(result))
            {
                return null;
            }

            var token = new Token
            {
                AuthToken = result,
                Created = DateTime.Now
            };
            await CreateAsync(token);
            return token;
        }

        private string ParseResponseMessage(HttpResponseMessage response, string property)
        {
            var json = response.Content.ReadAsStringAsync().Result;
            var obj = JObject.Parse(json);

            return obj[property]?.ToString();
        }
    }
}
