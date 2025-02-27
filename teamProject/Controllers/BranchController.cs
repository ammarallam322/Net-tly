using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teamProject.Models;
using teamProject.Repository;
using teamProject.Repository.ImodelRepository;
using teamProject.viewModel.Branch;

namespace teamProject.Controllers
{
    public class BranchController : Controller
    {
        IMapper mapper;
        IBranchRepository branch;
        UserManager<ApplicationUser> user;
        IRepositoryGeneric<BranchMobile> mob;
        IRepositoryGeneric<BranchPhone> phn;

        public BranchController(IBranchRepository branch, IMapper mapper , UserManager<ApplicationUser> user, IRepositoryGeneric<BranchMobile> mob, IRepositoryGeneric<BranchPhone> phn)
        {
            this.branch = branch;
            this.mapper = mapper;
            this.user  = user;
            this.mob = mob;
            this.phn = phn;
        }

        // Select ----------------------------------
        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            var totalCount = branch.GetPagination().Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var paginatedData = branch.GetPagination()
                                      .Skip((page - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToList();

            List<BranchPhMobViewModel> brnchModel = mapper.Map<List<BranchPhMobViewModel>>(paginatedData);

            ViewBag.TotalCount = totalCount;
            ViewBag.Page = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.PageSize = pageSize;

            return View("Index", brnchModel);
        }


        // Pagination ------------------------------
        [HttpGet]
        public IActionResult Get(int page = 1, int pageSize = 5)
        {
            var totalCount = branch.GetPagination().Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var paginatedData = branch.GetPagination()
                                      .Skip((page - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToList();

            var result = new
            {
                Data = paginatedData,
                Page = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalCount = totalCount
            };

            return Ok(result);
        }

        // Edit ------------------------------------
        public async Task<IActionResult> Details (int id)
        {
            BranchEditViewModel brnchModel = mapper.Map<BranchEditViewModel>(branch.GetById(id));
            brnchModel.Employees = await user.Users.ToListAsync() ?? new List<ApplicationUser>();

            if (brnchModel == null)
                return NotFound();

            return View("Details", brnchModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BranchEditViewModel branchFromReq)
        {
            if (ModelState.IsValid)
            {
                //var existingBranch = branch.GetBranchWithMobPhnById(branchFromReq, id);

                //if (existingBranch != null)
                //{
                //    ModelState.AddModelError("Manager_Id", "This manager is already assigned to another branch.");
                //    branchFromReq.Employees = await user.Users.ToListAsync() ?? new List<ApplicationUser>();
                //    return View("Details", branchFromReq);
                //}

                Branch branchEntity = branch.GetBranchWithMobPhnById(id);

                if (branchEntity == null)
                    return NotFound();

                mapper.Map(branchFromReq, branchEntity);

                branchEntity.BranchMobiles ??= new BranchMobile { Br_Id = id };
                branchEntity.BranchPhones ??= new BranchPhone { Br_Id = id };
                branchEntity.BranchMobiles.Br_Mob1 = branchFromReq.Mobile1;
                branchEntity.BranchMobiles.Br_Mob2 = branchFromReq.Mobile2;
                branchEntity.BranchPhones.Br_Ph1 = branchFromReq.Phone1;
                branchEntity.BranchPhones.Br_Ph2 = branchFromReq.Phone2;

                try
                {
                    branch.Update(branchEntity);
                    branch.Save();
                }
                catch (Exception ex)
                {
                    branchFromReq.Employees = await user.Users.ToListAsync() ?? new List<ApplicationUser>();
                    return View("Details", branchFromReq);
                }

                return RedirectToAction("Index");
            }
            branchFromReq.Employees = await user.Users.ToListAsync() ?? new List<ApplicationUser>();
            return View("Details", branchFromReq);
        }

        // Add --------------------------------------
        public async Task<IActionResult> Create()
        {

            var emps = await user.Users.ToListAsync() ?? new List<ApplicationUser>();
            BranchForCreateViewModel brnch = new BranchForCreateViewModel()
            {
                Employees = emps
            };
            
            return View("Create", brnch);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> createConfirm (BranchForCreateViewModel branchFromReq)
        {
            if (ModelState.IsValid)
            {
                Branch brnch = mapper.Map<Branch>(branchFromReq);
                branch.Add(brnch);

                BranchMobile brnMob = new BranchMobile()
                {
                    Br_Mob1 = branchFromReq.Mobile1,
                    Br_Mob2 = branchFromReq.Mobile2
                };
                brnch.BranchMobiles = brnMob;

                BranchPhone brnPhn = new BranchPhone()
                {
                    Br_Ph1 = branchFromReq.Phone1,
                    Br_Ph2 = branchFromReq.Phone2
                };
                brnch.BranchPhones = brnPhn;

                branch.Save();
                return RedirectToAction("Index");
            }

            var emps = await user.Users.ToListAsync() ?? new List<ApplicationUser>();
            branchFromReq.Employees = emps;
            return View("Create", branchFromReq);
        }
        // Delete -----------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var br = branch.GetById(id);
            if (br == null)
            {
                return NotFound();
            }
            
            branch.Delete(id);
            branch.Save();

            return RedirectToAction("Index");
        }


    }
}
