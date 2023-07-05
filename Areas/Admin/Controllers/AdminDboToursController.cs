using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using TravelFinalProject.Helpper;
using TravelFinalProject.Models;

namespace TravelFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDboToursController : Controller
    {
        private readonly Travel_DatabaseContext _context;
		public INotyfService _notyfService { get; }
		public AdminDboToursController(Travel_DatabaseContext context, INotyfService notyfService)
		{
			_context = context;
			_notyfService = notyfService;
		}

		// GET: Admin/AdminDboTours
		public IActionResult Index(int page = 1, int CatTourID = 0)
		{
			var pageNumber = page;
			var pageSize = 20;

			List<DboTour> lsTours = new List<DboTour>();
			if (CatTourID != 0)
			{
				lsTours = _context.DboTours.AsNoTracking().Where(x => x.CatTourId == CatTourID).Include(x => x.CatTour).OrderByDescending(x => x.TourId).ToList();
			}
			else
			{
				lsTours = _context.DboTours.AsNoTracking().Include(x => x.CatTour).OrderByDescending(x => x.TourId).ToList();
			}

			PagedList<DboTour> models = new PagedList<DboTour>(lsTours.AsQueryable(), pageNumber, pageSize);
			ViewBag.CurrentCateID = CatTourID;
			ViewBag.CurrentPage = pageNumber;
			ViewData["CategoriesTour"] = new SelectList(_context.DboCategoriesTours, "CatTourId", "CatTourName", CatTourID);
			return View(models);
		}

		public IActionResult Filtter(int CatTourID = 0)
		{

			var url = $"/Admin/AdminDboTours?CatTourID={CatTourID}";
			if (CatTourID == 0)
			{
				url = $"/Admin/AdminDboTours";
			}
			return Json(new { status = "success", redirectUrl = url });
		}

		// GET: Admin/AdminDboTours/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboTour = await _context.DboTours
                .Include(d => d.CatTour)
                .FirstOrDefaultAsync(m => m.TourId == id);
            if (dboTour == null)
            {
                return NotFound();
            }

            return View(dboTour);
        }

        // GET: Admin/AdminDboTours/Create
        public IActionResult Create()
        {
            ViewData["CategoriesTour"] = new SelectList(_context.DboCategoriesTours, "CatTourId", "CatTourName");
            return View();
        }

        // POST: Admin/AdminDboTours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TourId,TourName,ShortDesc,Description,CatTourId,picture,Price,Discount,Video,DateCreated,DateModified,BestSellers,HomeFlag,Active,Tags,Title,Alias,MetaDesc,MetaKey,UnitslnStock,Seats,Amount,Duration")] DboTour dboTour, Microsoft.AspNetCore.Http.IFormFile fPicture)
		{
            if (ModelState.IsValid)
            {
				if (fPicture != null)
				{

					string extension = Path.GetExtension(fPicture.FileName);
					string pictureName = Utilities.SEOUrl(dboTour.Title) + extension;

					dboTour.Picture = await Utilities.UploadFile(fPicture, @"pages", pictureName.ToLower());
				}

				if (string.IsNullOrEmpty(dboTour.Picture)) dboTour.Picture = "default.jpg";
				dboTour.Alias = Utilities.SEOUrl(dboTour.Title);
				dboTour.DateModified = DateTime.Now;
				dboTour.DateCreated = DateTime.Now;

				_context.Add(dboTour);
                await _context.SaveChangesAsync();
				_notyfService.Success("Add new success");
				return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriesTour"] = new SelectList(_context.DboCategoriesTours, "CatTourId", "CatTourName", dboTour.CatTourId);
            return View(dboTour);
        }

        // GET: Admin/AdminDboTours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboTour = await _context.DboTours.FindAsync(id);
            if (dboTour == null)
            {
                return NotFound();
            }
            ViewData["CategoriesTour"] = new SelectList(_context.DboCategoriesTours, "CatTourId", "CatTourName", dboTour.CatTourId);
            return View(dboTour);
        }

        // POST: Admin/AdminDboTours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TourId,TourName,ShortDesc,Description,CatTourId,picture,Price,Discount,Video,DateCreated,DateModified,BestSellers,HomeFlag,Active,Tags,Title,Alias,MetaDesc,MetaKey,UnitslnStock,Seats,Amount,Duration")] DboTour dboTour, Microsoft.AspNetCore.Http.IFormFile fPicture)
		{
            if (id != dboTour.TourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
					if (fPicture != null)
					{

						string extension = Path.GetExtension(fPicture.FileName);
						string pictureName = Utilities.SEOUrl(dboTour.Title) + extension;

						dboTour.Picture = await Utilities.UploadFile(fPicture, @"pages", pictureName.ToLower());
					}

					if (string.IsNullOrEmpty(dboTour.Picture)) dboTour.Picture = "default.jpg";
					dboTour.Alias = Utilities.SEOUrl(dboTour.Title);
					dboTour.DateModified = DateTime.Now;
					dboTour.DateCreated = DateTime.Now;

					_context.Update(dboTour);
					_notyfService.Success("Successful update");
					await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DboTourExists(dboTour.TourId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriesTour"] = new SelectList(_context.DboCategoriesTours, "CatTourId", "CatTourName", dboTour.CatTourId);
            return View(dboTour);
        }

        // GET: Admin/AdminDboTours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboTour = await _context.DboTours
                .Include(d => d.CatTour)
                .FirstOrDefaultAsync(m => m.TourId == id);
            if (dboTour == null)
            {
                return NotFound();
            }

            return View(dboTour);
        }

        // POST: Admin/AdminDboTours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dboTour = await _context.DboTours.FindAsync(id);
            _context.DboTours.Remove(dboTour);
            await _context.SaveChangesAsync();
			_notyfService.Success("Successful delete");
			return RedirectToAction(nameof(Index));
        }

        private bool DboTourExists(int id)
        {
            return _context.DboTours.Any(e => e.TourId == id);
        }
    }
}
