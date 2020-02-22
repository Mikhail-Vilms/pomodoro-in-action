using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomodoroInAction.Models
{
    [Table("board")]
    public class Board : BaseEntity
    {
        [Column("display_name")]
        [Required]
        public string DisplayName { get; set; }

        [Column("description")]
        public string Description { get; set; }
       
        [Column("sort_order")]
        [Required]
        public int SortOrder { get; set; }

        public ICollection<KanbanContainer> Containers { get; set; }
    }
}
