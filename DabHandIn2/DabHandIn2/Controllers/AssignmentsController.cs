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
    public class AssignmentsController : Controller
    {
        private readonly HelpRequestContext _context;

        public AssignmentsController(HelpRequestContext context)
        {
            _context = context;
        }

        // GET: Assignments
        public async Task<IActionResult> Index()
        {
            var assignments = await _context.Assignments.ToListAsync();
            List<Student> students = new List<Student>();
            foreach (var assignment in assignments)
            {
                students.Add(await _context.Students.FindAsync(assignment.StudentauId));
            }

            ViewData["Emails"] = students;
            return View(assignments);
        }

        // GET: Assignments/Create
        public IActionResult Create(int student)
        {
            ViewData["ID"] = student;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,CourseId")] Assignment assignment, int id)
        {
            if (ModelState.IsValid)
            {
                assignment.StudentauId = id;
                _context.Add(assignment);
                await _context.SaveChangesAsync();
                return RedirectToAction("AddAssignment", "Students",
                    new { assignmentId = assignment.Id, name = assignment.Name, id = id, courseId = assignment.CourseId });
            }
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignments.Any(e => e.Id == id);
        }
    }
}
