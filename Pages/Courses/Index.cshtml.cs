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
    public class CoursesIndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        //private readonly BookApp.Data.BookListAppDbContext _context;

        public IList<BookApp.Data.Course> Courses { get; set; }
        public ICourseInterface Ig { get; set; }

        public CoursesIndexModel(ICourseInterface _Ig )
        {
            Ig = _Ig;
        }

        //public IEnumerable<Course> Courses { get; set; }

        public async Task OnGetAsync()
        {
            Courses = await Ig.GetItemsAsync();

        }
    }
}
