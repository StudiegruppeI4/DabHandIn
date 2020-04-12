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
    public class ExercisesController : Controller
    {
        private readonly HelpRequestContext _context;

        public ExercisesController(HelpRequestContext context)
        {
            _context = context;
        }

        // GET: Exercises
        public async Task<IActionResult> Index()
        {
            var exercises = await _context.Exercises.ToListAsync();
            List<Student> students = new List<Student>();
            foreach (var exercise in exercises)
            {
                students.Add(await _context.Students.FindAsync(exercise.StudentauId));
            }

            ViewData["Emails"] = students;
            return View(exercises);
        }

        // GET: Exercises/Create
        public IActionResult Create(int student)
        {
            ViewData["ID"] = student;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Lecture,Number,CourseId")] Exercise exercise, int id)
        {
            if (ModelState.IsValid)
            {
                exercise.StudentauId = id;
                _context.Add(exercise);
                await _context.SaveChangesAsync();
                return RedirectToAction("AddExercise", "Students",
                    new {id = id, lecture = exercise.Lecture, number = exercise.Number, courseId = exercise.CourseId});
            }
            return View(exercise);
        }

        // GET: Exercises/Delete/5
        public async Task<IActionResult> Delete(string lecture, int number)
        {
            var exercise = await _context.Exercises
                .FirstOrDefaultAsync(m => m.Lecture == lecture && m.Number == number);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string lecture, int number)
        {
            var exercise = await _context.Exercises.FindAsync(lecture, number);
            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
