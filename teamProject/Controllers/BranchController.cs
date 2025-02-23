using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teamProject.Models;
using teamProject.Repository.ImodelRepository;
using teamProject.viewModel.Branch;

namespace teamProject.Controllers
{
    public class BranchController : Controller
    {
        IBranchRepository branch;
        IMapper mapper;
        public BranchController(IBranchRepository branch, IMapper mapper)
        {
            this.branch = branch;
            this.mapper = mapper;
        }

        // Select ----------------------------------
        public IActionResult Index()
        {
            List<BranchPhMobViewModel> brnchModel = mapper.Map<List<BranchPhMobViewModel>>(branch.GetAll());
            return View("Index", brnchModel);
        }

        // Edit ------------------------------------
        public IActionResult Details(int id)
        {
            BranchPhMobViewModel brnchModel = mapper.Map<BranchPhMobViewModel>(branch.GetById(id));

            if (brnchModel == null)
                return NotFound();

            return View("Details", brnchModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BranchPhMobViewModel branchVM)
        {
            if (ModelState.IsValid)
            {
                var realBranch = branch.GetById(branchVM.Id);
                if (realBranch == null)
                    return NotFound();

                mapper.Map(branchVM, realBranch);

                branch.Update(realBranch);
                branch.Save();

                return RedirectToAction("Index");
            }

            return View("Details", branchVM);
        }

        // Add --------------------------------------
        //public IActionResult Create()
        //{
        //    var users =  
        //    return View("Create");
        //}

        // Delete -----------------------------------
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var br = branch.GetById(id);
            if (br == null)
            {
                return NotFound();
            }
            return View("Delete", br);
        }

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
