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
    public class AdminDboHotelsController : Controller
    {
        private readonly Travel_DatabaseContext _context;
		public INotyfService _notyfService { get; }
		public AdminDboHotelsController(Travel_DatabaseContext context, INotyfService notyfService)
        {
            _context = context;
			_notyfService = notyfService;
		}

		// GET: Admin/AdminDboHotels
		public IActionResult Index(int page = 1, int CatHotelID = 0)
		{
			var pageNumber = page;
			var pageSize = 20;

			List<DboHotel> lsHotels = new List<DboHotel>();
			if (CatHotelID != 0)
			{
				lsHotels = _context.DboHotels.AsNoTracking().Where(x => x.CatHotelId == CatHotelID).Include(x => x.CatHotel).OrderByDescending(x => x.HotelId).ToList();
			}
			else
			{
				lsHotels = _context.DboHotels.AsNoTracking().Include(x => x.CatHotel).OrderByDescending(x => x.HotelId).ToList();
			}

			PagedList<DboHotel> models = new PagedList<DboHotel>(lsHotels.AsQueryable(), pageNumber, pageSize);
			ViewBag.CurrentCateHotelID = CatHotelID;
			ViewBag.CurrentPage = pageNumber;
			ViewData["CategoriesHotel"] = new SelectList(_context.DboCategoriesHotels, "CatHotelId", "CatHotelName", CatHotelID);
			return View(models);
		}

		public IActionResult Filtter(int CatHotelID = 0)
		{

			var url = $"/Admin/AdminDboHotels?CatHotelID={CatHotelID}";
			if (CatHotelID == 0)
			{
				url = $"/Admin/AdminDboHotels";
			}
			return Json(new { status = "success", redirectUrl = url });
		}
		// GET: Admin/AdminDboHotels/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboHotel = await _context.DboHotels
                .Include(d => d.CatHotel)
                .FirstOrDefaultAsync(m => m.HotelId == id);
            if (dboHotel == null)
            {
                return NotFound();
            }

            return View(dboHotel);
        }

        // GET: Admin/AdminDboHotels/Create
        public IActionResult Create()
        {
            ViewData["CategoriesHotel"] = new SelectList(_context.DboCategoriesHotels, "CatHotelId", "CatHotelName");
            return View();
        }

        // POST: Admin/AdminDboHotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelId,HotelName,ShortDesc,Description,CatHotelId,Price,Discount,picture,Video,DateCreated,DateModified,BestSellers,HomeFlag,Active,Tags,Title,Alias,MetaDesc,MetaKey,UnitslnStock,Bed,Address")] DboHotel dboHotel, Microsoft.AspNetCore.Http.IFormFile fPicture)
        {
            if (ModelState.IsValid)
            {
				if (fPicture != null)
				{

					string extension = Path.GetExtension(fPicture.FileName);
					string pictureName = Utilities.SEOUrl(dboHotel.Title) + extension;

					dboHotel.Picture = await Utilities.UploadFile(fPicture, @"pages", pictureName.ToLower());
				}

				if (string.IsNullOrEmpty(dboHotel.Picture)) dboHotel.Picture = "default.jpg";
				dboHotel.Alias = Utilities.SEOUrl(dboHotel.Title);
				dboHotel.DateModified = DateTime.Now;
				dboHotel.DateCreated = DateTime.Now;

				_context.Add(dboHotel);
                await _context.SaveChangesAsync();
				_notyfService.Success("Add new success");
				return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriesHotel"] = new SelectList(_context.DboCategoriesHotels, "CatHotelId", "CatHotelName", dboHotel.CatHotelId);
            return View(dboHotel);
        }

        // GET: Admin/AdminDboHotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboHotel = await _context.DboHotels.FindAsync(id);
            if (dboHotel == null)
            {
                return NotFound();
            }
            ViewData["CategoriesHotel"] = new SelectList(_context.DboCategoriesHotels, "CatHotelId", "CatHotelName", dboHotel.CatHotelId);
            return View(dboHotel);
        }

        // POST: Admin/AdminDboHotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HotelId,HotelName,ShortDesc,Description,CatHotelId,Price,Discount,picture,Video,DateCreated,DateModified,BestSellers,HomeFlag,Active,Tags,Title,Alias,MetaDesc,MetaKey,UnitslnStock,Bed,Address")] DboHotel dboHotel, Microsoft.AspNetCore.Http.IFormFile fPicture)
        {
            if (id != dboHotel.HotelId)
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
						string pictureName = Utilities.SEOUrl(dboHotel.Title) + extension;

						dboHotel.Picture = await Utilities.UploadFile(fPicture, @"pages", pictureName.ToLower());
					}

					if (string.IsNullOrEmpty(dboHotel.Picture)) dboHotel.Picture = "default.jpg";
					dboHotel.Alias = Utilities.SEOUrl(dboHotel.Title);

					_context.Update(dboHotel);
                    await _context.SaveChangesAsync();
					_notyfService.Success("Successful update");
				}
                catch (DbUpdateConcurrencyException)
                {
                    if (!DboHotelExists(dboHotel.HotelId))
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
            ViewData["CategoriesHotel"] = new SelectList(_context.DboCategoriesHotels, "CatHotelId", "CatHotelName", dboHotel.CatHotelId);
            return View(dboHotel);
        }

        // GET: Admin/AdminDboHotels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboHotel = await _context.DboHotels
                .Include(d => d.CatHotel)
                .FirstOrDefaultAsync(m => m.HotelId == id);
            if (dboHotel == null)
            {
                return NotFound();
            }

            return View(dboHotel);
        }

        // POST: Admin/AdminDboHotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dboHotel = await _context.DboHotels.FindAsync(id);
            _context.DboHotels.Remove(dboHotel);
            await _context.SaveChangesAsync();
			_notyfService.Success("Successful delete");
			return RedirectToAction(nameof(Index));
        }

        private bool DboHotelExists(int id)
        {
            return _context.DboHotels.Any(e => e.HotelId == id);
        }
    }
}
