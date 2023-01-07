using BookApp.Data;
using BookApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookListFinal.Pages.Books
{
    public class BookUpdateModel : PageModel
    {
        //private readonly BookApp.Data.BookListAppDbContext _context;

        [BindProperty]
        public BookApp.Data.Book Books { get; set; }
        public IBookInterface Ig { get; set; }
        public BookUpdateModel(IBookInterface _Ig)
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

            //if (Books == null)
            //{
            //    return NotFound();
            //}
         Books= await Ig.GetItemAsyncById(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //if(!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Attach(Books).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch
            //{
            //    throw;
            //}
            await Ig.UpdateItemAsync2(Books);
            return RedirectToPage("./Index");
        }

    }

    
}
