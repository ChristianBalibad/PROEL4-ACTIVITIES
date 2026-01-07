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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesUndefined.Data.RazorPagesUndefinedContext _context;

        public DetailsModel(RazorPagesUndefined.Data.RazorPagesUndefinedContext context)
        {
            _context = context;
        }

        public Shoe Shoe { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoe.FirstOrDefaultAsync(m => m.Id == id);
            if (shoe == null)
            {
                return NotFound();
            }
            else
            {
                Shoe = shoe;
            }
            return Page();
        }
    }
}
