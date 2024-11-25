using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EscalaWebMvc.Models;

namespace EscalaWebMvc.Data
{
    public class EscalaWebMvcContext : DbContext
    {
        public EscalaWebMvcContext (DbContextOptions<EscalaWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<EscalaWebMvc.Models.Func> Func { get; set; } = default!;
    }
}
