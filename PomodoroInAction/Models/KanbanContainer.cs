using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        //[JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore, IsReference = true)]
        public ICollection<Ticket> Tickets { get; set; }
    }
}
