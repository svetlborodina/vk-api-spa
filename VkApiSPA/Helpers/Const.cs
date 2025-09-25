namespace VkApiSPA.Helpers
{
    public static class Const
    {
        private const string AuthorizeBaseUrl = "https://oauth.vk.com/authorize";
        private const string TokenBaseUrl = "https://oauth.vk.com/access_token";
        private const string RedirectUrl = "https://api.vk.com/blank.html";
        private const string AllGroupsBaseUrl = "https://api.vk.com/method/groups.get";
        private const string LeaveGroupBaseUrl = "https://api.vk.com/method/groups.leave";
        private const string AllConversationsBaseUrl = "https://api.vk.com/method/messages.getConversations";
        private const string AllMessagesBaseUrl = "https://api.vk.com/method/messages.get";

        private const string Scope = "offline,groups";
        private const string Version = "5.131";

        public static string AuthorizeUrl(int clientId) =>
            $"{AuthorizeBaseUrl}?response_type=code&client_id={clientId}&redirect_uri={RedirectUrl}&scope={Scope}&v={Version}";

        public static string TokenUrl(int clientId, string secretKey, string code) =>
            $"{TokenBaseUrl}?client_id={clientId}&client_secret={secretKey}&redirect_uri={RedirectUrl}&code={code}&v={Version}";

        public static string AllGroupsUrl(string token, int userId) =>
            $"{AllGroupsBaseUrl}?access_token={token}&user_id={userId}&v={Version}";

        public static string LeaveGroupUrl(string token, int groupId) =>
            $"{LeaveGroupBaseUrl}?access_token={token}&group_id={groupId}&v={Version}";
        
        public static string AllConversationsUrl(string token, int userId) =>
            $"{AllConversationsBaseUrl}?access_token={token}&user_id={userId}&v={Version}";
        
        public static string AllMessagesUrl(string token, int userId) =>
            $"{AllMessagesBaseUrl}?access_token={token}&user_id={userId}&v={Version}";
    }
}
