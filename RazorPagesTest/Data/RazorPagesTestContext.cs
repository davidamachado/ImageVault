using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesTest.Models;

namespace RazorPagesTest.Data
{
    public class RazorPagesTestContext : DbContext
    {
        public RazorPagesTestContext (DbContextOptions<RazorPagesTestContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesTest.Models.Image> Image { get; set; }
    }
}
