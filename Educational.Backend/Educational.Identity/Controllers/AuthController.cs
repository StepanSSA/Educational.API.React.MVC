using Educational.Identity.Data.Entity;
using Educational.Identity.Models;
using IdentityModel;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Educational.Identity.Controllers
{
    
    [Route("[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly IIdentityServerInteractionService interactionService;

        public AuthController(SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager, IIdentityServerInteractionService interactionService)
        {
            this.signInManager=signInManager;
            this.userManager=userManager;
            this.interactionService=interactionService;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl) 
        {
            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Username.ToUpper());
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(user,model.Password, true, true);
            if(result.Succeeded)
                return Redirect(model.ReturnUrl);

            ModelState.AddModelError(string.Empty, "Login error");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            var model = new RegisterViewModel { ReturnUrl = returnUrl, BirthDate = new DateTime(DateTime.Now.Year-16, DateTime.Now.Month, DateTime.Now.Day) };
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new AppUser
            {
                Email = model.Email,
                Firstname = model.Firstname,
                Lastname = model.LastName,
                UserName = model.Firstname+"_" +model.LastName,
                BirthDate = DateOnly.FromDateTime(model.BirthDate)
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {   
                await signInManager.SignInAsync(user, false);

                AddStudent(user);

                if (model.ReturnUrl == "Desktop")
                    return View("SucceededRegistration");

                return Redirect(model.ReturnUrl);
            }

            ModelState.AddModelError(string.Empty, "Register error");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await signInManager.SignOutAsync();
            var logoutResult = await interactionService.GetLogoutContextAsync(logoutId);
            return Redirect(logoutResult.PostLogoutRedirectUri);
        }

        [HttpGet]
        public IActionResult RegisterTeacher(string returnUrl)
        {
            var model = new RegisterViewModel { ReturnUrl = returnUrl, BirthDate = new DateTime(DateTime.Now.Year-16, DateTime.Now.Month, DateTime.Now.Day) };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTeacherAsync(RegisterViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new AppUser
            {
                Email = model.Email,
                Firstname = model.Firstname,
                Lastname = model.LastName,
                UserName = model.Email,
                BirthDate = DateOnly.FromDateTime(model.BirthDate)
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                AddTeacher(user);
                return Redirect(model.ReturnUrl);
            }

            ModelState.AddModelError(string.Empty, "Register error");
            return View(model);
        }


        private async void AddTeacher(AppUser user)
        {
            await userManager.AddToRoleAsync(user, Roles.Teacher);
            await AddClaimsToUser(user, Roles.Teacher);
            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(new HttpRequestMessage()
                {
                    RequestUri=new Uri("https://localhost:7083/api/Teacher/CreateTeacher"),
                    Method = HttpMethod.Post,
                    Content = new StringContent(JsonSerializer.Serialize(new
                        {
                            userId = user.Id,
                            name = user.Firstname,
                            lastname = user.Lastname,
                            email = user.Email
                       }), Encoding.UTF8, "application/json")
                });
                
            }
            AddInChat(user);
        }

        private async void AddStudent(AppUser user)
        {
            await userManager.AddToRoleAsync(user, Roles.Student);
            await AddClaimsToUser(user, Roles.Student);
            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(new HttpRequestMessage()
                {
                    RequestUri=new Uri($"https://localhost:7083/api/Student/AddStudent"),
                    Method = HttpMethod.Post,
                    Content = new StringContent(JsonSerializer.Serialize(new
                    {
                        userId = user.Id,
                        name = user.Firstname,
                        lastname = user.Lastname,
                        email = user.Email
                    }), Encoding.UTF8, "application/json")
                });
            }
            AddInChat(user);
        }

        private async void AddInChat(AppUser user)
        {
            using(var clietn = new HttpClient()) 
            {
                await clietn.PostAsync($"http://localhost:40510/api/User?userId={user.Id}&userName={user.Firstname}", new StringContent(""));
            }
        }

        private async Task AddClaimsToUser(AppUser user, string role)
        {
            await userManager.AddClaimAsync(user, new Claim(JwtClaimTypes.GivenName, user.Firstname));
            await userManager.AddClaimAsync(user, new Claim(JwtClaimTypes.ClientId, user.Id));
            await userManager.AddClaimAsync(user, new Claim(JwtClaimTypes.FamilyName, user.Lastname));
            await userManager.AddClaimAsync(user, new Claim(JwtClaimTypes.Email, user.Email));
            await userManager.AddClaimAsync(user, new Claim(JwtClaimTypes.BirthDate, user.BirthDate.ToString()));
            await userManager.AddClaimAsync(user, new Claim(JwtClaimTypes.Role, role));
        }
    }

    
}
