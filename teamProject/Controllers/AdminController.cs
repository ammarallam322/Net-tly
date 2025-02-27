using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using teamProject.Models;
using teamProject.viewModel;

namespace teamProject.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
     
        //ref from usermanger

        private readonly UserManager<ApplicationUser> userManager;
        //ref from rolemanger
        private readonly RoleManager<IdentityRole> roleManager;


        //ref fom mapconfig
        IMapper mapper;
        public AdminController(UserManager<ApplicationUser> userManager, IMapper mapper,  RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.roleManager = roleManager;
        }


        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();

            var usersVM = new List<UserViewModel>();

            foreach (var user in users)
            {
                var uservm = mapper.Map<UserViewModel>(user);
                if (user!=null)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    uservm.SelectedRole = roles.FirstOrDefault();

                    usersVM.Add(uservm);
                }
                
            }

            return View(usersVM);
        }


        public async Task<IActionResult> Details(string id)
        {
            if (id != null)
            {
                var user = await userManager.FindByIdAsync(id);
                if (user != null)
                {
                    //mapping 
                    var uservm = mapper.Map<UserViewModel>(user);
                    uservm.Roles = (List<string>)await userManager.GetRolesAsync(user);

                    return View(uservm);

                }
            }
            return NotFound();
        }

        public IActionResult Create()
        {
            UserViewModel user = new UserViewModel();
            user.Roles = roleManager.Roles.Select(r => r.Name).ToList();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userViewModel);
            }
            var existingEmail = await userManager.FindByEmailAsync(userViewModel.Email);
            if (existingEmail != null)
            {
                ModelState.AddModelError("", "Username is already taken.");
                return View("Register", userViewModel);
            }
            var user = new ApplicationUser
            {
                UserName = userViewModel.Name,
                Email = userViewModel.Email,
                PasswordHash = userViewModel.Password,
                Address = userViewModel.Address
            };
          

            var result = await userManager.CreateAsync(user, userViewModel.Password);
            var AddUserToRole = await userManager.AddToRoleAsync(user, userViewModel.SelectedRole);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(userViewModel);
        }


        public async Task<IActionResult> Edit(string id)
        {
            
            return await Details(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UserViewModel userViewModel)
        {
            if (id != userViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //getting from db
                    var user = await userManager.FindByIdAsync(id);

                    if (user != null)
                    {
                        //mapping same ref
                        mapper.Map(userViewModel, user);

                        var result = await userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    var x = 0;
                   
                        throw;
                    
                }
            }
            return View(userViewModel);
        }


        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await userManager.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            var userVm= mapper.Map<UserViewModel>(user);


            return View(userVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                // Remove the roles associated with the user
                var rolesForUser = await userManager.GetRolesAsync(user);
                if (rolesForUser.Any())
                {
                    var result = await userManager.RemoveFromRolesAsync(user, rolesForUser);
                    if (!result.Succeeded)
                    {
                        // Handle failure if necessary
                        ModelState.AddModelError("", "Error removing user roles.");
                        return View(user);
                    }
                }

                // Now delete the user
                var deleteResult = await userManager.DeleteAsync(user);
                if (deleteResult.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                // Handle failure if the user deletion didn't succeed
                ModelState.AddModelError("", "Error deleting user.");
                return View(user);
            }
            return NotFound();
        }



    }
}
