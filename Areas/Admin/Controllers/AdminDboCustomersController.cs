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
    public class AdminDboCustomersController : Controller
    {
        private readonly Travel_DatabaseContext _context;

        public AdminDboCustomersController(Travel_DatabaseContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminDboCustomers
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 20;
            var lsCustomers = _context.DboCustomers.AsNoTracking().Include(x=>x.Location).OrderByDescending(x => x.CustomerId);
            PagedList<DboCustomer> models = new PagedList<DboCustomer>(lsCustomers, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/AdminDboCustomers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboCustomer = await _context.DboCustomers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (dboCustomer == null)
            {
                return NotFound();
            }

            return View(dboCustomer);
        }

        // GET: Admin/AdminDboCustomers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminDboCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FullName,Birthday,Avatar,Address,Email,Phone,LocationId,District,Ward,CreateDate,Password,Salt,LastLogin,Active")] DboCustomer dboCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dboCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dboCustomer);
        }

        // GET: Admin/AdminDboCustomers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboCustomer = await _context.DboCustomers.FindAsync(id);
            if (dboCustomer == null)
            {
                return NotFound();
            }
            return View(dboCustomer);
        }

        // POST: Admin/AdminDboCustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FullName,Birthday,Avatar,Address,Email,Phone,LocationId,District,Ward,CreateDate,Password,Salt,LastLogin,Active")] DboCustomer dboCustomer)
        {
            if (id != dboCustomer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dboCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DboCustomerExists(dboCustomer.CustomerId))
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
            return View(dboCustomer);
        }

        // GET: Admin/AdminDboCustomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dboCustomer = await _context.DboCustomers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (dboCustomer == null)
            {
                return NotFound();
            }

            return View(dboCustomer);
        }

        // POST: Admin/AdminDboCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dboCustomer = await _context.DboCustomers.FindAsync(id);
            _context.DboCustomers.Remove(dboCustomer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DboCustomerExists(int id)
        {
            return _context.DboCustomers.Any(e => e.CustomerId == id);
        }
    }
}
