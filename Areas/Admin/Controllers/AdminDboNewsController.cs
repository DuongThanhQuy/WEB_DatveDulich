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
    public class AdminDboNewsController : Controller
    {
        private readonly Travel_DatabaseContext _context;
        public INotyfService _notyfService { get; }
        public AdminDboNewsController(Travel_DatabaseContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

		// GET: Admin/AdminDboNews
		public IActionResult Index(int? page)
		{
            var collection = _context.DboNews.AsNoTracking().ToList();
            foreach (var item in collection)
            {
                if (item.CreatedDate == null)
                {
                    item.CreatedDate = DateTime.Now;
                    _context.Update(item);
                    _context.SaveChanges();
                }
            }

            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
			var pageSize = 20;
			var lsNews = _context.DboNews.AsNoTracking().OrderByDescending(x => x.PostId);
			PagedList<DboNews> models = new PagedList<DboNews>(lsNews, pageNumber, pageSize);
			ViewBag.CurrentPage = pageNumber;
			return View(models);
		}

		// GET: Admin/AdminDboNews/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboNews = await _context.DboNews
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (dboNews == null)
            {
                return NotFound();
            }

            return View(dboNews);
        }

        // GET: Admin/AdminDboNews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminDboNews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,Title,Scontents,Contents,Picture,Published,Alias,CreatedDate,Author,AccountId,Tags,CatId,IsHot,IsNewfeed,MetaDesc,MetaKey,Views")] DboNews dboNews, Microsoft.AspNetCore.Http.IFormFile fPicture)
        {
            if (ModelState.IsValid)
            {
                if (fPicture != null)
                {

                    string extension = Path.GetExtension(fPicture.FileName);
                    string pictureName = Utilities.SEOUrl(dboNews.Title) + extension;

                    dboNews.Picture = await Utilities.UploadFile(fPicture, @"pages", pictureName.ToLower());
                }

                if (string.IsNullOrEmpty(dboNews.Picture)) dboNews.Picture = "default.jpg";
                dboNews.Alias = Utilities.SEOUrl(dboNews.Title);
                dboNews.CreatedDate = DateTime.Now;
                _context.Add(dboNews);
                await _context.SaveChangesAsync();
                _notyfService.Success("Add new success");
                return RedirectToAction(nameof(Index));
            }
            return View(dboNews);
        }

        // GET: Admin/AdminDboNews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboNews = await _context.DboNews.FindAsync(id);
            if (dboNews == null)
            {
                return NotFound();
            }
            return View(dboNews);
        }

        // POST: Admin/AdminDboNews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,Title,Scontents,Contents,Picture,Published,Alias,CreatedDate,Author,AccountId,Tags,CatId,IsHot,IsNewfeed,MetaDesc,MetaKey,Views")] DboNews dboNews, Microsoft.AspNetCore.Http.IFormFile fPicture)
        {
            if (id != dboNews.PostId)
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
                        string pictureName = Utilities.SEOUrl(dboNews.Title) + extension;

                        dboNews.Picture = await Utilities.UploadFile(fPicture, @"pages", pictureName.ToLower());
                    }

                    if (string.IsNullOrEmpty(dboNews.Picture)) dboNews.Picture = "default.jpg";
                    dboNews.Alias = Utilities.SEOUrl(dboNews.Title);
                    
                    _context.Update(dboNews);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Successful update");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DboNewsExists(dboNews.PostId))
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
            return View(dboNews);
        }

        // GET: Admin/AdminDboNews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboNews = await _context.DboNews
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (dboNews == null)
            {
                return NotFound();
            }

            return View(dboNews);
        }

        // POST: Admin/AdminDboNews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dboNews = await _context.DboNews.FindAsync(id);
            _context.DboNews.Remove(dboNews);
            await _context.SaveChangesAsync();
            _notyfService.Success("Successful delete");
            return RedirectToAction(nameof(Index));
        }

        private bool DboNewsExists(int id)
        {
            return _context.DboNews.Any(e => e.PostId == id);
        }
    }
}
