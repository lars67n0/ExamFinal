using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Data;
using BookApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListFinal.Pages.Teachers
{
    public class TeacherCreateModel : PageModel
    {
        //private readonly BookApp.Data.BookListAppDbContext _context;

        [BindProperty]
        public BookApp.Data.Teacher Teachers { get; set; }

        public ITeacherInterface Ig { get; set; }

        public TeacherCreateModel(ITeacherInterface _Ig)
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
            //_context.Teachers.Add(Teachers);
            //await _context.SaveChangesAsync();
            await Ig.AddItemAsync(Teachers);
            return RedirectToPage("./Index");
        }
    }
}
