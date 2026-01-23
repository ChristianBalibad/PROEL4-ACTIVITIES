using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UndefinedShoes.Data;
using UndefinedShoes.Models;

namespace UndefinedShoes.Pages.Shoes
{
    public class EditModel : PageModel
    {
        private readonly UndefinedShoes.Data.UndefinedShoesContext _context;

        public EditModel(UndefinedShoes.Data.UndefinedShoesContext context)
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

            var shoe =  await _context.Shoe.FirstOrDefaultAsync(m => m.Id == id);
            if (shoe == null)
            {
                return NotFound();
            }
            Shoe = shoe;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Shoe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoeExists(Shoe.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShoeExists(int id)
        {
            return _context.Shoe.Any(e => e.Id == id);
        }
    }
}
