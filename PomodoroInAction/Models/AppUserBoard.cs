using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PomodoroInAction.Models
{
    [Table("user_board")]
    public class AppUserBoard
    {
        [Column("board_id")]
        [Required]
        public int BoardId { get; set; }
        public Board Board { get; set; }

        [Column("user_id")]
        [Required]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        [Column("is_owner")]
        [Required]
        public bool IsOwner { get; set; }
    }
}
