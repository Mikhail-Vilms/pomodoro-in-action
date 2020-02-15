using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomodoroInAction.Models
{
    [Table("container")]
    public class KanbanContainer : BaseEntity
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
