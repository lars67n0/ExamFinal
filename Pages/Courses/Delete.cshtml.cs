using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Data;
using BookApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListFinal.Pages.Courses
{
    public class CourseDeleteModel : PageModel
    {
        //private readonly BookApp.Data.BookListAppDbContext _context;

        [BindProperty]
        public BookApp.Data.Course Courses { get; set; }
        public IGenericInterface<Course> Ig { get; set; }
        public CourseDeleteModel(IGenericInterface<Course> _Ig)
        {
            Ig = _Ig;
        }

        // Proctecting Agaist Overposting tror jeg


        public async Task<IActionResult> OnGetAsync(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //Courses = await _context.Courses.FirstOrDefaultAsync(m => m.Id == id);

            //if (Courses == null)
            //{
            //    return NotFound();
            //}
            Courses = await Ig.GetItemAsyncById(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //Courses = await _context.Courses.FindAsync(id);

            //if (Courses != null)
            //{
            //    _context.Courses.Remove(Courses);
            //    await _context.SaveChangesAsync();
            //}
            await Ig.DeleteItemsAsync(Courses);

            return RedirectToPage("./Index");
        }
    }
}
