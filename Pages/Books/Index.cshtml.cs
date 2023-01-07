using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookApp.Data;
using BookApp.Data.Interfaces;

namespace BookListFinal.Pages.Books
{
    public class BookIndexModel : PageModel

    {
        [BindProperty(SupportsGet = true)]
        //private readonly BookApp.Data.BookListAppDbContext _context;

        public IList<BookApp.Data.Book> Books { get; set; }
        public IBookInterface Ig { get; set; }
        public BookIndexModel(IBookInterface _Ig)
        {
            Ig = _Ig;
        }

        //public IEnumerable<Book> Ebooks { get; set; }

        public async Task OnGetAsync()
        {
            Books = await Ig.GetItemsAsync();

        }

    }
}

