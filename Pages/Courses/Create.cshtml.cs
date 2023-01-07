using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Data;
using BookApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListFinal.Pages.Courses
{
    public class CourseCreateModel : PageModel
    {
        //private readonly BookApp.Data.BookListAppDbContext _context;
        [BindProperty]
        public BookApp.Data.Course Courses { get; set; }
        public ICourseInterface Ig { get; set; }
        public CourseCreateModel(ICourseInterface _Ig)
        {
            Ig = _Ig;
        }

        public IActionResult OnGet()
        {
            
            return Page();
        }

 
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            //_context.Courses.Add(Courses);
            //await _context.SaveChangesAsync();

            await Ig.AddItemAsync(Courses);
            return RedirectToPage("./Index");
        }
    }
}
