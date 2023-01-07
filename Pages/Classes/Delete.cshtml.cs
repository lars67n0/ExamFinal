using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Data;
using BookApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListFinal.Pages.Classes
{
    public class ClassDeleteModel : PageModel
    {
        //private readonly BookApp.Data.BookListAppDbContext _context;
        [BindProperty]
        public BookApp.Data.Class Classes { get; set; }
        public IClassInterface Ig { get; set; }
        public ClassDeleteModel(IClassInterface _Ig)
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

            //Classes = await _context.Classes.FirstOrDefaultAsync(m => m.Id == id);

            //if (Classes == null)
            //{
            //    return NotFound();
            //}
            Classes = await Ig.GetItemAsyncById(id);
            return Page();
        }

     
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Classes = await _context.Classes.FindAsync(id);

            //if (Classes != null)
            //{
            //    _context.Classes.Remove(Classes);
            //    await _context.SaveChangesAsync();
            //}
            await Ig.DeleteItemsAsync(Classes);
            return RedirectToPage("./Index");
        }
    }
}
