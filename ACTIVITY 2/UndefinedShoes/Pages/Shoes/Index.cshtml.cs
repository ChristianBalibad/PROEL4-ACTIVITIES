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
    public class IndexModel : PageModel
    {
        private readonly UndefinedShoes.Data.UndefinedShoesContext _context;

        public IndexModel(UndefinedShoes.Data.UndefinedShoesContext context)
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
