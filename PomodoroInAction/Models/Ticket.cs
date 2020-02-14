using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomodoroInAction.Models
{
    [Table("ticket")]
    public class Ticket : BaseEntity
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
    }
}
