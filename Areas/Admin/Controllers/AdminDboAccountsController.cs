using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using TravelFinalProject.Models;

namespace TravelFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDboAccountsController : Controller
    {
        private readonly Travel_DatabaseContext _context;

        public AdminDboAccountsController(Travel_DatabaseContext context)
        {
            _context = context;
        }



		// GET: Admin/AdminDboAccounts
		public async Task<IActionResult> Index()
        {
            ViewData["Role"] = new SelectList(_context.DboRoles, "RoleId", "Description");

            List<SelectListItem> lsStatus = new List<SelectListItem>();
			lsStatus.Add(new SelectListItem() { Text = "Active", Value = "1" });
			lsStatus.Add(new SelectListItem() { Text = "Block", Value = "0" });
            ViewData["lsStatus"] = lsStatus;

            var travel_DatabaseContext = _context.DboAccounts.Include(d => d.Role);
            return View(await travel_DatabaseContext.ToListAsync());
        }

        // GET: Admin/AdminDboAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboAccount = await _context.DboAccounts
                .Include(d => d.Role)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (dboAccount == null)
            {
                return NotFound();
            }

            return View(dboAccount);
        }

        // GET: Admin/AdminDboAccounts/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.DboRoles, "RoleId", "RoleId");
            return View();
        }

        // POST: Admin/AdminDboAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,Phone,Email,Password,Salt,Active,FullName,RoleId,LastLogin,CreateDate")] DboAccount dboAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dboAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.DboRoles, "RoleId", "RoleId", dboAccount.RoleId);
            return View(dboAccount);
        }

        // GET: Admin/AdminDboAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboAccount = await _context.DboAccounts.FindAsync(id);
            if (dboAccount == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.DboRoles, "RoleId", "RoleId", dboAccount.RoleId);
            return View(dboAccount);
        }

        // POST: Admin/AdminDboAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,Phone,Email,Password,Salt,Active,FullName,RoleId,LastLogin,CreateDate")] DboAccount dboAccount)
        {
            if (id != dboAccount.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dboAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DboAccountExists(dboAccount.AccountId))
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
            ViewData["RoleId"] = new SelectList(_context.DboRoles, "RoleId", "RoleId", dboAccount.RoleId);
            return View(dboAccount);
        }

        // GET: Admin/AdminDboAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboAccount = await _context.DboAccounts
                .Include(d => d.Role)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (dboAccount == null)
            {
                return NotFound();
            }

            return View(dboAccount);
        }

        // POST: Admin/AdminDboAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dboAccount = await _context.DboAccounts.FindAsync(id);
            _context.DboAccounts.Remove(dboAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DboAccountExists(int id)
        {
            return _context.DboAccounts.Any(e => e.AccountId == id);
        }
    }
}
