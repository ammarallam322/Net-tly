using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using teamProject.Models;
using teamProject.Repository;
using teamProject.viewModel;

namespace teamProject.Controllers
{
    public class CentralController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly TeamContext _context;
        private readonly IRepositoryGeneric<Central> repo;

        public CentralController(TeamContext context,IRepositoryGeneric<Central> repo)
        {
            _context = context;
            this.repo = repo;
        }
        public List<CentralGovernmentViewModel> All()
        {

            List<Central> cents = _context.Centrals
                       .Include(c => c.Governerate) 
                       .ToList();


         //   List<Central> cents= repo.GetAll();
            List<CentralGovernmentViewModel> centrals=new List<CentralGovernmentViewModel>();
            CentralGovernmentViewModel central;
            foreach (var item in cents)
            {
             central=   new CentralGovernmentViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    GovernerateName = item.Governerate?.Name?? "No Gover",
                    Gov_Id = item.Gov_Id

                };

                centrals.Add(central);
            }

            return centrals;
        }

        public IActionResult Index()
        {


            return View("Index",All());
        }

        public IActionResult Create()
        {
            var model = new CentralGovernmentViewModel
            {
                Governerates = _context.Governerates.Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Name
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveCreate(CentralGovernmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //model.Governerates = _context.Governerates.Select(g => new SelectListItem
                //{
                //    Value = g.Id.ToString(),
                //    Text = g.Name
                //}).ToList();

                Central central2 = new Central();
                
                central2.Name = model.Name;
                central2.Gov_Id =model.Gov_Id;
                

                repo.Add(central2);
                repo.Save();

                //_context.SaveChanges();
                return RedirectToAction("Index" ,All());
            }

            var central = new Central
            {
                Name = model.Name,
                Gov_Id = model.Gov_Id
            };

            _context.Centrals.Add(central);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var central = _context.Centrals.FirstOrDefault(c => c.Id == id);
            if (central == null) return NotFound();

            CentralGovernmentViewModel model = new CentralGovernmentViewModel()
            {
                Id = central.Id,
                Name = central.Name,
                Gov_Id = central.Gov_Id ?? 0,
                Governerates = _context.Governerates.Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Name
                })
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveEdit(CentralGovernmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
              Central cent =repo.GetById(model.Id);
                if (cent == null) return NotFound();
                cent.Name = model.Name;
                cent.Gov_Id = model.Gov_Id;
                repo.Update(cent);
                repo.Save();

                return RedirectToAction("Index", All());
            }

            var central = _context.Centrals.Find(model.Id);
            if (central == null) return NotFound();

            central.Name = model.Name;
            central.Gov_Id = model.Gov_Id;

            _context.Centrals.Update(central);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index)); 
        }
        // Delete ----------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var central = _context.Centrals.Find(id);
            if (central == null) return NotFound();

            _context.Centrals.Remove(central);
            _context.SaveChanges();
            return Json(new { success = true });
        }
    }
}
