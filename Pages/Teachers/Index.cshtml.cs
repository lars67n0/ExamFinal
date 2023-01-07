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
    public class TeacherIndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]

        public IList<BookApp.Data.Teacher> Teachers { get; set; }

        //private readonly BookApp.Data.BookListAppDbContext _context;

        public ITeacherInterface Ig { get; set; }

        public TeacherIndexModel(ITeacherInterface _Ig)
        {
            Ig = _Ig;
        }


            public async Task OnGetAsync()
            {
            Teachers = await Ig.GetItemsAsync();
            }

        
    }
}
