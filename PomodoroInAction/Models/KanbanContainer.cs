using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomodoroInAction.Models
{
    [Table("container")]
    public class KanbanContainer : BaseEntity
    {
        [Column("display_name")]
        [Required]
        public string DisplayName { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("sort_order")]
        [Required]
        public int SortOrder { get; set; }

        [Column("board_id")]
        [Required]
        public int BoardId { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
