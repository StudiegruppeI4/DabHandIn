using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DabHandIn2.Models;

namespace DabHandIn2.Controllers
{
    public class HelpRequestsController : Controller
    {
        private readonly HelpRequestContext _context;

        public HelpRequestsController(HelpRequestContext context)
        {
            _context = context;
        }

        // GET: HelpRequests
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        // GET: HelpRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.auId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: HelpRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HelpRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("auId,Name,Email")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: HelpRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: HelpRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("auId,Name,Email")] Student student)
        {
            if (id != student.auId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.auId))
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
            return View(student);
        }

        // GET: HelpRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.auId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: HelpRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.auId == id);
        }
    }
}
