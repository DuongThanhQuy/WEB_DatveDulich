using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TravelFinalProject.Models;
using TravelFinalProject.ModelViews;

namespace TravelFinalProject.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly Travel_DatabaseContext _context;
        public HomeController(ILogger<HomeController> logger, Travel_DatabaseContext context)
		{
			_logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            HomeViewVM model = new HomeViewVM();

            var lsFlights = _context.DboFlights.AsNoTracking()
                .Where(x => x.Active == true && x.HomeFlag == true)
                .OrderByDescending(x => x.DateCreated)
                .Take(6)
                .ToList();

            List<ServiceHomeVM> lsFlightViews = new List<ServiceHomeVM>();

            var lsTours = _context.DboTours.AsNoTracking()
                .Where(x => x.Active == true && x.HomeFlag == true)
                .OrderByDescending(x => x.DateCreated)
                .Take(8)
                .ToList();

            List<ServiceHomeVM> lsTourViews = new List<ServiceHomeVM>();

            var lsHotels = _context.DboHotels.AsNoTracking()
                .Where(x => x.Active == true && x.HomeFlag == true)
                .OrderByDescending(x => x.DateCreated)
                .Take(6)
                .ToList();

            List<ServiceHomeVM> lsHotelViews = new List<ServiceHomeVM>();

            var lsTras = _context.DboTransports.AsNoTracking()
                .Where(x => x.Active == true && x.HomeFlag == true)
                .OrderByDescending(x => x.DateCreated)
                .Take(3)
                .ToList();

            List<ServiceHomeVM> lsTraViews = new List<ServiceHomeVM>();

            var news = _context.DboNews
                    .AsNoTracking()
                    .Where(x => x.Published == true && x.IsNewfeed == true)
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(3)
                    .ToList();
            model.Flights = lsFlightViews;
            ViewBag.AllFlights = lsFlights;
            model.Tours = lsTourViews;
            ViewBag.AllTours = lsTours;
            model.Hotels = lsHotelViews;
            ViewBag.AllHotels = lsHotels;
            model.Transports = lsTraViews;
            ViewBag.AllTras = lsTras;
            model.News = news;
            ViewBag.AllTours = lsTours;
            model.News = news;
            return View(model);
        }


        public IActionResult Gallery()
        {
            return View();
        }
        
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
