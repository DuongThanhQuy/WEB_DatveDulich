using System.Linq;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using TravelFinalProject.Models;

namespace TravelFinalProject.Controllers
{
    public class TransportController : Controller
    {
        private readonly Travel_DatabaseContext _context;

        public TransportController(Travel_DatabaseContext context)
        {
            _context = context;
        }
        [Route("transport.html", Name = ("Transport"))]
        public IActionResult Index(int? page)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 10;
                var lsTransports = _context.DboTransports
                    .AsNoTracking()
                    .OrderBy(x => x.DateCreated);
                PagedList<DboTransport> models = new PagedList<DboTransport>(lsTransports, pageNumber, pageSize);

                ViewBag.CurrentPage = pageNumber;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }

        [Route("categoriesTour/{Alias}-{id}.html", Name = ("ListTransport"))]
        public IActionResult List(string Alias, int page = 1)
        {
            try
            {
                var pageSize = 10;
                var CateTra = _context.DboCategoriesTras.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);

                var lsTransports = _context.DboTransports
                    .AsNoTracking()
                    .Where(x => x.CatTraId == CateTra.CatTraId)
                    .OrderByDescending(x => x.DateCreated);
                PagedList<DboTransport> models = new PagedList<DboTransport>(lsTransports, page, pageSize);
                ViewBag.CurrentPage = page;
                ViewBag.CurrentCat = CateTra;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }
       
        [Route("/transport-detail/{Alias}-{id}.html", Name = ("TransportDetails"))]
        public IActionResult Details(int id)
        {
           
                var transport = _context.DboTransports.Include(x => x.CatTra).FirstOrDefault(x => x.TransportId == id);
                if (transport == null)
                {
                    return RedirectToAction("Index");
                }
                var lsTransport = _context.DboTransports
                    .AsNoTracking()
                    .Where(x => x.CatTraId == transport.CatTraId && x.TransportId != id && x.Active == true)
                    .Take(4)
                    .OrderByDescending(x => x.DateCreated)
                    .ToList();
                ViewBag.TransportL = lsTransport;
                return View(transport);


        }
    }
}
