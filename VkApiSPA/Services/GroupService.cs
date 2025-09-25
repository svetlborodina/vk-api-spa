using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VkApiSPA.Data;
using VkApiSPA.Helpers;
using VkApiSPA.Models;
using VkApiSPA.Services.Interfaces;

namespace VkApiSPA.Services
{
    public class GroupService : Repository<Group>, IGroupService
    {
        private readonly IAuthService _authService;
        public GroupService(DbContext context, IAuthService authService) : base(context)
        {
            _authService = authService;
        }

        public async Task<List<(int, bool)>> LeaveGroups(int userId, List<int> excludeIds)
        {
            var token = _authService.GetToken();
            var groups = await GetAll(token, userId);
            if (!groups.Items.Any())
            {
                return null;
            }

            var filtered = groups.Items.Except(excludeIds).ToList();
            var result = new List<(int, bool)>();
            foreach (var group in filtered)
            {
                var response = await LeaveGroup(token, group);
                result.Add((group, response));
                await Task.Delay(500);
            }
            return result;
        }
        
        private async Task<AllGroups> GetAll(string token, int userId)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(Const.AllGroupsUrl(token, userId));
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var result = ParseAllGroupsResponse(response);
            return result.Response;
        }

        private async Task<bool> LeaveGroup(string token, int groupId)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(Const.LeaveGroupUrl(token, groupId));
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            var result = ParseLeaveGroupResponse(response);
            return result;
        }

        private bool ParseLeaveGroupResponse(HttpResponseMessage response)
        {
            var json = response.Content.ReadAsStringAsync().Result;
            var obj = JsonSerializer.Deserialize<LeaveGroupResponse>(json);

            return obj.Response == 1;
        }

        private AllGroupsResponse ParseAllGroupsResponse(HttpResponseMessage response)
        {
            var json = response.Content.ReadAsStringAsync().Result;
            var obj = JsonSerializer.Deserialize<AllGroupsResponse>(json);

            return obj;
        }

        public class LeaveGroupResponse
        {
            public int Response { get; set; }
        }

        public class AllGroupsResponse
        {
            public AllGroups Response { get; set; }
        }

        public class AllGroups
        {
            public int Count { get; set; }
            public List<int> Items { get; set; }
        }
    }
}
