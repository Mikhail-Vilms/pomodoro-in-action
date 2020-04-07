using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PomodoroInAction.Models
{
    [Table("board")]
    public class Board : BaseEntity
    {
        [Column("display_name")]
        [Required]
        [MaxLength(100)]
        public string DisplayName { get; set; }

        [Column("description")]
        [MaxLength(300)]
        public string Description { get; set; }
       
        [Column("sort_order")]
        [Required]
        public int SortOrder { get; set; }

        [Column("is_archived")]
        [Required]
        public bool IsArchived { get; set; } = false;

        [Column("is_public")]
        [Required]
        public bool IsPublic { get; set; } = false;

        
        public ICollection<KanbanContainer> Containers { get; set; }

        [JsonIgnore]
        public ICollection<AppUserBoard> AppUserBoards { get; set; }
    }
}
