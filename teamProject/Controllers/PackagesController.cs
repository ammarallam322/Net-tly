using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using teamProject.Models;
using teamProject.Repository;
using teamProject.viewModel;

namespace teamProject.Controllers
{
    public class PackagesController : Controller
    {
        IRepositoryGeneric<package> repo;
        private readonly IRepositoryGeneric<Provider_Package> provider_Package;
        private readonly IRepositoryGeneric<myServiceProvider> servRepo;

        //ref fom mapconfig
        IMapper mapper;
        public PackagesController(IRepositoryGeneric<package> repo, IRepositoryGeneric<Provider_Package> Provider_Package, IRepositoryGeneric<myServiceProvider> ServRepo, IMapper mapper)
        {
            this.repo = repo;
            provider_Package = Provider_Package;
            servRepo = ServRepo;
            this.mapper = mapper;
        }


        // GET: packages
        public IActionResult Index()
        {
           return View("Index", repo.GetAll());
            

        }

        public IActionResult Details(int id)
        {
         

            var package = repo.GetById(id);
            if (package == null)
            {
                return NotFound();
            }

            return View(package);
        }

        public IActionResult Create()
        {
            
            var package = new PackagesViewModel();
            package.MyServiceProviders = new SelectList(servRepo.GetAll(), "Id", "Name");
            return View(package);
        }

        [HttpPost]
        public IActionResult Create(PackagesViewModel packageVM)
        {
            if (ModelState.IsValid)
            {
               
                package package = mapper.Map<package>(packageVM);


                repo.Add(package);
                repo.Save();
                provider_Package.Add(new Provider_Package { Package_Id = package.Id, provider_Id = packageVM.service_Id });
                provider_Package.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(packageVM);
        }

        public IActionResult Edit(int id)
        {
            

            var package = repo.GetById(id);
            if (package == null)
            {
                return NotFound();
            }
            return View(package);
        }

        [HttpPost]
        public IActionResult Edit(int id, PackagesViewModel packageVM)
        {



            if (ModelState.IsValid)
            {
                //mapping
                package package = mapper.Map<package>(packageVM);
                package.Id = id;
                try
                {
                    repo.Update(package);
                    repo.Save();
                }
                catch (Exception ex)
                {
                    return View(ex.Message);



                }
                return RedirectToAction(nameof(Index));
            }
            return View(packageVM);
        }
        public IActionResult Delete(int id)
        {
           
            var package = repo.GetById(id);
            if (package == null)
            {
                return NotFound();
            }

            return View(package);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var package = repo.GetById(id);
            if (package != null)
            {
                repo.Delete(id);
            }

            repo.Save();
            return RedirectToAction(nameof(Index));
        }












    }
}
