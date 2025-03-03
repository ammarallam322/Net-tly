using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using teamProject.Models;
using teamProject.Repository;
using teamProject.Repository.ImodelRepository;
using teamProject.Services;
using teamProject.viewModel;

namespace teamProject.Controllers
{
    public class RecietController : Controller
    {
        private readonly IRecietServicecs recietServicecs;
        private readonly IRepositoryGeneric<Client> clientRepo;
        private readonly IClientRepository ClientItSelf;


        public RecietController( IRecietServicecs recietServicecs , IRepositoryGeneric<Client> clientRepo, IClientRepository ClientItSelf)
        {
            this.recietServicecs = recietServicecs;
            this.clientRepo = clientRepo;
            this.ClientItSelf = ClientItSelf;
        }

        public IActionResult Index()
        {
            var receipt = new ReceitViewModel();
            return View("Index", receipt);
        }

        public IActionResult GetClientDetails(string phoneNumber)
        {
            
            var client = ClientItSelf.GetClientByPhone(phoneNumber);

            var receit = recietServicecs.GetRecietData(client.Id);
            if (receit == null)
            {
                return NotFound();
            }
            return Json(receit);
        }




        public IActionResult Paid(int clientId)
        {

           recietServicecs.Paid(clientId);
            var receit = recietServicecs.GetRecietData(clientId);
            if (receit == null)
            {
                return NotFound();
            }
            return Json(receit);
        }


        //public IActionResult Index(string phone)
        //{
        //    int id = 1;
        //    var receit =recietServicecs.GetRecietData(id);
        //    receit.clients = new SelectList(clientRepo.GetAll(), "Id", "Phone");
        //    return View(receit);
        //}

    }
}
