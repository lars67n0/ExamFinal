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
    public class ClassIndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        //private readonly BookApp.Data.BookListAppDbContext _context;

        public IList<BookApp.Data.Class> Classes { get; set; }
        public IClassInterface Ig { get; set; }

        public ClassIndexModel(IClassInterface _Ig)
        {
            Ig = _Ig;
        }

        //public IEnumerable<Class> Classes { get; set; }

        public async Task OnGetAsync()
        {
            //Classes = await _context.Classes.ToListAsync();
            Classes = await Ig.GetItemsAsync();
        }
    }
}
