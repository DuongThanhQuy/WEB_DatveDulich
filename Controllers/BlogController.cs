using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PagedList.Core;
using TravelFinalProject.Models;

namespace TravelFinalProject.Controllers
{
	public class BlogController : Controller
	{
		private readonly Travel_DatabaseContext _context;
		public BlogController(Travel_DatabaseContext context)
		{
			_context = context;
		}

        [Route("blogs.html", Name = ("Blog"))]
        public IActionResult Index(int? page)
		{
			var pageNumber = page == null || page <= 0 ? 1 : page.Value;
			var pageSize = 20;
			var lsNews = _context.DboNews.AsNoTracking().OrderByDescending(x => x.PostId);
			PagedList<DboNews> models = new PagedList<DboNews>(lsNews, pageNumber, pageSize);
			ViewBag.CurrentPage = pageNumber;
			return View(models);
		}

        [Route("/blogs-detail/{Alias}-{id}.html", Name = "Details")]
        public IActionResult Details(int id)
		{
			var news = _context.DboNews.AsNoTracking().SingleOrDefault(x => x.PostId == id);
			if (news == null)
			{
				return RedirectToAction("Index");
			}
			var lsRecentPost = _context.DboNews
				.AsNoTracking()
				.Where(x => x.Published == true && x.PostId != id)
				.Take(3)
				.OrderByDescending(x => x.CreatedDate).ToList();
			ViewBag.RecentPost = lsRecentPost;
			return View(news);
		}
	}
}
