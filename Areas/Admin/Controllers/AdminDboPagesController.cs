using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using TravelFinalProject.Helpper;
using TravelFinalProject.Models;

namespace TravelFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDboPagesController : Controller
    {
        private readonly Travel_DatabaseContext _context;
        public INotyfService _notyfService { get; }
        public AdminDboPagesController(Travel_DatabaseContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

		// GET: Admin/AdminDboPages
		public IActionResult Index(int? page)
		{
			var pageNumber = page == null || page <= 0 ? 1 : page.Value;
			var pageSize = 20;
			var lsPages = _context.DboPages.AsNoTracking().OrderByDescending(x => x.PageId);
			PagedList<DboPage> models = new PagedList<DboPage>(lsPages, pageNumber, pageSize);
			ViewBag.CurrentPage = pageNumber;
			return View(models);
		}

		// GET: Admin/AdminDboPages/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboPage = await _context.DboPages
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (dboPage == null)
            {
                return NotFound();
            }

            return View(dboPage);
        }

        // GET: Admin/AdminDboPages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminDboPages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PageId,PageName,Contents,Content2,Content3,Content4,Picture,Published,Title,Title2,Title3,Title4,MetaDesc,MetaKey,Alias,CreateDate,Ordering")] DboPage dboPage, Microsoft.AspNetCore.Http.IFormFile fPicture)
        {
            if (ModelState.IsValid)
            {

                if (fPicture != null)
                {

                    string extension = Path.GetExtension(fPicture.FileName);
                    string pictureName = Utilities.SEOUrl(dboPage.PageName) + extension;
                    
                    dboPage.Picture = await Utilities.UploadFile(fPicture, @"pages", pictureName.ToLower());
                }

                if (string.IsNullOrEmpty(dboPage.Picture)) dboPage.Picture = "default.jpg";
                dboPage.Alias = Utilities.SEOUrl(dboPage.PageName);
                _context.Add(dboPage);
                await _context.SaveChangesAsync();
                _notyfService.Success("Add new success"); 
                return RedirectToAction(nameof(Index));
            }
            return View(dboPage);
        }

        // GET: Admin/AdminDboPages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboPage = await _context.DboPages.FindAsync(id);
            if (dboPage == null)
            {
                return NotFound();
            }
            return View(dboPage);
        }

        // POST: Admin/AdminDboPages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PageId,PageName,Contents,Content2,Content3,Content4,Picture,Published,Title,Title2,Title3,Title4,MetaDesc,MetaKey,Alias,CreateDate,Ordering")] DboPage dboPage, Microsoft.AspNetCore.Http.IFormFile fPicture)
        {
            if (id != dboPage.PageId)
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
                        string pictureName = Utilities.SEOUrl(dboPage.PageName) + extension;

                        dboPage.Picture = await Utilities.UploadFile(fPicture, @"pages", pictureName.ToLower());
                    }

                    if (string.IsNullOrEmpty(dboPage.Picture)) dboPage.Picture = "default.jpg";

                    dboPage.Alias = Utilities.SEOUrl(dboPage.PageName);
                    _context.Update(dboPage);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Successful update");   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DboPageExists(dboPage.PageId))
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
            return View(dboPage);
        }

        // GET: Admin/AdminDboPages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboPage = await _context.DboPages
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (dboPage == null)
            {
                return NotFound();
            }

            return View(dboPage);
        }

        // POST: Admin/AdminDboPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dboPage = await _context.DboPages.FindAsync(id);
            _context.DboPages.Remove(dboPage);
            await _context.SaveChangesAsync();
            _notyfService.Success("Successful delete");
            return RedirectToAction(nameof(Index));
        }

        private bool DboPageExists(int id)
        {
            return _context.DboPages.Any(e => e.PageId == id);
        }
    }
}
