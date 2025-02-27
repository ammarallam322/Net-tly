using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using teamProject.Models;
using teamProject.Repository;
using teamProject.Repository.ImodelRepository;
using teamProject.viewModel;

namespace teamProject.Controllers
{
    public class OfferController : Controller
    {
        private readonly IRepositoryGeneric<Offer> offerRepository;
        private readonly IRepositoryGeneric<myServiceProvider> serviceProvider;
        private readonly TeamContext _context;
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public OfferController( TeamContext context, IRepositoryGeneric<Offer> offerRepository,IRepositoryGeneric<myServiceProvider>serviceProvider)
        {
            this._context = context;
            this.offerRepository = offerRepository;
            this.serviceProvider = serviceProvider;
        }
        public List<OfferServiceProviderViewModel> All()
        {

            var listOfOffer=offerRepository.GetAll();   
            List<OfferServiceProviderViewModel> offers = new List<OfferServiceProviderViewModel>();
            OfferServiceProviderViewModel serviceprovider;
            
            foreach (var item in listOfOffer)
            {
                if(item.Name!=null && item.offerduration !=null )
                {
                    serviceprovider = new OfferServiceProviderViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        OfferDuration = item.offerduration,
                        ServiceProviderId = item?.Servuce_Id,
                        ServiceProviderName = item.ServiceProvider?.Name,

                    };
                    offers.Add(serviceprovider);
                }       
              
            }
            
            return offers;
        }

        public async Task<IActionResult> Index()
        {
          
            return View("Index",All());
        }
        //details of offer
        public async Task<IActionResult> Details(int id)
        {
            var offerRepo = offerRepository.GetById(id);
            var offer = new OfferServiceProviderViewModel();
            offer.Id = id;
            offer.Name = offerRepo.Name;
            offer.ServiceProviderName = offerRepo.ServiceProvider==null?"not found serviceprovider":offerRepo.ServiceProvider.Name;
            offer.OfferDuration = offerRepo.offerduration;
            offer.ServiceProviderId = offerRepo.Servuce_Id;
            if (offer == null) return NotFound();
            return View("Details",offer);
        }
        public IActionResult Create()
        {
            var offer = new OfferServiceProviderViewModel();
            List<myServiceProvider> serviceProviders = _context.ServiceProviders.ToList(); // استرجاع البيانات

           
            offer.ServiceProviders = serviceProviders.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),  
                Text = s.Name             
            }).ToList();

            return View("Create", offer);

            //Offer offer = new Offer();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OfferServiceProviderViewModel model)
        { 
            if (ModelState.IsValid)
            {
                var offer = new Offer
                {
                    Name = model.Name,
                    offerduration = model.OfferDuration,
                    Servuce_Id = model.ServiceProviderId
                };

                 offerRepository.Add(offer);
                 offerRepository.Save();
                return RedirectToAction(nameof(Index));
            }

            //model.ServiceProviders = _context.ServiceProviders.ToList();

           

            return View(model);



            //    if (ModelState.IsValid)
            //    {
            //        offerRepository.Add(offer);
            //        offerRepository.Save();
            //        return RedirectToAction(nameof(Index));
            //    }
            //    //return View(offer);
            //    return RedirectToAction("Index", "Offer");
        }

       


            public async Task<IActionResult> Edit(int id)
            {
            var offer = offerRepository.GetById(id);
            if (offer == null) return NotFound();

            OfferServiceProviderViewModel model = new OfferServiceProviderViewModel
            {
                Id = id,
                Name = offer.Name,
                ServiceProviderId = offer.Servuce_Id,
                OfferDuration = offer.offerduration,
                ServiceProviders = await _context.ServiceProviders
                                      .Select(g => new SelectListItem
                                      {
                                          Value = g.Id.ToString(),
                                          Text = g.Name
                                      }).ToListAsync()
            };

            return View("Edit", model);


            // var offer = offerRepository.GetById(id);
            // //offerRepository.Update(offer);
            // if (offer == null) return NotFound();
            // OfferServiceProviderViewModel model = new OfferServiceProviderViewModel();
            // model.Id = id;
            // model.Name = offer.Name;
            //// model.ServiceProviderName = offer.ServiceProvider==null?"dont have Service Provider":offer.ServiceProvider.Name;
            //model.ServiceProviderName=_context.Offers.Select(g=> new SelectListItem
            //{
            //    Value = g.Id.ToString(),
            //    Text = g.Name
            //})



            // model.ServiceProviderId=offer.Servuce_Id;
            // model.OfferDuration=offer.offerduration;
            // return View("Edit",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OfferServiceProviderViewModel offerRequest)
        {
            if (ModelState.IsValid)
            {
               Offer offer = offerRepository.GetById(offerRequest.Id);
                if (offer == null) return NotFound();
                offer.Name = offerRequest.Name;
                offer.Servuce_Id = offerRequest.ServiceProviderId;
                offer.offerduration=offerRequest.OfferDuration;
                offerRepository.Update(offer);
                offerRepository.Save();
                return RedirectToAction("Index",All());
            }
            var off = _context.Offers.Find(offerRequest.Id);
            if ((off == null)) return NotFound();
            off.Name = offerRequest.Name;
            off.Servuce_Id = offerRequest.ServiceProviderId;
            off.offerduration=offerRequest.OfferDuration;
            _context.Offers.Update(off);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));  
        }

        public async Task<IActionResult> Delete(int id)
        {
            var offer = offerRepository.GetById(id);
            if (offer == null) return NotFound();
            return View("Delete",offer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            offerRepository.Delete(id);
            offerRepository.Save();
            return RedirectToAction("Index",All());
        }
    }
}
