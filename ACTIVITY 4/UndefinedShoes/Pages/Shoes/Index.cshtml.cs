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

        [BindProperty(SupportsGet = true)]
        public string? Search { get; set; }

        public IList<Shoe> Shoe { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var shoesQuery = _context.Shoe.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(Search))
            {
                var term = Search.Trim();
                var pattern = $"%{term}%";

                shoesQuery = shoesQuery.Where(s =>
                    (s.Brand != null && EF.Functions.Like(s.Brand, pattern)) ||
                    (s.Model != null && EF.Functions.Like(s.Model, pattern)) ||
                    (s.Style != null && EF.Functions.Like(s.Style, pattern)) ||
                    (s.Color != null && EF.Functions.Like(s.Color, pattern))
                );

                if (int.TryParse(term, out var size))
                {
                    shoesQuery = shoesQuery.Union(
                        _context.Shoe.AsNoTracking().Where(s => s.Size == size)
                    );
                }
            }

            Shoe = await shoesQuery.ToListAsync();
        }
    }
}
