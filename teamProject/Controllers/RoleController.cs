using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace teamProject.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IQueryable<IdentityRole> All()
        {
            return roleManager.Roles;
        }
        public IActionResult Index()
        {
            
            return View("Index",All());
        }
        [HttpGet]
        public IActionResult Add()
        {
            var role = new IdentityRole();
            return View("Add",role);
        }
        [HttpPost]
        public async Task< IActionResult> Add(string RoleName) 
        {
            var role = new IdentityRole();
            if (RoleName == null || RoleName.Length<=4) 
            {
                ViewBag.ErrorMessage = "The number of letters must be greater than 4 ";
                return View("Add", role);
            }
            var roleExist = await roleManager.RoleExistsAsync(RoleName);
            if (roleExist)
            {
                ViewBag.ErrorMessage = "The Role Name Is aready exists";
                return View("Add", role);
            }
            var result = await roleManager.CreateAsync(new IdentityRole(RoleName));
            if (result.Succeeded)
            {
                return RedirectToAction("Index", All());
            }
            return View("Add",role);
        }

        [HttpGet]
        public async Task< IActionResult> Edit(string id)
        {
            var role =await roleManager.FindByIdAsync(id);
            return View("Edit",role);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id,string RoleName)
        {
            var role =await roleManager.FindByIdAsync(id);
            if (role == null) 
            {
                ViewBag.ErrorMessage = "Role Not Found ";
                return RedirectToAction("Edit",role); 
            }
            
            var roleExist =await roleManager.RoleExistsAsync(RoleName);
            role.Name = RoleName;
            if (RoleName.Length<4 || RoleName==null)
            {
                ViewBag.ErrorMessage = "The number of letters must be greater than 4";
                return View("Edit", role);
            }
            if (roleExist)
            {
                ViewBag.ErrorMessage = "The Role Is Oready Exists";
                return View("Edit", role);
            }

            
           await roleManager.UpdateAsync(role);
           return RedirectToAction("Index", All());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> DeleteConfirmed(string id)
        {
           
            var role =await roleManager.FindByIdAsync(id);
            if(role ==null)
            {
                return Json(new { success = false, message = "Role not found." });
            }
            await roleManager.DeleteAsync(role);

            return Json(new { success = true, message = "Role deleted successfully." });
        }
    }
}
