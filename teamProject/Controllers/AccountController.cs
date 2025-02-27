using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using teamProject.Models;
using teamProject.viewModel;

namespace teamProject.Controllers
{
    public class AccountController : Controller
    {
        //ref from usermanger and sign in manager

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // register


        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel UserFromRequest)
        {
            // check model state
            if (ModelState.IsValid)
            {
                var existingEmail = await userManager.FindByEmailAsync(UserFromRequest.Email);
                if (existingEmail != null)
                {
                    ModelState.AddModelError("", "Username is already taken.");
                    return View("Register", UserFromRequest);
                }

                //mapping 
                ApplicationUser appuser = new ApplicationUser()
                {

                    UserName = UserFromRequest.Name,
                    Email = UserFromRequest.Email,
                    PasswordHash = UserFromRequest.Password,
                    Address = UserFromRequest.Address,
                };
              
               
                // saving to database
                IdentityResult result = await userManager.CreateAsync(appuser, UserFromRequest.Password);
                var AddUserToRole = await userManager.AddToRoleAsync(appuser, "Employee");

                // create cookie in case of succes
                if (result.Succeeded)
                {

                    //Create  session Cooike
                    await signInManager.SignInAsync(appuser, false);

                    return RedirectToAction("Login", "Account");
                }
                else          
                {
                    foreach (var i in result.Errors) { ModelState.AddModelError("", i.Description); }

                }
            }

            return View("Register", UserFromRequest);
        }

        //login 
        public IActionResult Login()
        {

            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel UserFromRequest)
        {
            //check model state
            if (ModelState.IsValid)
            {
                // ApplicationUser userfromDB = await userManager.FindByNameAsync(UserFromRequest.UserName);
                ApplicationUser userfromDB = await userManager.FindByEmailAsync(UserFromRequest.Email);

                if (userfromDB != null)
                {

                    bool found = await userManager.CheckPasswordAsync(userfromDB, UserFromRequest.Password);

                    if (found)
                    {

                        //Create  session Cooike and redirect to home page
                        await signInManager.SignInAsync(userfromDB, false);

                        return RedirectToAction("Index", "Client");

                    }
                }

                // invalid inpupts
                ModelState.AddModelError("", "invalid user name or password");

            }

            return View("Login", UserFromRequest);

        }
        //logout return to login view
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
