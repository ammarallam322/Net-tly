using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using teamProject.Models;
using teamProject.Repository;
using teamProject.viewModel;

namespace teamProject.Controllers
{
    public class ClientController : Controller
    {
        private readonly IRepositoryGeneric<Client> repo;
        private readonly IRepositoryGeneric<myServiceProvider> serviceRepo;
        private readonly IRepositoryGeneric<Offer> offerRepo;
        private readonly IRepositoryGeneric<package> packageRepo;
        private readonly IRepositoryGeneric<Central> centralRepo;
        private readonly IMapper mapper;

        public ClientController(IRepositoryGeneric<Client> clientRepository , IMapper mapper ,
            IRepositoryGeneric<myServiceProvider> serviceRepo , IRepositoryGeneric<Offer> offerRepo ,
            IRepositoryGeneric<package> packageRepo , IRepositoryGeneric<Central> centralRepo )
        {
            this.repo = clientRepository;
            this.mapper = mapper;
            this.serviceRepo = serviceRepo;
            this.offerRepo = offerRepo;
            this.packageRepo = packageRepo;
            this.centralRepo = centralRepo;
        }
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
            ClientViewModel model = new ClientViewModel
            {
                myServiceProviders = new SelectList(serviceRepo.GetAll(), "Id", "Name"),
                packages = new SelectList(packageRepo.GetAll(), "Id", "Name"),
                Offer_Services = new SelectList(offerRepo.GetAll(), "Id", "Name"),
                centrals = new SelectList(centralRepo.GetAll(), "Id", "Name")
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ClientViewModel clientVM)
        {
            if (ModelState.IsValid)
            {
                Client client = mapper.Map<Client>(clientVM);
                repo.Add(client);
                repo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(clientVM);
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
        public IActionResult Edit(int id, ClientViewModel clientVM)
        {
            if (ModelState.IsValid)
            {
                Client client = mapper.Map<Client>(clientVM);
                client.Id = id;
                try
                {
                    repo.Update(client);
                    repo.Save();
                }
                catch (Exception ex)
                {
                    return View(clientVM);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clientVM);
        }

        [HttpGet]
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
            if (package == null)
            {
                return NotFound();
            }
            try
            {
                repo.Delete(id);
                repo.Save();
            }
            catch (Exception ex)
            {
                return View(package); 
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
