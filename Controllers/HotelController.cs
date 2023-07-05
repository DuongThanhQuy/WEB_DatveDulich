using System.Linq;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using TravelFinalProject.Models;

namespace TravelFinalProject.Controllers
{
	public class HotelController : Controller
	{
        private readonly Travel_DatabaseContext _context;

        public HotelController(Travel_DatabaseContext context)
        {
            _context = context;
        }
        [Route("hotel.html", Name = ("Hotel"))]
        public IActionResult Index(int? page)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 10;
                var lsHotels = _context.DboHotels
                    .AsNoTracking()
                    .OrderBy(x => x.DateCreated);
                PagedList<DboHotel> models = new PagedList<DboHotel>(lsHotels, pageNumber, pageSize);

                ViewBag.CurrentPage = pageNumber;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }

        [Route("categoriesHotel/{Alias}-{id}.html", Name = ("ListHotel"))]
        public IActionResult List(string Alias, int page = 1)
        {
            try
            {
                var pageSize = 10;
                var CateHot = _context.DboCategoriesHotels.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);

                var lsHotels = _context.DboHotels
                    .AsNoTracking()
                    .Where(x => x.CatHotelId == CateHot.CatHotelId)
                    .OrderByDescending(x => x.DateCreated);
                PagedList<DboHotel> models = new PagedList<DboHotel>(lsHotels, page, pageSize);
                ViewBag.CurrentPage = page;
                ViewBag.CurrentCat = CateHot;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }

        [Route("/hotel-detail/{Alias}-{id}.html", Name = ("HotelDetails"))]
        public IActionResult Details(int id)
        {
            try
            {
                var Hotel = _context.DboHotels.Include(x => x.CatHotel).FirstOrDefault(x => x.HotelId == id);
                if (Hotel == null)
                {
                    return RedirectToAction("Index");
                }
                var lsHotel = _context.DboHotels
                    .AsNoTracking()
                    .Where(x => x.CatHotelId == Hotel.CatHotelId && x.HotelId != id && x.Active == true)
                    .Take(4)
                    .OrderByDescending(x => x.DateCreated)
                    .ToList();
                ViewBag.HotelL = lsHotel;
                return View(Hotel);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }
    }
}
