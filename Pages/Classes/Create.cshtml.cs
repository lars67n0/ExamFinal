using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Data;
using BookApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListFinal.Pages.Classes
{
    public class ClassCreateModel : PageModel
    {
        //private readonly BookApp.Data.BookListAppDbContext _context;

        [BindProperty]
        public BookApp.Data.Class Classes { get; set; }
        public IClassInterface Ig { get; set; }

        public ClassCreateModel(IClassInterface _Ig)
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
            //_context.Classes.Add(Classes);
            //await _context.SaveChangesAsync();
            await Ig.AddItemAsync(Classes);

            return RedirectToPage("./Index");
        }
    }


}
