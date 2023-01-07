using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Data;
using BookApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListFinal.Pages.Books
{
    public class BookCreateModel : PageModel
    {
        //private readonly BookApp.Data.BookListAppDbContext _context;

        [BindProperty]
        public BookApp.Data.Book Books { get; set; }
        public IBookInterface  Ig { get; set; }
        public BookCreateModel(IBookInterface _Ig)
        {
            Ig = _Ig;
        }

        public IActionResult OnGet()
        {
          
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //_context.Books.Add(Books);
            //await _context.SaveChangesAsync();
            await Ig.AddItemAsync(Books);

            return RedirectToPage("./Index");
        }
    }
}
