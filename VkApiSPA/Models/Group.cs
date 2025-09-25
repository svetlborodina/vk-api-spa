using System.ComponentModel.DataAnnotations;
using VkApiSPA.Data;

namespace VkApiSPA.Models
{
    public class Group: BaseEntity
    {
        [MaxLength(255)]
        public string Title { get; set; }
    }
}
