using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Data;
using BookApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListFinal.Pages.Educations
{
    public class EducationCreateModel : PageModel
    {
        //private readonly BookApp.Data.BookListAppDbContext _context;

        [BindProperty]
        public BookApp.Data.Education Educations { get; set; }
        public IEducationInterface Ig { get; set; }
        public EducationCreateModel(IEducationInterface _Ig)
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
            //_context.Educations.Add(Educations);
            //await _context.SaveChangesAsync();
            await Ig.AddItemAsync(Educations);

            return RedirectToPage("./Index");
        }
    }
}
