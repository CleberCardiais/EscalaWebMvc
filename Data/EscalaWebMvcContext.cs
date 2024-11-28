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
        public EscalaWebMvcContext(DbContextOptions<EscalaWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<EscalaWebMvc.Models.Func> Func { get; set; }
        public DbSet<EscalaWebMvc.Models.Area> Area { get; set; }


        // Removida DbSet<Escala>, pois não será persistida no banco

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Adicionar dados iniciais para Area
            modelBuilder.Entity<Area>().HasData(
                new Area { Id = 1, Zona = "Musculação" },
                new Area { Id = 2, Zona = "Recepção" },
                new Area { Id = 3, Zona = "Limpeza" }
            );

            // Configuração adicional: Ignorar a propriedade FuncionariosPorTurno
            modelBuilder.Entity<Escala>()
                .Ignore(e => e.FuncionariosPorTurno);

            modelBuilder.Entity<Escala>()
        .Ignore(e => e.FuncionariosPorTurno)
        .HasNoKey(); // Marcar Escala como entidade sem chave

            // Configurações adicionais podem ser adicionadas aqui no futuro


            base.OnModelCreating(modelBuilder); // Chamar o método base
        }

    }
}
