using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Data;
using BookApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListFinal.Pages.Books
{
    public class BookDeleteModel : PageModel
    {
        //private readonly BookApp.Data.BookListAppDbContext _context;
        [BindProperty]
        public BookApp.Data.Book Books { get; set; }
        public IBookInterface Ig { get; set; }

        public BookDeleteModel(IBookInterface _Ig)
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

            //Books = await _context.Books.FirstOrDefaultAsync(m => m.Id == id);
          Books=   await Ig.GetItemAsyncById(id);

            //if (Books == null)
            //{
            //    return NotFound();
            //}
            return Page();
        }

    
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Books = await _context.Books.FindAsync(id);

            //if (Books != null)
            // {
            //     _context.Books.Remove(Books);
            //     await _context.SaveChangesAsync();
            // }
            await Ig.DeleteItemsAsync(Books);
            return RedirectToPage("./Index");
        }
    }
}
