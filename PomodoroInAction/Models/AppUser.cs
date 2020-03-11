using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PomodoroInAction.Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<AppUserBoard> AppUserBoards { get; set; }
    }
}
