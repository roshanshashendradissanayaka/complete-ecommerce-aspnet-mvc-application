using Microsoft.AspNetCore.Mvc;
using eTickets.Data;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;
        public ActorsController(AppDbContext context)
        {
            _context = context;
        }


        /*public IActionResult Index()
        {
            var data = _context.Actors.ToList();
            return View();
        }*/

        public async Task<IActionResult> Index()
        {
            var allActors = await _context.Actors.ToListAsync();
            return View(allActors);
            //by default this will send the call to index view, if you want to send to a specific view the do the below.
            //return view("viewnamethatyouwant",allActors);
        }
    }
}
