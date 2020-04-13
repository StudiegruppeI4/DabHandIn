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
        public async Task<IActionResult> CourseHelpRequests(int CourseId)
        {
            ViewData["Course"] = await _context.Courses.FindAsync(CourseId);

            List<Student> students = await _context.Students
                .Include(s => s.Assignments)
                .Include(s => s.Exercises)
                .Where(s => s.StudentCourses.Any(sc => sc.CourseId == CourseId))
                .ToListAsync();
                return View(students);
        }
    }
}
