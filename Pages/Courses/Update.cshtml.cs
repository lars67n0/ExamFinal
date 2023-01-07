using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListFinal.Pages.Courses
{
    public class CoursesUpdateModel : PageModel
    {
        //private readonly BookApp.Data.BookListAppDbContext _context;

        [BindProperty]
        public BookApp.Data.Course Courses { get; set; }
        public ICourseInterface Ig  { get; set; }
        public CoursesUpdateModel(ICourseInterface _Ig)
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

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Attach(Courses).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch
            //{
            //    throw;
            //}
            await Ig.UpdateItemAsync(Ig);

            return RedirectToPage("./Index");
        }

    }
}
