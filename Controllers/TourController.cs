using System.Linq;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using TravelFinalProject.Models;
namespace TravelFinalProject.Controllers
{
	public class TourController : Controller
	{
        private readonly Travel_DatabaseContext _context;

        public TourController(Travel_DatabaseContext context)
        {
            _context = context;
        }
        [Route("tour.html", Name = ("Tour"))]
        public IActionResult Index(int? page)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 10;
                var lsTours = _context.DboTours
                    .AsNoTracking()
                    .OrderBy(x => x.DateCreated);
                PagedList<DboTour> models = new PagedList<DboTour>(lsTours, pageNumber, pageSize);

                ViewBag.CurrentPage = pageNumber;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }

        [Route("categoriesTour/{Alias}", Name = ("ListTour"))]
        public IActionResult List(string Alias, int page = 1)
        {
            try
            {
                var pageSize = 10;
                var CateHot = _context.DboCategoriesTours.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);

                var lsTours = _context.DboTours
                    .AsNoTracking()
                    .Where(x => x.CatTourId == CateHot.CatTourId)
                    .OrderByDescending(x => x.DateCreated);
                PagedList<DboTour> models = new PagedList<DboTour>(lsTours, page, pageSize);
                ViewBag.CurrentPage = page;
                ViewBag.CurrentCat = CateHot;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }
        
        [Route("/tour-detail/{Alias}-{id}.html", Name = "TourDetails")]
        public IActionResult Details(int id)
        {
           
                var Tour = _context.DboTours.AsNoTracking().SingleOrDefault(x => x.TourId == id);
            if (Tour == null)
                {
                    return RedirectToAction("Index");
                }
                var lsTour = _context.DboTours
                          .AsNoTracking()
                          .Where(x => x.CatTourId == Tour.CatTourId && x.TourId != id && x.Active == true)
                          .Take(4)
                          .OrderByDescending(x => x.DateCreated)
                          .ToList();
                ViewBag.TourL = lsTour;
                return View(Tour);
            
           


        }
    }
}
