using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UndefinedShoes.Data;
using UndefinedShoes.Models;

namespace UndefinedShoes.Pages.Shoes
{
    public class DeleteModel : PageModel
    {
        private readonly UndefinedShoes.Data.UndefinedShoesContext _context;

        public DeleteModel(UndefinedShoes.Data.UndefinedShoesContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoe.FindAsync(id);
            if (shoe != null)
            {
                Shoe = shoe;
                _context.Shoe.Remove(Shoe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
