﻿// <auto-generated />
using EscalaWebMvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EscalaWebMvc.Migrations
{
    [DbContext(typeof(EscalaWebMvcContext))]
    partial class EscalaWebMvcContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EscalaWebMvc.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Zona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Area");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Zona = "Musculação"
                        },
                        new
                        {
                            Id = 2,
                            Zona = "Recepção"
                        },
                        new
                        {
                            Id = 3,
                            Zona = "Limpeza"
                        });
                });

            modelBuilder.Entity("EscalaWebMvc.Models.Escala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Escala");
                });

            modelBuilder.Entity("EscalaWebMvc.Models.Func", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SetorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SetorId");

                    b.ToTable("Func");
                });

            modelBuilder.Entity("EscalaWebMvc.Models.Func", b =>
                {
                    b.HasOne("EscalaWebMvc.Models.Area", "Setor")
                        .WithMany("Funcionario")
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("EscalaWebMvc.Models.Area", b =>
                {
                    b.Navigation("Funcionario");
                });
#pragma warning restore 612, 618
        }
    }
}
