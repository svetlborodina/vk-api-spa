using System;
using VkApiSPA.Data;

namespace VkApiSPA.Models
{
    public class Token : BaseEntity
    {
        public string AuthToken { get; set; }
        public DateTime Created { get; set; }
    }
}
