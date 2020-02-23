using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PomodoroInAction.Models;
using System;
using System.Threading.Tasks;

namespace PomodoroInAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private UserManager<AppUser> _userManager;

        public AppUsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        // POST: /api/AppUsers/Register
        public async Task<IActionResult> Register(AppUserModel model)
        {
            AppUser applicationUser = new AppUser()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}