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
    public class AdminDboFlightsController : Controller
    {
        private readonly Travel_DatabaseContext _context;
        public INotyfService _notyfService { get; }
        public AdminDboFlightsController(Travel_DatabaseContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminDboFlights
        public IActionResult Index(int page = 1, int CatFlightID = 0)
        {
            var pageNumber = page;
            var pageSize = 20;

            List<DboFlight> lsFlights = new List<DboFlight>();
            if (CatFlightID != 0)
            {
                lsFlights = _context.DboFlights.AsNoTracking().Where(x => x.CatFlightId == CatFlightID).Include(x => x.CatFlight).OrderByDescending(x => x.FlightId).ToList();
            }
            else
            {
                lsFlights = _context.DboFlights.AsNoTracking().Include(x => x.CatFlight).OrderByDescending(x => x.FlightId).ToList();
            }

            PagedList<DboFlight> models = new PagedList<DboFlight>(lsFlights.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentCateFlightID = CatFlightID;
            ViewBag.CurrentPage = pageNumber;
            ViewData["CategoriesFlight"] = new SelectList(_context.DboCategoriesFlights, "CatFlightId", "CatFlightName", CatFlightID);
            return View(models);
        }

        public IActionResult Filtter(int CatFlightID = 0)
        {

            var url = $"/Admin/AdminDboFlights?CatFlightID={CatFlightID}";
            if (CatFlightID == 0)
            {
                url = $"/Admin/AdminDboFlights";
            }
            return Json(new { status = "success", redirectUrl = url });
        }
        // GET: Admin/AdminDboFlights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboFlight = await _context.DboFlights
                .Include(d => d.CatFlight)
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (dboFlight == null)
            {
                return NotFound();
            }

            return View(dboFlight);
        }

        // GET: Admin/AdminDboFlights/Create
        public IActionResult Create()
        {
            ViewData["CategoriesFlight"] = new SelectList(_context.DboCategoriesFlights, "CatFlightId", "CatFlightName");
            return View();
        }

        // POST: Admin/AdminDboFlights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightId,FlightName,ShortDesc,Description,CatFlightId,Price,Discount,picture,Video,DateCreated,DateModified,BestSellers,HomeFlag,Active,Tags,Title,Alias,MetaDesc,MetaKey,UnitslnStock,From,To,TotalTime,Seats")] DboFlight dboFlight, Microsoft.AspNetCore.Http.IFormFile fPicture)
        {
            if (ModelState.IsValid)
            {
				if (fPicture != null)
				{

					string extension = Path.GetExtension(fPicture.FileName);
					string pictureName = Utilities.SEOUrl(dboFlight.Title) + extension;

					dboFlight.Picture = await Utilities.UploadFile(fPicture, @"pages", pictureName.ToLower());
				}

				if (string.IsNullOrEmpty(dboFlight.Picture)) dboFlight.Picture = "default.jpg";
				dboFlight.Alias = Utilities.SEOUrl(dboFlight.Title);
				dboFlight.DateModified = DateTime.Now;
				dboFlight.DateCreated = DateTime.Now;

				_context.Add(dboFlight);
				await _context.SaveChangesAsync();
				_notyfService.Success("Add new success");
				return RedirectToAction(nameof(Index));
			}
            ViewData["CategoriesFlight"] = new SelectList(_context.DboCategoriesFlights, "CatFlightId", "CatFlightName", dboFlight.CatFlightId);
            return View(dboFlight);
        }

        // GET: Admin/AdminDboFlights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboFlight = await _context.DboFlights.FindAsync(id);
            if (dboFlight == null)
            {
                return NotFound();
            }
            ViewData["CategoriesFlight"] = new SelectList(_context.DboCategoriesFlights, "CatFlightId", "CatFlightName", dboFlight.CatFlightId);
            return View(dboFlight);
        }

        // POST: Admin/AdminDboFlights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightId,FlightName,ShortDesc,Description,CatFlightId,Price,Discount,picture,Video,DateCreated,DateModified,BestSellers,HomeFlag,Active,Tags,Title,Alias,MetaDesc,MetaKey,UnitslnStock,From,To,TotalTime,Seats")] DboFlight dboFlight, Microsoft.AspNetCore.Http.IFormFile fPicture)
        {
            if (id != dboFlight.FlightId)
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
                        string pictureName = Utilities.SEOUrl(dboFlight.Title) + extension;

                        dboFlight.Picture = await Utilities.UploadFile(fPicture, @"pages", pictureName.ToLower());
                    }

                    if (string.IsNullOrEmpty(dboFlight.Picture)) dboFlight.Picture = "default.jpg";
                    dboFlight.Alias = Utilities.SEOUrl(dboFlight.Title);

                    _context.Update(dboFlight);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Successful update");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DboFlightExists(dboFlight.FlightId))
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
            ViewData["CategoriesFlight"] = new SelectList(_context.DboCategoriesFlights, "CatFlightId", "CatFlightName", dboFlight.CatFlightId);
            return View(dboFlight);
        }

        // GET: Admin/AdminDboFlights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboFlight = await _context.DboFlights
                .Include(d => d.CatFlight)
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (dboFlight == null)
            {
                return NotFound();
            }

            return View(dboFlight);
        }

        // POST: Admin/AdminDboFlights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dboFlight = await _context.DboFlights.FindAsync(id);
            _context.DboFlights.Remove(dboFlight);
            await _context.SaveChangesAsync();
            _notyfService.Success("Successful delete");
            return RedirectToAction(nameof(Index));
        }

        private bool DboFlightExists(int id)
        {
            return _context.DboFlights.Any(e => e.FlightId == id);
        }
    }
}
