using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomodoroInAction.Models
{
    [Table("ticket")]
    //[JsonObject(IsReference = true)]
    public class Ticket : BaseEntity
    {
        [Column("display_name")]
        [Required]
        [MaxLength(127)]
        public string DisplayName { get; set; }

        [Column("sort_order")]
        [Required]
        public int? SortOrder { get; set; }

        [Column("description")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Column("container_id")]
        [Required]
        public int? KanbanContainerId { get; set; }

        //[JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore, IsReference = true)]
        public KanbanContainer KanbanContainer { get; set; }
    }
}
