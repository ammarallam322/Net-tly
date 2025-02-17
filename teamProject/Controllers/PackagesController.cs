using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teamProject.Models;
using teamProject.Repository;

namespace teamProject.Controllers
{
    public class PackagesController : Controller
    {
        //private readonly TeamContext _context;
        IRepositoryGeneric<package> repo;

        public PackagesController(IRepositoryGeneric<package> repo)
        {
            this.repo = repo;
        }


        // GET: packages
        public IActionResult Index()
        {
            return View("Index",repo.GetAll());
        }

        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = repo.GetById(id);
            if (package == null)
            {
                return NotFound();
            }

            return View(package);
        }

        public IActionResult Create()
        {
            return View();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Create([Bind("Id,Name,Type,Notes,Active,Price")] package package)
        {
            if (ModelState.IsValid)
            {
                repo.Add(package);
                repo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(package);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = repo.GetById(id);
            if (package == null)
            {
                return NotFound();
            }
            return View(package);
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name,Type,Notes,Active,Price")] package package)
        {
            if (id != package.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
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
            return View(package);
        }

        // GET: packages/Delete/5
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
