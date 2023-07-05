using System.Linq;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using TravelFinalProject.Models;

namespace TravelFinalProject.Controllers
{
	public class FlightController : Controller
	{
        private readonly Travel_DatabaseContext _context;

        public FlightController(Travel_DatabaseContext context)
        {
            _context = context;
        }
        [Route("flight.html", Name = ("Flight"))]
        public IActionResult Index(int? page)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 10;
                var lsFlights = _context.DboFlights
                    .AsNoTracking()
                    .OrderBy(x => x.DateCreated);
                PagedList<DboFlight> models = new PagedList<DboFlight>(lsFlights, pageNumber, pageSize);

                ViewBag.CurrentPage = pageNumber;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }

        [Route("categoriesFlight/{Alias}-{id}.html", Name = ("ListFlight"))]
        public IActionResult List(string Alias, int page = 1)
        {
            try
            {
                var pageSize = 10;
                var CateFli = _context.DboCategoriesFlights.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);

                var lsFlights = _context.DboFlights
                    .AsNoTracking()
                    .Where(x => x.CatFlightId == CateFli.CatFlightId)
                    .OrderByDescending(x => x.DateCreated);
                PagedList<DboFlight> models = new PagedList<DboFlight>(lsFlights, page, pageSize);
                ViewBag.CurrentPage = page;
                ViewBag.CurrentCat = CateFli;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }

        [Route("/flight-detail/{Alias}-{id}.html", Name = ("FlightDetails"))]
        public IActionResult Details(int id)
        {
            try
            {
                var flight = _context.DboFlights.Include(x => x.CatFlight).FirstOrDefault(x => x.FlightId == id);
                if (flight == null)
                {
                    return RedirectToAction("Index");
                }
                var lsFlight = _context.DboFlights
                    .AsNoTracking()
                    .Where(x => x.CatFlightId == flight.CatFlightId && x.FlightId != id && x.Active == true)
                    .Take(4)
                    .OrderByDescending(x => x.DateCreated)
                    .ToList();
                ViewBag.FlightL = lsFlight;
                return View(flight);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }

    }
}
