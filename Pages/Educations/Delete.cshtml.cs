using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Data;
using BookApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListFinal.Pages.Educations
{
    public class EducationDeleteModel : PageModel
    {
        //private readonly BookApp.Data.BookListAppDbContext _context;

        [BindProperty]
        public BookApp.Data.Education Educations { get; set; }
        public IEducationInterface Ig  { get; set; }

        public EducationDeleteModel(IEducationInterface _Ig)
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

            //Educations = await _context.Educations.FirstOrDefaultAsync(m => m.Id == id);

            //if (Educations == null)
            //{
            //    return NotFound();
            //}
            Educations = await Ig.GetItemAsyncById(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //Educations = await _context.Educations.FindAsync(id);

            //if (Educations != null)
            //{
            //    _context.Educations.Remove(Educations);
            //    await _context.SaveChangesAsync();
            //}
            await Ig.DeleteItemsAsync(Educations);

            return RedirectToPage("./Index");
        }
    }
}
