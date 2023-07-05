using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using TravelFinalProject.Models;

namespace TravelFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDboRolesController : Controller
    {
        private readonly Travel_DatabaseContext _context;
        public INotyfService _notifyService { get; }
        public AdminDboRolesController(Travel_DatabaseContext context, INotyfService notifyService)
        {
            _context = context;
            _notifyService = notifyService;
        }

        // GET: Admin/AdminDboRoles
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 20;
            var lsRoles = _context.DboRoles.AsNoTracking().OrderByDescending(x => x.RoleId);
            PagedList<DboRole> models = new PagedList<DboRole>(lsRoles, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/AdminDboRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboRole = await _context.DboRoles
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (dboRole == null)
            {
                return NotFound();
            }

            return View(dboRole);
        }

        // GET: Admin/AdminDboRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminDboRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,RoleName,Description")] DboRole dboRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dboRole);
                await _context.SaveChangesAsync();
                _notifyService.Success("Successful!");
                return RedirectToAction(nameof(Index));
            }
            return View(dboRole);
        }

        // GET: Admin/AdminDboRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboRole = await _context.DboRoles.FindAsync(id);
            if (dboRole == null)
            {
                return NotFound();
            }
            return View(dboRole);
        }

        // POST: Admin/AdminDboRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleId,RoleName,Description")] DboRole dboRole)
        {
            if (id != dboRole.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dboRole);
                    await _context.SaveChangesAsync();
                    _notifyService.Success("Successful Update!");

				}
                catch (DbUpdateConcurrencyException)
                {
                    if (!DboRoleExists(dboRole.RoleId))
                    {
                        _notifyService.Success("Error!");
						return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dboRole);
        }

        // GET: Admin/AdminDboRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboRole = await _context.DboRoles
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (dboRole == null)
            {
                return NotFound();
            }

            return View(dboRole);
        }

        // POST: Admin/AdminDboRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dboRole = await _context.DboRoles.FindAsync(id);
            _context.DboRoles.Remove(dboRole);
            await _context.SaveChangesAsync();
            _notifyService.Success("Successful Deletion!");
			return RedirectToAction(nameof(Index));
        }

        private bool DboRoleExists(int id)
        {
            return _context.DboRoles.Any(e => e.RoleId == id);
        }
    }
}
