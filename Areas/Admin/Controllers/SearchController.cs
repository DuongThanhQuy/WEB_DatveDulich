using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelFinalProject.Models;

namespace TravelFinalProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SearchController : Controller
	{
		private readonly Travel_DatabaseContext _context;

		public SearchController(Travel_DatabaseContext context)
		{
			_context = context;
		}

		[HttpPost]
		public IActionResult FindTransport(string keyword)
		{
			List<DboTransport> ls = new List<DboTransport>();
			if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
			{
				return PartialView("ListTranportsSearchPartial", null);
			}
			ls = _context.DboTransports.AsNoTracking()
								  .Include(a => a.CatTra)
								  .Where(x => x.TransportName.Contains(keyword))
								  .OrderByDescending(x => x.TransportName)
								  .Take(10)
								  .ToList();
			if (ls == null)
			{
				return PartialView("ListTranportsSearchPartial", null);
			}
			else
			{
				return PartialView("ListTranportsSearchPartial", ls);
			}
		}
		[HttpPost]
		public IActionResult FindHotel(string keyword)
		{
			List<DboHotel> ls = new List<DboHotel>();
			if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
			{
				return PartialView("ListHotelsSearchPartial", null);
			}
			ls = _context.DboHotels.AsNoTracking()
								  .Include(a => a.CatHotel)
								  .Where(x => x.HotelName.Contains(keyword))
								  .OrderByDescending(x => x.HotelName)
								  .Take(10)
								  .ToList();
			if (ls == null)
			{
				return PartialView("ListHotelsSearchPartial", null);
			}
			else
			{
				return PartialView("ListHotelsSearchPartial", ls);
			}
		}
		[HttpPost]
		public IActionResult FindTour(string keyword)
		{
			List<DboTour> ls = new List<DboTour>();
			if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
			{
				return PartialView("ListToursSearchPartial", null);
			}
			ls = _context.DboTours.AsNoTracking()
								  .Include(a => a.CatTour)
								  .Where(x => x.TourName.Contains(keyword))
								  .OrderByDescending(x => x.TourName)
								  .Take(10)
								  .ToList();
			if (ls == null)
			{
				return PartialView("ListToursSearchPartial", null);
			}
			else
			{
				return PartialView("ListToursSearchPartial", ls);
			}
		}
		[HttpPost]
		public IActionResult FindFlight(string keyword)
		{
			List<DboFlight> ls = new List<DboFlight>();
			if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
			{
				return PartialView("ListFlightsSearchPartial", null);
			}
			ls = _context.DboFlights.AsNoTracking()
								  .Include(a => a.CatFlight)
								  .Where(x => x.FlightName.Contains(keyword))
								  .OrderByDescending(x => x.FlightName)
								  .Take(10)
								  .ToList();
			if (ls == null)
			{
				return PartialView("ListFlightsSearchPartial", null);
			}
			else
			{
				return PartialView("ListFlightsSearchPartial", ls);
			}
		}
	}
}
