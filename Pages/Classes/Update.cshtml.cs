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
    public class ClassUpdateModel : PageModel
    {
        //private readonly BookApp.Data.BookListAppDbContext _context;

        [BindProperty]
        public BookApp.Data.Class Classes { get; set; }
        public IClassInterface Ig { get; set; }

        public ClassUpdateModel(IClassInterface _Ig)
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

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Attach(Classes).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch
            //{
            //    throw;
            //}
            await Ig.UpdateItemAsync2(Classes);

            return RedirectToPage("./Index");
        }
    }
}
