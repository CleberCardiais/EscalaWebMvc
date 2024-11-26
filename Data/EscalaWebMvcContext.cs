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

        public DbSet<EscalaWebMvc.Models.Func> Func { get; set; } 
        public DbSet<EscalaWebMvc.Models.Area> Area { get; set; }
        public DbSet<EscalaWebMvc.Models.Escala> Escala { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>().HasData(
                new Area { Id = 1, Zona = "Musculação" },
                new Area { Id = 2, Zona = "Recepção" },
                new Area { Id = 3, Zona = "Limpeza" }
            );
        }


    }
}
