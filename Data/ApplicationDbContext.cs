using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CHUTHIENTU_639.Models;

namespace Cau2
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CHUTHIENTU_639.Models.Cau2> Cau2 { get; set; } = default!;
    }
}
