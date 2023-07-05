using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using TravelFinalProject.Helpper;
using TravelFinalProject.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using AspNetCoreHero.ToastNotification.Notyf;

namespace TravelFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDboTransportsController : Controller
    {
        private readonly Travel_DatabaseContext _context;
        public INotyfService _notyfService { get; }
        public AdminDboTransportsController(Travel_DatabaseContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

		// GET: Admin/AdminDboTransports
		public IActionResult Index(int page = 1, int CatTraID = 0)
		{
			var pageNumber = page;
			var pageSize = 20;

            List<DboTransport> lsTransports = new List<DboTransport>();
            if (CatTraID != 0)
            {
				lsTransports = _context.DboTransports.AsNoTracking().Where(x=>x.CatTraId==CatTraID).Include(x => x.CatTra).OrderByDescending(x => x.TransportId).ToList();
			}
            else
            {
				lsTransports = _context.DboTransports.AsNoTracking().Include(x => x.CatTra).OrderByDescending(x => x.TransportId).ToList();
			}
			
			PagedList<DboTransport> models = new PagedList<DboTransport>(lsTransports.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentCateTraID = CatTraID;
			ViewBag.CurrentPage = pageNumber;
			ViewData["CategoriesTras"] = new SelectList(_context.DboCategoriesTras, "CatTraId", "CatTraName", CatTraID);
			return View(models);
		}

		public IActionResult Filtter(int CatTraID = 0)
		{
           
			var url = $"/Admin/AdminDboTransports?CatTraID={CatTraID}";
			if (CatTraID == 0)
			{
				url = $"/Admin/AdminDboTransports";
			}
			return Json(new { status = "success", redirectUrl = url });
		}

		// GET: Admin/AdminDboTransports/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboTransport = await _context.DboTransports
                .Include(d => d.CatTra)
                .FirstOrDefaultAsync(m => m.TransportId == id);
            if (dboTransport == null)
            {
                return NotFound();
            }

            return View(dboTransport);
        }

        // GET: Admin/AdminDboTransports/Create
        public IActionResult Create()
        {
            ViewData["CategoriesTras"] = new SelectList(_context.DboCategoriesTras, "CatTraId", "CatTraName");
            return View();
        }

        // POST: Admin/AdminDboTransports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransportId,TransportName,ShortDesc,Description,CatTraId,Price,Discount,picture,Video,DateCreated,DateModified,BestSellers,HomeFlag,Active,Tags,Title,Alias,MetaDesc,MetaKey,UnitslnStock")] DboTransport dboTransport, Microsoft.AspNetCore.Http.IFormFile fPicture)
        {
            if (ModelState.IsValid)
            {
                    if (fPicture != null)
                    {

                        string extension = Path.GetExtension(fPicture.FileName);
                        string picture = Utilities.SEOUrl(dboTransport.TransportName) + extension;

                        dboTransport.Picture = await Utilities.UploadFile(fPicture, @"transports", picture.ToLower());
                    }

                    if (string.IsNullOrEmpty(dboTransport.Picture)) dboTransport.Picture = "default.jpg";
                    dboTransport.Alias = Utilities.SEOUrl(dboTransport.TransportName);
                    dboTransport.DateModified = DateTime.Now;
                    dboTransport.DateCreated = DateTime.Now;

                    _context.Add(dboTransport);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Add new success");
                    return RedirectToAction(nameof(Index));


            }
            ViewData["CategoriesTras"] = new SelectList(_context.DboCategoriesTras, "CatTraId", "CatTraName", dboTransport.CatTraId);
            return View(dboTransport);
        }

        // GET: Admin/AdminDboTransports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboTransport = await _context.DboTransports.FindAsync(id);
            if (dboTransport == null)
            {
                return NotFound();
            }
            ViewData["CategoriesTras"] = new SelectList(_context.DboCategoriesTras, "CatTraId", "CatTraName", dboTransport.CatTraId);
            return View(dboTransport);
        }

        // POST: Admin/AdminDboTransports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransportId,TransportName,ShortDesc,Description,CatTraId,Price,Discount,picture,Video,DateCreated,DateModified,BestSellers,HomeFlag,Active,Tags,Title,Alias,MetaDesc,MetaKey,UnitslnStock")] DboTransport dboTransport, Microsoft.AspNetCore.Http.IFormFile fPicture)
        {
            if (id != dboTransport.TransportId)
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
                        string picture = Utilities.SEOUrl(dboTransport.TransportName) + extension; 
                        dboTransport.Picture = await Utilities.UploadFile(fPicture, @"transports", picture.ToLower());
                    }

                    if (string.IsNullOrEmpty(dboTransport.Picture)) dboTransport.Picture = "default.jpg";
                    dboTransport.Alias = Utilities.SEOUrl(dboTransport.TransportName);

                    _context.Update(dboTransport);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Successful update");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DboTransportExists(dboTransport.TransportId))
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
            ViewData["CategoriesTras"] = new SelectList(_context.DboCategoriesTras, "CatTraId", "CatTraName", dboTransport.CatTraId);
            return View(dboTransport);
        }

        // GET: Admin/AdminDboTransports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboTransport = await _context.DboTransports
                .Include(d => d.CatTra)
                .FirstOrDefaultAsync(m => m.TransportId == id);
            if (dboTransport == null)
            {
                return NotFound();
            }

            return View(dboTransport);
        }

        // POST: Admin/AdminDboTransports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dboTransport = await _context.DboTransports.FindAsync(id);
            _context.DboTransports.Remove(dboTransport);
            await _context.SaveChangesAsync();
            _notyfService.Success("Successful delete");
            return RedirectToAction(nameof(Index));
        }

        private bool DboTransportExists(int id)
        {
            return _context.DboTransports.Any(e => e.TransportId == id);
        }
    }
}
