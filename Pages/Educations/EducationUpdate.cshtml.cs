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
    public class EducationUpdateModel : PageModel
    {
        //private readonly BookApp.Data.BookListAppDbContext _context;
        [BindProperty]
        public BookApp.Data.Education Educations { get; set; }
        public IEducationInterface Ig { get; set; }

        public EducationUpdateModel(IEducationInterface _Ig)
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


        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Attach(Educations).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch
            //{
            //    throw;
            //}

            await Ig.UpdateItemAsync2(Educations);

            return RedirectToPage("./Index");
        }

    }
}

