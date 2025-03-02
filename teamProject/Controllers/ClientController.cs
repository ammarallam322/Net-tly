using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using teamProject.Models;
using teamProject.Repository;
using teamProject.Repository.ImodelRepository;
using teamProject.viewModel;
using teamProject.viewModel.Branch;

namespace teamProject.Controllers
{
    public class ClientController : Controller
    {
        private readonly IRepositoryGeneric<Client> clientRepository;
        private readonly IRepositoryGeneric<myServiceProvider> serviceRepo;
        private readonly IRepositoryGeneric<Offer> offerRepo;
        private readonly IRepositoryGeneric<package> packageRepo;
        private readonly IRepositoryGeneric<Central> centralRepo;
        private readonly IClientRepository clientRepo;
        private readonly IMapper mapper;

        public ClientController(IRepositoryGeneric<Client> clientRepository, IMapper mapper,
            IRepositoryGeneric<myServiceProvider> serviceRepo, IRepositoryGeneric<Offer> offerRepo,
            IRepositoryGeneric<package> packageRepo, IRepositoryGeneric<Central> centralRepo, IClientRepository clientRepo)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
            this.serviceRepo = serviceRepo;
            this.offerRepo = offerRepo;
            this.packageRepo = packageRepo;
            this.centralRepo = centralRepo;
            this.clientRepo = clientRepo;
        }
        public IActionResult Index()
        {
            ViewBag.TotalCount = clientRepository.GetAll().Count();
            return View("Index", clientRepository.GetAll());
        }
        

        public IActionResult Details(int id)
        {
            var package = clientRepository.GetById(id);

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
                clientRepository.Add(client);
                clientRepository.Save();
                return RedirectToAction(nameof(Index));
            }

            ClientViewModel model = new ClientViewModel
            {
                myServiceProviders = new SelectList(serviceRepo.GetAll(), "Id", "Name"),
                packages = new SelectList(packageRepo.GetAll(), "Id", "Name"),
                Offer_Services = new SelectList(offerRepo.GetAll(), "Id", "Name"),
                centrals = new SelectList(centralRepo.GetAll(), "Id", "Name")
            };
            return View(model);
        }
        public IActionResult GetAllServicesPackage(int id)
        {
            var Package = clientRepo.GetServicePackages(id);

            return Json(Package);
        }
        public IActionResult GetOfferService(int id)
        {
            List<Offer> offers = clientRepo.GetOfferService(id);
            List<ShowOfferViewModel> showOffer = new List<ShowOfferViewModel>();
            foreach (var item in offers)
            {
                ShowOfferViewModel myOffer = new ShowOfferViewModel();
                myOffer.Id = item.Id;
                myOffer.Name = item.Name;
                showOffer.Add(myOffer);
            }

            return Json(showOffer);
        }
        public IActionResult Edit(int id)

        {
            var package = clientRepository.GetById(id);
            ClientViewModel clientVM = mapper.Map<ClientViewModel>(package);
            clientVM = new ClientViewModel
            {
                myServiceProviders = new SelectList(serviceRepo.GetAll(), "Id", "Name"),
                packages = new SelectList(packageRepo.GetAll(), "Id", "Name"),
                Offer_Services = new SelectList(offerRepo.GetAll(), "Id", "Name"),
                centrals = new SelectList(centralRepo.GetAll(), "Id", "Name"),
                Name = clientVM.Name,
                Mobile = clientVM.Mobile,
                Phone = clientVM.Phone,
                Address = clientVM.Address,
                Email = clientVM.Email,
                SSN = clientVM.SSN,
                Service_Id = clientVM.Service_Id,
                Offer_Id = clientVM.Offer_Id,
              
            };
            clientVM.Id = id;
            if (package == null)
            {
                return NotFound();
            }
            return View(clientVM);
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
                    clientRepository.Update(client);
                    clientRepository.Save();
                }
                catch (Exception ex)
                {
                    return View(clientVM);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clientVM);
        }

        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var myClient = clientRepository.GetById(id);
        //    ClientViewModel clientVM = mapper.Map<ClientViewModel>(myClient);
        //    if (clientVM == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(clientVM);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var Client = clientRepository.GetById(id);
            if (Client == null)
            {
                return Json(new { success = false, message = "Client not found." });
            }
            try
            {
                clientRepository.Delete(id);
                clientRepository.Save();
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error removing client." });
            }
            return Json(new { success = true, message = "Client deleted successfully." });
        }

    }
}
