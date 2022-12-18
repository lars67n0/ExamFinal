using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookApp.Data;


namespace BookListFinal.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookApp.Data.BookListAppDbContext _context;

        public IndexModel(BookApp.Data.BookListAppDbContext context)
        {
            _context = context;
        }

        public IList<BookApp.Data.Book> Book { get; set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Books.ToListAsync();
        }

    }
}

