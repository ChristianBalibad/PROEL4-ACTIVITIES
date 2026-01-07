using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesUndefined.Models;

namespace RazorPagesUndefined.Data
{
    public class RazorPagesUndefinedContext : DbContext
    {
        public RazorPagesUndefinedContext (DbContextOptions<RazorPagesUndefinedContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesUndefined.Models.Shoe> Shoe { get; set; } = default!;
    }
}
