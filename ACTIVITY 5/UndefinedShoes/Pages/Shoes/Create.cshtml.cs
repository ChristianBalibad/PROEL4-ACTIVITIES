using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UndefinedShoes.Data;
using UndefinedShoes.Models;

namespace UndefinedShoes.Pages.Shoes
{
    public class CreateModel : PageModel
    {
        private readonly UndefinedShoes.Data.UndefinedShoesContext _context;

        public CreateModel(UndefinedShoes.Data.UndefinedShoesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Shoe Shoe { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Shoe.Add(Shoe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
