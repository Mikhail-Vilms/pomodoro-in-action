using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomodoroInAction.Models
{
    [Table("ticket")]
    public class Ticket : BaseEntity
    {
        [Required]
        [Column("display_name")]
        public string DisplayName { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Required]
        [Column("sort_order")]
        public int SortOrder { get; set; }

        [Required]
        [Column("container_id")]
        public int KanbanContainerId { get; set; }
    }
}
