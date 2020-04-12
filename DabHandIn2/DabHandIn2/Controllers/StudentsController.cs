using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DabHandIn2.Models;

namespace DabHandIn2.Controllers
{
    public class StudentsController : Controller
    {
        private readonly HelpRequestContext _context;

        public StudentsController(HelpRequestContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .Include(s => s.Exercises)
                .Include(s => s.Assignments)
                .ToListAsync());
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> AddCourse(int? id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            ViewData["ID"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCourse([Bind("auId,CourseId")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
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

        // GET: Students/Delete/5
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

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddExercise(int id, string lecture, int number, int courseId)
        {
            var student = await _context.Students.FindAsync(id);
            var course = await _context.Courses.FindAsync(courseId);
            var exercise = await _context.Exercises.FindAsync(lecture, number);

            if (student.Exercises == null)
            {
                student.Exercises = new List<Exercise>();
            }

            if (course.Exercises == null)
            {
                course.Exercises = new List<Exercise>();
            }
            course.Exercises.Add(exercise);

            student.Exercises.Add(exercise);
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddAssignment(int id, int assignmentId, string name, int courseId)
        {
            var student = await _context.Students.FindAsync(id);
            var course = await _context.Courses.FindAsync(courseId);
            var assignment = await _context.Assignments.FindAsync(assignmentId);

            if (student.Assignments == null)
            {
                student.Assignments = new List<Assignment>();
            }
            student.Assignments.Add(assignment);

            if (course.Assignments == null)
            {
                course.Assignments = new List<Assignment>();
            }
            course.Assignments.Add(assignment);

            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.auId == id);
        }
    }
}
