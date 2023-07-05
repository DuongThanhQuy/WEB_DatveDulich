using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using TravelFinalProject.Models;

namespace TravelFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDboCruisesController : Controller
    {
        private readonly Travel_DatabaseContext _context;

        public AdminDboCruisesController(Travel_DatabaseContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminDboCruises
        public IActionResult Index(int page = 1, int CatID = 0)
        {
            var pageNumber = page;
            var pageSize = 20;

            List<DboCruise> lsCruises = new List<DboCruise>();
            if (CatID != 0)
            {
                lsCruises = _context.DboCruises.AsNoTracking().Where(x => x.CatId == CatID).Include(x => x.Cat).OrderByDescending(x => x.CruiseId).ToList();
            }
            else
            {
                lsCruises = _context.DboCruises.AsNoTracking().Include(x => x.Cat).OrderByDescending(x => x.CruiseId).ToList();
            }

            PagedList<DboCruise> models = new PagedList<DboCruise>(lsCruises.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentCateID = CatID;
            ViewBag.CurrentPage = pageNumber;
            ViewData["Categories"] = new SelectList(_context.DboCategories, "CatId", "CatName", CatID);
            return View(models);
        }

        // GET: Admin/AdminDboCruises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboCruise = await _context.DboCruises
                .Include(d => d.Cat)
                .FirstOrDefaultAsync(m => m.CruiseId == id);
            if (dboCruise == null)
            {
                return NotFound();
            }

            return View(dboCruise);
        }

        // GET: Admin/AdminDboCruises/Create
        public IActionResult Create()
        {
            ViewData["Categories"] = new SelectList(_context.DboCategories, "CatId", "CatName");
            return View();
        }

        // POST: Admin/AdminDboCruises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CruiseId,CruiseName,ShortDesc,Description,CatId,Price,Discount,Thumb,Video,CreatedDate,ModifiedDate,BestSellers,HomeFlag,Active,Tags,Title,Alias,MetaDesc,MetaKey,UnitslnStock")] DboCruise dboCruise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dboCruise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categories"] = new SelectList(_context.DboCategories, "CatId", "CatName", dboCruise.CatId);
            return View(dboCruise);
        }

        // GET: Admin/AdminDboCruises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboCruise = await _context.DboCruises.FindAsync(id);
            if (dboCruise == null)
            {
                return NotFound();
            }
            ViewData["Categories"] = new SelectList(_context.DboCategories, "CatId", "CatName", dboCruise.CatId);
            return View(dboCruise);
        }

        // POST: Admin/AdminDboCruises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CruiseId,CruiseName,ShortDesc,Description,CatId,Price,Discount,Thumb,Video,CreatedDate,ModifiedDate,BestSellers,HomeFlag,Active,Tags,Title,Alias,MetaDesc,MetaKey,UnitslnStock")] DboCruise dboCruise)
        {
            if (id != dboCruise.CruiseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dboCruise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DboCruiseExists(dboCruise.CruiseId))
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
            ViewData["Categories"] = new SelectList(_context.DboCategories, "CatId", "CatName", dboCruise.CatId);
            return View(dboCruise);
        }

        // GET: Admin/AdminDboCruises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboCruise = await _context.DboCruises
                .Include(d => d.Cat)
                .FirstOrDefaultAsync(m => m.CruiseId == id);
            if (dboCruise == null)
            {
                return NotFound();
            }

            return View(dboCruise);
        }

        // POST: Admin/AdminDboCruises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dboCruise = await _context.DboCruises.FindAsync(id);
            _context.DboCruises.Remove(dboCruise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DboCruiseExists(int id)
        {
            return _context.DboCruises.Any(e => e.CruiseId == id);
        }
    }
}
