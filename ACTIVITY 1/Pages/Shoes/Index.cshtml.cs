using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesUndefined.Data;
using RazorPagesUndefined.Models;

namespace RazorPagesUndefined.Pages.Shoes
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesUndefined.Data.RazorPagesUndefinedContext _context;

        public IndexModel(RazorPagesUndefined.Data.RazorPagesUndefinedContext context)
        {
            _context = context;
        }

        public IList<Shoe> Shoe { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Shoe = await _context.Shoe.ToListAsync();
        }
    }
}
