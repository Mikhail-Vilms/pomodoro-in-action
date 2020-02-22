using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomodoroInAction.Models
{
    public class BaseEntity
    {
        [Column("id")]
        [Required]
        public int Id { get; set; }
    }
}
