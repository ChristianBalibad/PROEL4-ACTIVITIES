using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using UndefinedShoes.Models;

namespace UndefinedShoes.Data
{
    public class UndefinedShoesContext : IdentityDbContext
    {
        public UndefinedShoesContext (DbContextOptions<UndefinedShoesContext> options)
            : base(options)
        {
        }

        public DbSet<UndefinedShoes.Models.Shoe> Shoe { get; set; } = default!;
    }
}
