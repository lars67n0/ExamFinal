using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Data;
using BookApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListFinal.Pages.Teachers
{
    public class TeacherDeleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        //private readonly BookApp.Data.BookListAppDbContext _context;
    
        public BookApp.Data.Teacher Teachers { get; set; }
        public ITeacherInterface Ig { get; set; }

        public TeacherDeleteModel(ITeacherInterface _Ig )
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

            //Teachers = await _context.Teachers.FirstOrDefaultAsync(m => m.Id == id);

            //if (Teachers == null)
            //{
            //    return NotFound();
            //}
            Teachers = await Ig.GetItemAsyncById(id);
            return Page();
        }

 
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //Teachers = await _context.Teachers.FindAsync(id);

            //if (Teachers != null)
            //{
            //    _context.Teachers.Remove(Teachers);
            //    await _context.SaveChangesAsync();
            //}

            await Ig.DeleteItemsAsync(Teachers);
            return RedirectToPage("./Index");
        }
    }
}
