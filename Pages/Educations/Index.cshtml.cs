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
    public class EducationsIndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        //private readonly BookApp.Data.BookListAppDbContext _context;

        public IList<BookApp.Data.Education> Educations { get; set; }
        public IEducationInterface Ig { get; set; }
        public EducationsIndexModel(IEducationInterface _Ig)
        {
            Ig = _Ig;
        }


        public async Task OnGetAsync()
        {
            Educations = await Ig.GetItemsAsync();
        }
    }
}
