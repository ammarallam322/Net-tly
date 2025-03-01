using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using teamProject.Models;
using teamProject.Repository;
using teamProject.Services;
using teamProject.viewModel;

namespace teamProject.Controllers
{
    public class RecietController : Controller
    {
        private readonly IRecietServicecs recietServicecs;
        private readonly IRepositoryGeneric<Client> clientRepo;

        public RecietController( IRecietServicecs recietServicecs , IRepositoryGeneric<Client> clientRepo)
        {
            this.recietServicecs = recietServicecs;
            this.clientRepo = clientRepo;
        }
        public IActionResult Index()
        {
            int id = 1;
            var receit =recietServicecs.GetRecietData(id);
            receit.clients = new SelectList(clientRepo.GetAll(), "Id", "SSN");


            return View(receit);
        }

        public IActionResult GetClientDetails(int clientId)
        {

            var receit = recietServicecs.GetRecietData(clientId);
            if (receit == null)
            {
                return NotFound();
            }

            return Json(receit);
        }

    }
}
