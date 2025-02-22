using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            List<BranchPhMobViewModel> brnchModel = mapper.Map<List<BranchPhMobViewModel>>(branch.GetAll());
            return View("Index", brnchModel);
        }

        public IActionResult Details(int id)
        {
            if (id == null)
                return NotFound();

            Branch brnch = branch.GetById(id);

            if (brnch == null)
                return NotFound();

            return View("Details", brnch);
        }


    }
}
