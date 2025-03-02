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
            return View("Create", user);
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
                ModelState.AddModelError("", "Email is already taken.");
                userViewModel.Roles = roleManager.Roles.Select(r => r.Name).ToList();
                return View("Create", userViewModel);
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
                    // Get the user from the database
                    var user = await userManager.FindByIdAsync(id);

                    if (user != null)
                    {
                        // Map the non-password properties
                        mapper.Map(userViewModel, user);

                        // Update the password if a new one is provided
                        if (!string.IsNullOrEmpty(userViewModel.Password))
                        {
                            // Remove the old password
                            var removePasswordResult = await userManager.RemovePasswordAsync(user);
                            if (!removePasswordResult.Succeeded)
                            {
                                foreach (var error in removePasswordResult.Errors)
                                {
                                    ModelState.AddModelError("", error.Description);
                                }
                                return View(userViewModel); // Stop if there's an error in removing the password
                            }

                            // Add the new password and hash it
                            var addPasswordResult = await userManager.AddPasswordAsync(user, userViewModel.Password);
                            if (!addPasswordResult.Succeeded)
                            {
                                foreach (var error in addPasswordResult.Errors)
                                {
                                    ModelState.AddModelError("", error.Description);
                                }
                                return View(userViewModel); // Stop if there's an error in adding the new password
                            }
                        }

                        // Update the other user details
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
                    throw;
                }
            }
            return View(userViewModel);
        }


        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await userManager.Users.FirstOrDefaultAsync(m => m.Id == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    var userVm= mapper.Map<UserViewModel>(user);


        //    return View(userVm);
        //}

        //[HttpPost, //ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var user = await userManager.FindByIdAsync(id);
        //    if (user != null)
        //    {
        //        // Remove the roles associated with the user
        //        var rolesForUser = await userManager.GetRolesAsync(user);
        //        if (rolesForUser.Any())
        //        {
        //            var result = await userManager.RemoveFromRolesAsync(user, rolesForUser);
        //            if (!result.Succeeded)
        //            {
        //                // Handle failure if necessary
        //                ModelState.AddModelError("", "Error removing user roles.");
        //                return View(user);
        //            }
        //        }

        //        // Now delete the user
        //        var deleteResult = await userManager.DeleteAsync(user);
        //        if (deleteResult.Succeeded)
        //        {
        //            return Json(new { success = true });
        //        }

        //        // Handle failure if the user deletion didn't succeed
        //        ModelState.AddModelError("", "Error deleting user.");
        //        return View(user);
        //    }
        //    return NotFound();
        //}

        [HttpPost]
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
                        return Json(new { success = false, message = "Error removing user roles." });
                    }
                }

                // Now delete the user
                var deleteResult = await userManager.DeleteAsync(user);
                if (deleteResult.Succeeded)
                {
                    return Json(new { success = true, message = "User deleted successfully." });
                }

                // Handle failure if the user deletion didn't succeed
                return Json(new { success = false, message = "Error deleting user." });
            }
            return Json(new { success = false, message = "User not found." });
        }
    }
}
