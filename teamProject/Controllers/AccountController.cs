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
                //mapping 
                ApplicationUser appuser = new ApplicationUser()
                {
                    UserName = UserFromRequest.Name,
                    PasswordHash = UserFromRequest.Password,
                    Address = UserFromRequest.Address,



                };
                // saving to database
                IdentityResult result =
                                  await userManager.CreateAsync(appuser, UserFromRequest.Password);

                // create cookie in case of succes
                if (result.Succeeded)
                {

                    //Create  session Cooike
                    await signInManager.SignInAsync(appuser, false);

                    return RedirectToAction("Index", "Home");
                }
                else           //adding  errors description into modelstate
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

                // gettinh user from database by user name 
                ApplicationUser userfromDB = await userManager.FindByNameAsync(UserFromRequest.UserName);

                if (userfromDB != null)
                {
                    //check password
                    bool found = await userManager.CheckPasswordAsync(userfromDB, UserFromRequest.Password);

                    if (found)
                    {

                        //Create  session Cooike and redirect to home page
                        await signInManager.SignInAsync(userfromDB, false);

                        return RedirectToAction("Index", "Home");

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
