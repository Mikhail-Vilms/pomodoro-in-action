using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomodoroInAction.Models
{
    [Table("board")]
    public class Board : BaseEntity
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public ICollection<Container> Containers { get; set; }
    }
}
