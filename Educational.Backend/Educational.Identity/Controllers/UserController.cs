using Educational.Identity.Data.Entity;
using Educational.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Educational.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager=userManager;
        }

        [HttpGet]
        [Route("[controller]/userinfo")]
        public async Task<UserInfoModel> UserInfo(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) 
            {
                return new UserInfoModel();
            }

            var roleList = await _userManager.GetRolesAsync(user);

            var userInfo = new UserInfoModel()
            {
                BirthDate = user.BirthDate.ToString(),
                Email = user.Email,
                Id = user.Id,
                Lastname = user.Lastname,
                Name = user.Firstname,
                Role = roleList
                    .Where(r => r == Roles.Student || 
                    r == Roles.Teacher || 
                    r == Roles.Administrator || 
                    r == Roles.Editor).FirstOrDefault("none")
            };

            return userInfo;
        }

        [HttpGet]
        public ActionResult<List<UserInfoModel>> GetAllUsers() 
        {
            var model = _userManager.Users.ToList()?? new List<AppUser>() {new AppUser() };
            var userInfo = new List<UserInfoModel>();
            foreach (var item in model)
            {
                userInfo.Add(new UserInfoModel()
                {
                    Email = item.Email,
                    Id = item.Id,
                    Lastname = item.Lastname,
                    Name = item.Firstname
                });
            }
            return Ok(userInfo);
        }

    }
}
